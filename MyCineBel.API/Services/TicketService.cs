using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MyCineBel.API.DAL;
using MyCineBel.API.Models;
using MyCineBel.API.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCineBel.API.Services
{
    public class TicketService : ITicketService
    {
        private readonly ProjetMyCinebelContext _context;

        public TicketService(ProjetMyCinebelContext context)
        {
            _context = context;
        }

        //Retirer une  réservation
        public async Task<ProcSelectMyReservation> GetMaReservation(int Id)
        {
            var maReservation = await (from Ci in _context.Cinemas
                                         join Sa in _context.Salles on Ci.CIN_Id equals Sa.SAL_CIN_Id
                                         join Sea in _context.Seances on Sa.SAL_Id equals Sea.Sea_SAL_Id
                                         join Ta in _context.TarifSeances on Sea.SEA_Id equals Ta.TarSea_Sea_Id
                                         join Ti in _context.Tickets on Ta.TarSea_Id equals Ti.TIC_TarSea_Id
                                         join Co in _context.Comptes on Ti.TIC_COM_Id equals Co.COM_Id
                                         join Fi in _context.Films on Sea.Sea_Film_Id equals Fi.Film_Id

                                         where Ti.TIC_Id == Id && Sea.SEA_HeureDebut > DateTime.Now
                                         select new ProcSelectMyReservation
                                         {
                                             TicketId = Ti.TIC_Id,
                                             Cinema = Ci.CIN_Name,
                                             Film = Fi.Film_Titre,
                                             salle = Sa.SAL_Id,
                                             prix = Ta.TarSea_Prix,
                                             DateSeance = Sea.SEA_HeureDebut
                                         }).FirstOrDefaultAsync();

            return maReservation;
        }

        //afficher les réservations  par email (par compte)
        public async Task<List<ProcSelectMyReservation>> GetReservation(string email)
        {
            var mesReservations = await (from Ci in _context.Cinemas
                                         join Sa in _context.Salles on Ci.CIN_Id equals Sa.SAL_CIN_Id
                                         join Sea in _context.Seances on Sa.SAL_Id equals Sea.Sea_SAL_Id
                                         join Ta in _context.TarifSeances on Sea.SEA_Id equals Ta.TarSea_Sea_Id
                                         join Ti in _context.Tickets on Ta.TarSea_Id equals Ti.TIC_TarSea_Id
                                         join Co in _context.Comptes on Ti.TIC_COM_Id equals Co.COM_Id
                                         join Fi in _context.Films on Sea.Sea_Film_Id equals Fi.Film_Id

                                         where Co.COM_Email == email && Sea.SEA_HeureDebut > DateTime.Now
                                         select new ProcSelectMyReservation
                                         {
                                             TicketId = Ti.TIC_Id,
                                             Cinema = Ci.CIN_Name,
                                             Film = Fi.Film_Titre,
                                             salle = Sa.SAL_Id,
                                             prix = Ta.TarSea_Prix,
                                             DateSeance = Sea.SEA_HeureDebut
                                         }).ToListAsync();

            return mesReservations;
        }

        //ajouter une reservation
        public async Task<bool> AddReservation(ReservationModel reservation)
        {
            bool TicketReverve;

            Ticket monTicket = new Ticket();

            monTicket.TIC_COM_Id = reservation.Com_Id;

            monTicket.TIC_TarSea_Id = await (from Ta in _context.TarifSeances.Where(x => x.TarSea_Sea_Id == reservation.idSeance
                                             && x.TarSea_Prix == reservation.TarSea_Prix)
                                             select Ta.TarSea_Id).FirstOrDefaultAsync();

            //monTicket.TIC_TarSea_Id = reservation.TarSea_Id;

            monTicket.TIC_DateAchat = DateTime.Now;

            var ListTickets = await (from SE in _context.Seances
                                     join Ta in _context.TarifSeances on SE.SEA_Id equals Ta.TarSea_Sea_Id
                                     join Ti in _context.Tickets on Ta.TarSea_Id equals Ti.TIC_TarSea_Id
                                     where (SE.SEA_Id == reservation.idSeance)
                                     select Ti).ToListAsync();
            var placeAchete = ListTickets.Count;

            int nbrPlaceRestant = reservation.nbrDeplaceMax - placeAchete;

            //Trouver le compte concerné par la réservation
            Compte lecompte = _context.Comptes.Where(X => X.COM_Id == reservation.Com_Id).FirstOrDefault();

            //Enregistrer la réservation et incrémentation du nombre de points
            if (reservation.nbrDeplaDemande < nbrPlaceRestant)
            {
                try
                {
                    for(int i =0; i< reservation.nbrDeplaDemande;i++)
                    {
                        monTicket.TIC_Id = 0;
                        lecompte.COM_NbrPoints += 5;

                        _context.Tickets.Add(monTicket);
                        _context.Entry(lecompte).State = EntityState.Modified;


                        await _context.SaveChangesAsync();
                    }
                   

                    TicketReverve = true;

                }
                catch(Exception ex)
                {
                    TicketReverve = false;

                    
                }
              
            }

            else TicketReverve = false;



            return TicketReverve;
        }

        //effacer une réservation
        public async Task DeleteTicketAsync(int TicketId)
        {
            var Ticket = await _context.Tickets.FindAsync(TicketId);

            //trouver le compte concerné


            if (Ticket != null)
            {
                Compte lecompte = await (from Co in _context.Comptes
                                         join Ti in _context.Tickets on Co.COM_Id equals Ti.TIC_COM_Id
                                         where (Ti.TIC_Id == TicketId)
                                         select Co).FirstOrDefaultAsync();

                if (lecompte.COM_NbrPoints > 0)
                lecompte.COM_NbrPoints -= 5;

                _context.Entry(lecompte).State = EntityState.Modified;
                _context.Tickets.Remove(Ticket);
            }
            await _context.SaveChangesAsync();
        }

        public string GetHTMLString(int Id)
        {
            var monTicket = GetMaReservation(Id);

            var sb = new StringBuilder();

            sb.Append(@"
                        <html>
                            <head>
                             
                            </head>
                            <body>
                                <div class='header'><h1> Mon ticket pour la seance!!!</h1></div>"
                       );

            sb.AppendFormat(@"
                           <table>
                           <tr> 
                           <th> </th>
                           <th> </th>
                         
                          </tr>");

            sb.AppendFormat(@"<tr>
                                    <td>Numero :</td>
                                    <td>{0}</td>
                                  </tr>

                                    <tr>
                                    <td>Cinema :</td>
                                    <td>{1}</td>
                                  </tr>
                                  
                                 <tr>
                                    <td>Film :</td>
                                    <td>{2}</td>
                                  </tr>

                                 <tr>
                                    <td>Salle :</td>
                                    <td>{3}</td>
                                  </tr>

                                <tr>
                                    <td>Prix :</td>             
                                    <td>{4}</td>
                                  </tr>

                               <tr>
                                    <td>Date :</td>
                                    <td>{5}</td>
                                  </tr>", monTicket.Result.TicketId, monTicket.Result.Cinema, monTicket.Result.Film, monTicket.Result.salle,
                              monTicket.Result.prix, monTicket.Result.DateSeance.ToString("dd/MM/yyyy HH mm "));

            sb.Append(@"
                            </table>    
                            </body>
                        </html>"



                );

            return sb.ToString();
        }
    }
}
