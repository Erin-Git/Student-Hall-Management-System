#pragma checksum "C:\Users\ERIN\Desktop\9th\System\StudentHallManagement\StudentHallManagement\Views\Student\MyMealActivity.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "effa528b8c7f1820989424b3eff6a31010374004"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Student_MyMealActivity), @"mvc.1.0.view", @"/Views/Student/MyMealActivity.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Student/MyMealActivity.cshtml", typeof(AspNetCore.Views_Student_MyMealActivity))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"effa528b8c7f1820989424b3eff6a31010374004", @"/Views/Student/MyMealActivity.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ca87bc28b776b570619476c215b45728997132ff", @"/Views/_ViewImports.cshtml")]
    public class Views_Student_MyMealActivity : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<StudentHallManagement.ViewModels.MealDistributionViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\ERIN\Desktop\9th\System\StudentHallManagement\StudentHallManagement\Views\Student\MyMealActivity.cshtml"
  
    ViewData["Title"] = "MyMealActivity";

#line default
#line hidden
            BeginContext(117, 454, true);
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

    <h2>");
            EndContext();
            BeginContext(572, 19, false);
#line 33 "C:\Users\ERIN\Desktop\9th\System\StudentHallManagement\StudentHallManagement\Views\Student\MyMealActivity.cshtml"
   Write(Model.studentnameVM);

#line default
#line hidden
            EndContext();
            BeginContext(591, 186, true);
            WriteLiteral("\'s Meal Activity</h2>\r\n    <hr />\r\n    <table class=\"table table-bordered\">\r\n        <tbody>\r\n        <thead>\r\n\r\n            <tr>\r\n                <td>Hall ID:</td>\r\n                <td>");
            EndContext();
            BeginContext(778, 21, false);
#line 41 "C:\Users\ERIN\Desktop\9th\System\StudentHallManagement\StudentHallManagement\Views\Student\MyMealActivity.cshtml"
               Write(Model.studenthallidVM);

#line default
#line hidden
            EndContext();
            BeginContext(799, 102, true);
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td>Total Meal:</td>\r\n                <td>");
            EndContext();
            BeginContext(902, 10, false);
#line 45 "C:\Users\ERIN\Desktop\9th\System\StudentHallManagement\StudentHallManagement\Views\Student\MyMealActivity.cshtml"
               Write(Model.meal);

#line default
#line hidden
            EndContext();
            BeginContext(912, 101, true);
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td>My Status:</td>\r\n                <td>");
            EndContext();
            BeginContext(1014, 13, false);
#line 49 "C:\Users\ERIN\Desktop\9th\System\StudentHallManagement\StudentHallManagement\Views\Student\MyMealActivity.cshtml"
               Write(Model.status2);

#line default
#line hidden
            EndContext();
            BeginContext(1027, 87, true);
            WriteLiteral("%</td>\r\n            </tr>\r\n        </thead>\r\n        </tbody>\r\n    </table>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<StudentHallManagement.ViewModels.MealDistributionViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
