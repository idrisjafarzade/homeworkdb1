#pragma checksum "C:\Users\PavilioN HP\Documents\Visual Code Repo\FirstHomework\FirstHomework\Views\Home\Type.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cf820ca5ee43bb340a938cc9d970bfbae281a2c6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Type), @"mvc.1.0.view", @"/Views/Home/Type.cshtml")]
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
#line 1 "C:\Users\PavilioN HP\Documents\Visual Code Repo\FirstHomework\FirstHomework\Views\_ViewImports.cshtml"
using FirstHomework.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cf820ca5ee43bb340a938cc9d970bfbae281a2c6", @"/Views/Home/Type.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"084b4ceb125ff80ae76386fc5b93552cd2d4ba50", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Type : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\PavilioN HP\Documents\Visual Code Repo\FirstHomework\FirstHomework\Views\Home\Type.cshtml"
  
    ViewData["Title"] = "Type";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Type</h1>\r\n\r\n<ul>\r\n");
#nullable restore
#line 9 "C:\Users\PavilioN HP\Documents\Visual Code Repo\FirstHomework\FirstHomework\Views\Home\Type.cshtml"
     foreach (var item in Model.Types)
   {

#line default
#line hidden
#nullable disable
            WriteLiteral("       <li>\r\n           ");
#nullable restore
#line 12 "C:\Users\PavilioN HP\Documents\Visual Code Repo\FirstHomework\FirstHomework\Views\Home\Type.cshtml"
      Write(item);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n       </li>\r\n");
#nullable restore
#line 14 "C:\Users\PavilioN HP\Documents\Visual Code Repo\FirstHomework\FirstHomework\Views\Home\Type.cshtml"
   }

#line default
#line hidden
#nullable disable
            WriteLiteral("</ul>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
