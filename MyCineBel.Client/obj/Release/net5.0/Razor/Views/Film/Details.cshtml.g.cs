#pragma checksum "C:\Users\JEAN\MonBureau\ephec2021-2022\TFE\ProjetMyCineBel - CopieV3 -swagger\MyCineBel.Client\Views\Film\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "17b2553266d2f4b6daa87fb8513ed5a3d040bb8c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Film_Details), @"mvc.1.0.view", @"/Views/Film/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"17b2553266d2f4b6daa87fb8513ed5a3d040bb8c", @"/Views/Film/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9e1ec9dc7014cd6ff3b38bc7a42040bc91391920", @"/Views/_ViewImports.cshtml")]
    public class Views_Film_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MyCineBel.Client.Models.Film>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("rounded-link d-inline-block rounded p-2 shadow bg-dark a-text"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\JEAN\MonBureau\ephec2021-2022\TFE\ProjetMyCineBel - CopieV3 -swagger\MyCineBel.Client\Views\Film\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h3 class=\"mt-3\">");
#nullable restore
#line 7 "C:\Users\JEAN\MonBureau\ephec2021-2022\TFE\ProjetMyCineBel - CopieV3 -swagger\MyCineBel.Client\Views\Film\Details.cshtml"
            Write(Html.DisplayFor(model => model.Film_Titre));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>

<div class=""container-fluid mt-2"">
    <div class=""row no-gutters w-100 justify-content-center"">
        <div class=""col-sm-6"">
            <div class=""row no-gutters w-100 py-2"">
                <div class=""col-12"">
                    <div class=""row no-gutters justify-content-center"">
                        <div class=""col-4"">
                            <img");
            BeginWriteAttribute("src", " src=\"", 525, "\"", 599, 2);
            WriteAttributeValue("", 531, "https://jeanmusoni.blob.core.windows.net/cineimage/", 531, 51, true);
#nullable restore
#line 16 "C:\Users\JEAN\MonBureau\ephec2021-2022\TFE\ProjetMyCineBel - CopieV3 -swagger\MyCineBel.Client\Views\Film\Details.cshtml"
WriteAttributeValue("", 582, Model.Film_Image, 582, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"img-fluid w-100\" height=\"150\" />\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n                <div class=\"col-12 text-center py-2\">\r\n                    <strong>");
#nullable restore
#line 21 "C:\Users\JEAN\MonBureau\ephec2021-2022\TFE\ProjetMyCineBel - CopieV3 -swagger\MyCineBel.Client\Views\Film\Details.cshtml"
                       Write(Html.DisplayFor(model => model.Film_Titre));

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>\r\n                </div>\r\n                <div class=\"row w-100 no-gutters align-items-start py-2 border-bottom\">\r\n                    <div class=\"col-3 font-weight-bold\">\r\n                        ");
#nullable restore
#line 25 "C:\Users\JEAN\MonBureau\ephec2021-2022\TFE\ProjetMyCineBel - CopieV3 -swagger\MyCineBel.Client\Views\Film\Details.cshtml"
                   Write(Html.DisplayNameFor(model => model.Film_DateSortie));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"col-9\">\r\n                        ");
#nullable restore
#line 28 "C:\Users\JEAN\MonBureau\ephec2021-2022\TFE\ProjetMyCineBel - CopieV3 -swagger\MyCineBel.Client\Views\Film\Details.cshtml"
                   Write(Html.DisplayFor(model => model.Film_DateSortie));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n                <div class=\"row w-100 no-gutters align-items-start py-3 border-bottom\">\r\n                    <div class=\"col-3 font-weight-bold\">\r\n                        ");
#nullable restore
#line 33 "C:\Users\JEAN\MonBureau\ephec2021-2022\TFE\ProjetMyCineBel - CopieV3 -swagger\MyCineBel.Client\Views\Film\Details.cshtml"
                   Write(Html.DisplayNameFor(model => model.Film_Genre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"col-9\">\r\n                        ");
#nullable restore
#line 36 "C:\Users\JEAN\MonBureau\ephec2021-2022\TFE\ProjetMyCineBel - CopieV3 -swagger\MyCineBel.Client\Views\Film\Details.cshtml"
                   Write(Html.DisplayFor(model => model.Film_Genre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n                <div class=\"row w-100 no-gutters align-items-start py-3 border-bottom\">\r\n                    <div class=\"col-3 font-weight-bold\">\r\n                        ");
#nullable restore
#line 41 "C:\Users\JEAN\MonBureau\ephec2021-2022\TFE\ProjetMyCineBel - CopieV3 -swagger\MyCineBel.Client\Views\Film\Details.cshtml"
                   Write(Html.DisplayNameFor(model => model.Film_duree));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"col-9\">\r\n                        ");
#nullable restore
#line 44 "C:\Users\JEAN\MonBureau\ephec2021-2022\TFE\ProjetMyCineBel - CopieV3 -swagger\MyCineBel.Client\Views\Film\Details.cshtml"
                   Write(Html.DisplayFor(model => model.Film_duree));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n                <div class=\"row w-100 no-gutters align-items-start py-3 border-bottom\">\r\n                    <div class=\"col-3 font-weight-bold\">\r\n                        ");
#nullable restore
#line 49 "C:\Users\JEAN\MonBureau\ephec2021-2022\TFE\ProjetMyCineBel - CopieV3 -swagger\MyCineBel.Client\Views\Film\Details.cshtml"
                   Write(Html.DisplayNameFor(model => model.Film_Synopsis));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"col-9\">\r\n                        ");
#nullable restore
#line 52 "C:\Users\JEAN\MonBureau\ephec2021-2022\TFE\ProjetMyCineBel - CopieV3 -swagger\MyCineBel.Client\Views\Film\Details.cshtml"
                   Write(Html.DisplayFor(model => model.Film_Synopsis));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </div>
                </div>
                <div class=""row w-100 no-gutters align-items-start py-3 border-bottom"">
                    <div class=""col-3 font-weight-bold"">
                        Realisateur
                    </div>
                    <div class=""col-9"">
                        ");
#nullable restore
#line 60 "C:\Users\JEAN\MonBureau\ephec2021-2022\TFE\ProjetMyCineBel - CopieV3 -swagger\MyCineBel.Client\Views\Film\Details.cshtml"
                   Write(Html.DisplayName(@ViewBag.NameRealisateur));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </div>\r\n            <div class=\"row w-100 no-gutters py-2 justify-content-center\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "17b2553266d2f4b6daa87fb8513ed5a3d040bb8c10595", async() => {
                WriteLiteral("Listes des films");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div class=\"col-sm-6\">\r\n            <dl class=\"row w-100 no-gutters\">\r\n                <dt class=\"col-sm-12\">\r\n                    ");
#nullable restore
#line 71 "C:\Users\JEAN\MonBureau\ephec2021-2022\TFE\ProjetMyCineBel - CopieV3 -swagger\MyCineBel.Client\Views\Film\Details.cshtml"
               Write(Html.DisplayNameFor(model => model.Film_BandeAnnonce));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dt>\r\n                <dd class=\"col-sm-12\">\r\n                    <video class=\"w-100\" controls>\r\n\r\n                        <source");
            BeginWriteAttribute("src", " src=\"", 3522, "\"", 3603, 2);
            WriteAttributeValue("", 3528, "https://jeanmusoni.blob.core.windows.net/cineimage/", 3528, 51, true);
#nullable restore
#line 76 "C:\Users\JEAN\MonBureau\ephec2021-2022\TFE\ProjetMyCineBel - CopieV3 -swagger\MyCineBel.Client\Views\Film\Details.cshtml"
WriteAttributeValue("", 3579, Model.Film_BandeAnnonce, 3579, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" type=\"video/mp4\">\r\n                        Your browser does not support the video tag.\r\n                    </video>\r\n                </dd>\r\n            </dl>\r\n        </div>\r\n\r\n    </div>\r\n    <div>\r\n\r\n    </div>\r\n  \r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MyCineBel.Client.Models.Film> Html { get; private set; }
    }
}
#pragma warning restore 1591