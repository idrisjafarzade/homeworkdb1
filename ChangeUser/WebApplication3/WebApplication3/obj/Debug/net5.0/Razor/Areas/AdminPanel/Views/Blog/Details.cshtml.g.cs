#pragma checksum "C:\Users\PavilioN HP\Documents\Visual Code Repo\WebApplication3\WebApplication3\Areas\AdminPanel\Views\Blog\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5a972120e53ddfb8d111efe42dac82895a1689ba"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_AdminPanel_Views_Blog_Details), @"mvc.1.0.view", @"/Areas/AdminPanel/Views/Blog/Details.cshtml")]
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
#line 1 "C:\Users\PavilioN HP\Documents\Visual Code Repo\WebApplication3\WebApplication3\Areas\AdminPanel\Views\_ViewImports.cshtml"
using WebApplication3.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\PavilioN HP\Documents\Visual Code Repo\WebApplication3\WebApplication3\Areas\AdminPanel\Views\_ViewImports.cshtml"
using WebApplication3.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\PavilioN HP\Documents\Visual Code Repo\WebApplication3\WebApplication3\Areas\AdminPanel\Views\_ViewImports.cshtml"
using WebApplication3.Models.Home;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\PavilioN HP\Documents\Visual Code Repo\WebApplication3\WebApplication3\Areas\AdminPanel\Views\_ViewImports.cshtml"
using WebApplication3.Areas.AdminPanel.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5a972120e53ddfb8d111efe42dac82895a1689ba", @"/Areas/AdminPanel/Views/Blog/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1ee6cae487cbf87d71c1a156a125286760cfbf28", @"/Areas/AdminPanel/Views/_ViewImports.cshtml")]
    public class Areas_AdminPanel_Views_Blog_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BlogContent>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString(" width:50px; height:50px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\PavilioN HP\Documents\Visual Code Repo\WebApplication3\WebApplication3\Areas\AdminPanel\Views\Blog\Details.cshtml"
  
    ViewData["Title"] = "Details";
    

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""main-panel"">
  <div class=""content-wrapper"">
<div class=""row"">
<div class=""col-lg-12 grid-margin stretch-card"">
    <div class=""card"">
    <div class=""card-body"">
        <h4 class=""card-title"">Basic Table</h4>
        <div class=""table-responsive"">
        <table class=""table"">
            <thead>
            <tr>
                <th>Name</th>
                <th>Image</th>
                <th>Description</th>
                <th>Datetime</th>
            </tr>
            </thead>
            <tbody>
               <tr>
                <td>");
#nullable restore
#line 26 "C:\Users\PavilioN HP\Documents\Visual Code Repo\WebApplication3\WebApplication3\Areas\AdminPanel\Views\Blog\Details.cshtml"
               Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "5a972120e53ddfb8d111efe42dac82895a1689ba5338", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 732, "~/img/", 732, 6, true);
#nullable restore
#line 27 "C:\Users\PavilioN HP\Documents\Visual Code Repo\WebApplication3\WebApplication3\Areas\AdminPanel\Views\Blog\Details.cshtml"
AddHtmlAttributeValue("", 738, Model.ImgName, 738, 14, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 28 "C:\Users\PavilioN HP\Documents\Visual Code Repo\WebApplication3\WebApplication3\Areas\AdminPanel\Views\Blog\Details.cshtml"
               Write(Model.Text);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 29 "C:\Users\PavilioN HP\Documents\Visual Code Repo\WebApplication3\WebApplication3\Areas\AdminPanel\Views\Blog\Details.cshtml"
               Write(Model.dateTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n            </tbody>\r\n        </table>\r\n        </div>\r\n    </div>\r\n    </div>\r\n</div>\r\n</div>\r\n</div>\r\n</div>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BlogContent> Html { get; private set; }
    }
}
#pragma warning restore 1591
