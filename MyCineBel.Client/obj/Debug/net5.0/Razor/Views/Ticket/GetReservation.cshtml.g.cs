#pragma checksum "C:\Users\JEAN\MonBureau\ephec2021-2022\TFE\ProjetMyCineBel - CopieV3 -swagger\MyCineBel.Client\Views\Ticket\GetReservation.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0e1a370c82bc542e90de1664d212625d4b4548e0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Ticket_GetReservation), @"mvc.1.0.view", @"/Views/Ticket/GetReservation.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\JEAN\MonBureau\ephec2021-2022\TFE\ProjetMyCineBel - CopieV3 -swagger\MyCineBel.Client\Views\_ViewImports.cshtml"
using MyCineBel.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\JEAN\MonBureau\ephec2021-2022\TFE\ProjetMyCineBel - CopieV3 -swagger\MyCineBel.Client\Views\_ViewImports.cshtml"
using MyCineBel.Client.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0e1a370c82bc542e90de1664d212625d4b4548e0", @"/Views/Ticket/GetReservation.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9e1ec9dc7014cd6ff3b38bc7a42040bc91391920", @"/Views/_ViewImports.cshtml")]
    public class Views_Ticket_GetReservation : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<MyCineBel.Client.ViewModel.ProcSelectMyReservation>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("a-text"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "PrintMaReservation", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\JEAN\MonBureau\ephec2021-2022\TFE\ProjetMyCineBel - CopieV3 -swagger\MyCineBel.Client\Views\Ticket\GetReservation.cshtml"
  
    ViewData["Title"] = "GetReservation";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<h3");
            BeginWriteAttribute("style", " style=\"", 131, "\"", 139, 0);
            EndWriteAttribute();
            WriteLiteral(@">Mes reservations</h3>

<div class=""card bg-dark rounded shadow text-light"">
    <div class=""card-body"">
        <table class=""table table-borderless text-light"">
            <thead>
                <tr>
                    <th>
                        ");
#nullable restore
#line 16 "C:\Users\JEAN\MonBureau\ephec2021-2022\TFE\ProjetMyCineBel - CopieV3 -swagger\MyCineBel.Client\Views\Ticket\GetReservation.cshtml"
                   Write(Html.DisplayNameFor(model => model.Cinema));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 19 "C:\Users\JEAN\MonBureau\ephec2021-2022\TFE\ProjetMyCineBel - CopieV3 -swagger\MyCineBel.Client\Views\Ticket\GetReservation.cshtml"
                   Write(Html.DisplayNameFor(model => model.Film));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 22 "C:\Users\JEAN\MonBureau\ephec2021-2022\TFE\ProjetMyCineBel - CopieV3 -swagger\MyCineBel.Client\Views\Ticket\GetReservation.cshtml"
                   Write(Html.DisplayNameFor(model => model.salle));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 25 "C:\Users\JEAN\MonBureau\ephec2021-2022\TFE\ProjetMyCineBel - CopieV3 -swagger\MyCineBel.Client\Views\Ticket\GetReservation.cshtml"
                   Write(Html.DisplayNameFor(model => model.prix));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 28 "C:\Users\JEAN\MonBureau\ephec2021-2022\TFE\ProjetMyCineBel - CopieV3 -swagger\MyCineBel.Client\Views\Ticket\GetReservation.cshtml"
                   Write(Html.DisplayNameFor(model => model.DateSeance));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>Action</th>\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n");
#nullable restore
#line 34 "C:\Users\JEAN\MonBureau\ephec2021-2022\TFE\ProjetMyCineBel - CopieV3 -swagger\MyCineBel.Client\Views\Ticket\GetReservation.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 38 "C:\Users\JEAN\MonBureau\ephec2021-2022\TFE\ProjetMyCineBel - CopieV3 -swagger\MyCineBel.Client\Views\Ticket\GetReservation.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Cinema));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 41 "C:\Users\JEAN\MonBureau\ephec2021-2022\TFE\ProjetMyCineBel - CopieV3 -swagger\MyCineBel.Client\Views\Ticket\GetReservation.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Film));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 44 "C:\Users\JEAN\MonBureau\ephec2021-2022\TFE\ProjetMyCineBel - CopieV3 -swagger\MyCineBel.Client\Views\Ticket\GetReservation.cshtml"
                       Write(Html.DisplayFor(modelItem => item.salle));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 47 "C:\Users\JEAN\MonBureau\ephec2021-2022\TFE\ProjetMyCineBel - CopieV3 -swagger\MyCineBel.Client\Views\Ticket\GetReservation.cshtml"
                       Write(Html.DisplayFor(modelItem => item.prix));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 50 "C:\Users\JEAN\MonBureau\ephec2021-2022\TFE\ProjetMyCineBel - CopieV3 -swagger\MyCineBel.Client\Views\Ticket\GetReservation.cshtml"
                       Write(item.DateSeance.ToString("dddd, dd MMMM yyyy HH:mm"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0e1a370c82bc542e90de1664d212625d4b4548e09488", async() => {
                WriteLiteral("Delete");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 53 "C:\Users\JEAN\MonBureau\ephec2021-2022\TFE\ProjetMyCineBel - CopieV3 -swagger\MyCineBel.Client\Views\Ticket\GetReservation.cshtml"
                                                                    WriteLiteral(item.TicketId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("  |\r\n\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0e1a370c82bc542e90de1664d212625d4b4548e011840", async() => {
                WriteLiteral("Print");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 55 "C:\Users\JEAN\MonBureau\ephec2021-2022\TFE\ProjetMyCineBel - CopieV3 -swagger\MyCineBel.Client\Views\Ticket\GetReservation.cshtml"
                                                                                WriteLiteral(item.TicketId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 58 "C:\Users\JEAN\MonBureau\ephec2021-2022\TFE\ProjetMyCineBel - CopieV3 -swagger\MyCineBel.Client\Views\Ticket\GetReservation.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n</div>\r\n\r\n\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<MyCineBel.Client.ViewModel.ProcSelectMyReservation>> Html { get; private set; }
    }
}
#pragma warning restore 1591
