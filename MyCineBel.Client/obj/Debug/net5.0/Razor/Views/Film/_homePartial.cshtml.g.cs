#pragma checksum "C:\Users\JEAN\MonBureau\ephec2021-2022\TFE\ProjetMyCineBel - CopieV3 -swagger\MyCineBel.Client\Views\Film\_homePartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "edea8698029a5be54915f5bf6141d69dcfc55409"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Film__homePartial), @"mvc.1.0.view", @"/Views/Film/_homePartial.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"edea8698029a5be54915f5bf6141d69dcfc55409", @"/Views/Film/_homePartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9e1ec9dc7014cd6ff3b38bc7a42040bc91391920", @"/Views/_ViewImports.cshtml")]
    public class Views_Film__homePartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<MyCineBel.Client.Models.Film>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "edea8698029a5be54915f5bf6141d69dcfc554093577", async() => {
                WriteLiteral("Create New");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 10 "C:\Users\JEAN\MonBureau\ephec2021-2022\TFE\ProjetMyCineBel - CopieV3 -swagger\MyCineBel.Client\Views\Film\_homePartial.cshtml"
           Write(Html.DisplayNameFor(model => model.Film_Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 13 "C:\Users\JEAN\MonBureau\ephec2021-2022\TFE\ProjetMyCineBel - CopieV3 -swagger\MyCineBel.Client\Views\Film\_homePartial.cshtml"
           Write(Html.DisplayNameFor(model => model.Film_Titre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 16 "C:\Users\JEAN\MonBureau\ephec2021-2022\TFE\ProjetMyCineBel - CopieV3 -swagger\MyCineBel.Client\Views\Film\_homePartial.cshtml"
           Write(Html.DisplayNameFor(model => model.Film_Genre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 19 "C:\Users\JEAN\MonBureau\ephec2021-2022\TFE\ProjetMyCineBel - CopieV3 -swagger\MyCineBel.Client\Views\Film\_homePartial.cshtml"
           Write(Html.DisplayNameFor(model => model.Film_duree));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 22 "C:\Users\JEAN\MonBureau\ephec2021-2022\TFE\ProjetMyCineBel - CopieV3 -swagger\MyCineBel.Client\Views\Film\_homePartial.cshtml"
           Write(Html.DisplayNameFor(model => model.Film_BandeAnnonce));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 25 "C:\Users\JEAN\MonBureau\ephec2021-2022\TFE\ProjetMyCineBel - CopieV3 -swagger\MyCineBel.Client\Views\Film\_homePartial.cshtml"
           Write(Html.DisplayNameFor(model => model.Film_DateSortie));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 28 "C:\Users\JEAN\MonBureau\ephec2021-2022\TFE\ProjetMyCineBel - CopieV3 -swagger\MyCineBel.Client\Views\Film\_homePartial.cshtml"
           Write(Html.DisplayNameFor(model => model.Film_Synopsis));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 31 "C:\Users\JEAN\MonBureau\ephec2021-2022\TFE\ProjetMyCineBel - CopieV3 -swagger\MyCineBel.Client\Views\Film\_homePartial.cshtml"
           Write(Html.DisplayNameFor(model => model.Film_Image));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 34 "C:\Users\JEAN\MonBureau\ephec2021-2022\TFE\ProjetMyCineBel - CopieV3 -swagger\MyCineBel.Client\Views\Film\_homePartial.cshtml"
           Write(Html.DisplayNameFor(model => model.Film_Rea_Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 40 "C:\Users\JEAN\MonBureau\ephec2021-2022\TFE\ProjetMyCineBel - CopieV3 -swagger\MyCineBel.Client\Views\Film\_homePartial.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 43 "C:\Users\JEAN\MonBureau\ephec2021-2022\TFE\ProjetMyCineBel - CopieV3 -swagger\MyCineBel.Client\Views\Film\_homePartial.cshtml"
           Write(Html.DisplayFor(modelItem => item.Film_Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 46 "C:\Users\JEAN\MonBureau\ephec2021-2022\TFE\ProjetMyCineBel - CopieV3 -swagger\MyCineBel.Client\Views\Film\_homePartial.cshtml"
           Write(Html.DisplayFor(modelItem => item.Film_Titre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 49 "C:\Users\JEAN\MonBureau\ephec2021-2022\TFE\ProjetMyCineBel - CopieV3 -swagger\MyCineBel.Client\Views\Film\_homePartial.cshtml"
           Write(Html.DisplayFor(modelItem => item.Film_Genre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 52 "C:\Users\JEAN\MonBureau\ephec2021-2022\TFE\ProjetMyCineBel - CopieV3 -swagger\MyCineBel.Client\Views\Film\_homePartial.cshtml"
           Write(Html.DisplayFor(modelItem => item.Film_duree));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 55 "C:\Users\JEAN\MonBureau\ephec2021-2022\TFE\ProjetMyCineBel - CopieV3 -swagger\MyCineBel.Client\Views\Film\_homePartial.cshtml"
           Write(Html.DisplayFor(modelItem => item.Film_BandeAnnonce));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 58 "C:\Users\JEAN\MonBureau\ephec2021-2022\TFE\ProjetMyCineBel - CopieV3 -swagger\MyCineBel.Client\Views\Film\_homePartial.cshtml"
           Write(Html.DisplayFor(modelItem => item.Film_DateSortie));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 61 "C:\Users\JEAN\MonBureau\ephec2021-2022\TFE\ProjetMyCineBel - CopieV3 -swagger\MyCineBel.Client\Views\Film\_homePartial.cshtml"
           Write(Html.DisplayFor(modelItem => item.Film_Synopsis));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 64 "C:\Users\JEAN\MonBureau\ephec2021-2022\TFE\ProjetMyCineBel - CopieV3 -swagger\MyCineBel.Client\Views\Film\_homePartial.cshtml"
           Write(Html.DisplayFor(modelItem => item.Film_Image));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 67 "C:\Users\JEAN\MonBureau\ephec2021-2022\TFE\ProjetMyCineBel - CopieV3 -swagger\MyCineBel.Client\Views\Film\_homePartial.cshtml"
           Write(Html.DisplayFor(modelItem => item.Film_Rea_Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 70 "C:\Users\JEAN\MonBureau\ephec2021-2022\TFE\ProjetMyCineBel - CopieV3 -swagger\MyCineBel.Client\Views\Film\_homePartial.cshtml"
           Write(Html.ActionLink("Edit", "Edit", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                ");
#nullable restore
#line 71 "C:\Users\JEAN\MonBureau\ephec2021-2022\TFE\ProjetMyCineBel - CopieV3 -swagger\MyCineBel.Client\Views\Film\_homePartial.cshtml"
           Write(Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                ");
#nullable restore
#line 72 "C:\Users\JEAN\MonBureau\ephec2021-2022\TFE\ProjetMyCineBel - CopieV3 -swagger\MyCineBel.Client\Views\Film\_homePartial.cshtml"
           Write(Html.ActionLink("Delete", "Delete", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 75 "C:\Users\JEAN\MonBureau\ephec2021-2022\TFE\ProjetMyCineBel - CopieV3 -swagger\MyCineBel.Client\Views\Film\_homePartial.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<MyCineBel.Client.Models.Film>> Html { get; private set; }
    }
}
#pragma warning restore 1591
