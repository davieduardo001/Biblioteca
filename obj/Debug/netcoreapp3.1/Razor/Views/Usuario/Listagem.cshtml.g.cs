#pragma checksum "/media/davi/Novo volume/senac/ucGitEDebug/atividade2/Biblioteca/Views/Usuario/Listagem.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "704eb7bad8638ac1fc22df1a550dbd195e3231dd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Usuario_Listagem), @"mvc.1.0.view", @"/Views/Usuario/Listagem.cshtml")]
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
#line 1 "/media/davi/Novo volume/senac/ucGitEDebug/atividade2/Biblioteca/Views/_ViewImports.cshtml"
using Biblioteca;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/media/davi/Novo volume/senac/ucGitEDebug/atividade2/Biblioteca/Views/_ViewImports.cshtml"
using Biblioteca.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"704eb7bad8638ac1fc22df1a550dbd195e3231dd", @"/Views/Usuario/Listagem.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8ea07f0214da259abc315dec5bc842518e8ae187", @"/Views/_ViewImports.cshtml")]
    public class Views_Usuario_Listagem : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Usuario>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "/media/davi/Novo volume/senac/ucGitEDebug/atividade2/Biblioteca/Views/Usuario/Listagem.cshtml"
  
    ViewData["Title"] = "Usuario Listagem";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""row"">
    <div class=""col-md-12"">
        <table class=""table table-striped""> 
            <thead>
                <tr>
                    <th>Id</th>
                    <th>Usuario</th>
                    <th></th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 19 "/media/davi/Novo volume/senac/ucGitEDebug/atividade2/Biblioteca/Views/Usuario/Listagem.cshtml"
                 foreach(Usuario u in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("               <tr>\n                   <td>");
#nullable restore
#line 22 "/media/davi/Novo volume/senac/ucGitEDebug/atividade2/Biblioteca/Views/Usuario/Listagem.cshtml"
                  Write(u.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                   <td>");
#nullable restore
#line 23 "/media/davi/Novo volume/senac/ucGitEDebug/atividade2/Biblioteca/Views/Usuario/Listagem.cshtml"
                  Write(u.Login);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                   <td><a");
            BeginWriteAttribute("href", " href=\"", 582, "\"", 610, 2);
            WriteAttributeValue("", 589, "/Usuario/Edicao/", 589, 16, true);
#nullable restore
#line 24 "/media/davi/Novo volume/senac/ucGitEDebug/atividade2/Biblioteca/Views/Usuario/Listagem.cshtml"
WriteAttributeValue("", 605, u.Id, 605, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Editar</a></td>\n                   <td><a");
            BeginWriteAttribute("href", " href=\"", 653, "\"", 683, 2);
            WriteAttributeValue("", 660, "/Usuario/Exclusao/", 660, 18, true);
#nullable restore
#line 25 "/media/davi/Novo volume/senac/ucGitEDebug/atividade2/Biblioteca/Views/Usuario/Listagem.cshtml"
WriteAttributeValue("", 678, u.Id, 678, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Excluir</a></td>\n               </tr>\n");
#nullable restore
#line 27 "/media/davi/Novo volume/senac/ucGitEDebug/atividade2/Biblioteca/Views/Usuario/Listagem.cshtml"
               }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\n        </table>\n    </div>\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Usuario>> Html { get; private set; }
    }
}
#pragma warning restore 1591
