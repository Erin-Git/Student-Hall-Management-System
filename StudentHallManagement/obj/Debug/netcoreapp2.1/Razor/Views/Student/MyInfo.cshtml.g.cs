#pragma checksum "C:\Users\ERIN\Desktop\9th\System\StudentHallManagement\StudentHallManagement\Views\Student\MyInfo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "57472f381206b0cfec8498ee4ce01cc9fb84914f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Student_MyInfo), @"mvc.1.0.view", @"/Views/Student/MyInfo.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Student/MyInfo.cshtml", typeof(AspNetCore.Views_Student_MyInfo))]
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
#line 1 "C:\Users\ERIN\Desktop\9th\System\StudentHallManagement\StudentHallManagement\Views\_ViewImports.cshtml"
using StudentHallManagement;

#line default
#line hidden
#line 2 "C:\Users\ERIN\Desktop\9th\System\StudentHallManagement\StudentHallManagement\Views\_ViewImports.cshtml"
using StudentHallManagement.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"57472f381206b0cfec8498ee4ce01cc9fb84914f", @"/Views/Student/MyInfo.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ca87bc28b776b570619476c215b45728997132ff", @"/Views/_ViewImports.cshtml")]
    public class Views_Student_MyInfo : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<StudentHallManagement.ViewModels.StudentViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\ERIN\Desktop\9th\System\StudentHallManagement\StudentHallManagement\Views\Student\MyInfo.cshtml"
  
    ViewData["Title"] = "MyInfo";

#line default
#line hidden
            BeginContext(100, 460, true);
            WriteLiteral(@"
<style>
    #formdiv {
        background-color: #fff;
        padding: 30px;
        margin-top: 6%;
        border: 2px solid rebeccapurple;
        border-radius: 5px;
    }

    h2 {
        text-align: center;
    }

    hr {
        margin-bottom: 5%;
    }

    table {
        text-align: center;
    }

    th {
        text-align: center;
    }
</style>
<div class=""col-lg-6 col-lg-offset-3"" id=""formdiv"">

    <h2>About ");
            EndContext();
            BeginContext(561, 19, false);
#line 33 "C:\Users\ERIN\Desktop\9th\System\StudentHallManagement\StudentHallManagement\Views\Student\MyInfo.cshtml"
         Write(Model.studentnameVM);

#line default
#line hidden
            EndContext();
            BeginContext(580, 181, true);
            WriteLiteral("</h2>\r\n    <hr />\r\n    <table class=\"table table-bordered\">\r\n        <tbody>\r\n        <thead>\r\n           \r\n            <tr>\r\n                <td>Hall ID:</td>\r\n                <td>");
            EndContext();
            BeginContext(762, 21, false);
#line 41 "C:\Users\ERIN\Desktop\9th\System\StudentHallManagement\StudentHallManagement\Views\Student\MyInfo.cshtml"
               Write(Model.studenthallidVM);

#line default
#line hidden
            EndContext();
            BeginContext(783, 102, true);
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td>Department:</td>\r\n                <td>");
            EndContext();
            BeginContext(886, 18, false);
#line 45 "C:\Users\ERIN\Desktop\9th\System\StudentHallManagement\StudentHallManagement\Views\Student\MyInfo.cshtml"
               Write(Model.departmentVM);

#line default
#line hidden
            EndContext();
            BeginContext(904, 105, true);
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td>Date of Birth:</td>\r\n                <td>");
            EndContext();
            BeginContext(1010, 12, false);
#line 49 "C:\Users\ERIN\Desktop\9th\System\StudentHallManagement\StudentHallManagement\Views\Student\MyInfo.cshtml"
               Write(Model.dobdVM);

#line default
#line hidden
            EndContext();
            BeginContext(1022, 107, true);
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td>Contact No:</td>\r\n                <td>+880 ");
            EndContext();
            BeginContext(1130, 17, false);
#line 53 "C:\Users\ERIN\Desktop\9th\System\StudentHallManagement\StudentHallManagement\Views\Student\MyInfo.cshtml"
                    Write(Model.contactnoVM);

#line default
#line hidden
            EndContext();
            BeginContext(1147, 106, true);
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td>Admission Date:</td>\r\n                <td>");
            EndContext();
            BeginContext(1254, 10, false);
#line 57 "C:\Users\ERIN\Desktop\9th\System\StudentHallManagement\StudentHallManagement\Views\Student\MyInfo.cshtml"
               Write(Model.adVM);

#line default
#line hidden
            EndContext();
            BeginContext(1264, 86, true);
            WriteLiteral("</td>\r\n            </tr>\r\n        </thead>\r\n        </tbody>\r\n    </table>\r\n</div>\r\n\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<StudentHallManagement.ViewModels.StudentViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
