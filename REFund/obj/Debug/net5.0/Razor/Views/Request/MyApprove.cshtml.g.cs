#pragma checksum "C:\Users\tanyapornk.std\Desktop\REFund\REFund\REFund\Views\Request\MyApprove.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "83a8534990279328616aec6b97344ff6574b277b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Request_MyApprove), @"mvc.1.0.view", @"/Views/Request/MyApprove.cshtml")]
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
#line 1 "C:\Users\tanyapornk.std\Desktop\REFund\REFund\REFund\Views\_ViewImports.cshtml"
using REFund;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\tanyapornk.std\Desktop\REFund\REFund\REFund\Views\_ViewImports.cshtml"
using REFund.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"83a8534990279328616aec6b97344ff6574b277b", @"/Views/Request/MyApprove.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"71ec165c6f0a0c3df2686d9b8ad97259cf7ba597", @"/Views/_ViewImports.cshtml")]
    public class Views_Request_MyApprove : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<REFund.Models.Request>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\tanyapornk.std\Desktop\REFund\REFund\REFund\Views\Request\MyApprove.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"row\">\r\n");
            WriteLiteral(@"    <input id=""empID"" name=""empID"" type=""hidden""  />
    <label style=""font-size: 24px; margin-top: 50px; margin-left: 10px; font-weight: 700; line-height: 0.5; color: #3383AF; "">My Approve</label>
    <div class=""col"" style="" margin-top: 10px;"">
        <table class=""table table-bordered"" id=""tblMyRequest"" style=""font-size: 12px; margin-top: 40px; font-weight: 400; line-height: 0.5; border-color: #3383AF;"">
            <thead>
                <tr>
                    <th style=""background-color: #3383AF; color: white; width: 13%;"">ID</th>
                    <th style=""background-color: #3383AF; color: white; width: 40%;"">Request</th>
                    <th style=""background-color: #3383AF; color: white; width: 15%; text-align: center;"">Employee</th>
                    <th style=""background-color: #3383AF; color: white; width: 15%; text-align: center;"">Date</th>
                    <th style=""background-color: #3383AF; color: white; width: 25%; text-align: center;"">Status</th>
                </");
            WriteLiteral("tr>\r\n            </thead>\r\n            <tbody>\r\n");
#nullable restore
#line 23 "C:\Users\tanyapornk.std\Desktop\REFund\REFund\REFund\Views\Request\MyApprove.cshtml"
                  foreach (var item in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td style=\"text-align: center; vertical-align: middle; \">\r\n                                <a");
            BeginWriteAttribute("href", " href=\"", 1523, "\"", 1555, 2);
            WriteAttributeValue("", 1530, "/Request/Edit?id=", 1530, 17, true);
#nullable restore
#line 27 "C:\Users\tanyapornk.std\Desktop\REFund\REFund\REFund\Views\Request\MyApprove.cshtml"
WriteAttributeValue("", 1547, item.Id, 1547, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" target=\"_blank\">");
#nullable restore
#line 27 "C:\Users\tanyapornk.std\Desktop\REFund\REFund\REFund\Views\Request\MyApprove.cshtml"
                                                                               Write(item.RequestNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                            </td>\r\n                            <td style=\"vertical-align: middle; \">");
#nullable restore
#line 29 "C:\Users\tanyapornk.std\Desktop\REFund\REFund\REFund\Views\Request\MyApprove.cshtml"
                                                            Write(item.Category.CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td style=\"text-align: center; vertical-align: middle; \">");
#nullable restore
#line 30 "C:\Users\tanyapornk.std\Desktop\REFund\REFund\REFund\Views\Request\MyApprove.cshtml"
                                                                                Write(item.EmployeeId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td style=\"text-align: center; vertical-align: middle; \">");
#nullable restore
#line 31 "C:\Users\tanyapornk.std\Desktop\REFund\REFund\REFund\Views\Request\MyApprove.cshtml"
                                                                                Write(item.CreateAt);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td style=\"text-align: center; vertical-align: middle; \">\r\n                                <label");
            BeginWriteAttribute("style", " style=\"", 2071, "\"", 2291, 20);
            WriteAttributeValue("", 2079, "background-color:", 2079, 17, true);
#nullable restore
#line 33 "C:\Users\tanyapornk.std\Desktop\REFund\REFund\REFund\Views\Request\MyApprove.cshtml"
WriteAttributeValue(" ", 2096, item.Workflow.Status.BackgroundColor, 2097, 37, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2134, ";", 2134, 1, true);
            WriteAttributeValue(" ", 2135, "color:", 2136, 7, true);
#nullable restore
#line 33 "C:\Users\tanyapornk.std\Desktop\REFund\REFund\REFund\Views\Request\MyApprove.cshtml"
WriteAttributeValue("", 2142, item.Workflow.Status.FontColor, 2142, 31, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2173, ";", 2173, 1, true);
            WriteAttributeValue(" ", 2174, "border-radius:", 2175, 15, true);
            WriteAttributeValue(" ", 2189, "8px;", 2190, 5, true);
            WriteAttributeValue(" ", 2194, "padding:", 2195, 9, true);
            WriteAttributeValue(" ", 2203, "6px", 2204, 4, true);
            WriteAttributeValue(" ", 2207, "6px;", 2208, 5, true);
            WriteAttributeValue(" ", 2212, "display:", 2213, 9, true);
            WriteAttributeValue(" ", 2221, "inline-flex;", 2222, 13, true);
            WriteAttributeValue(" ", 2234, "align-items:", 2235, 13, true);
            WriteAttributeValue(" ", 2247, "center;", 2248, 8, true);
            WriteAttributeValue(" ", 2255, "font-size:", 2256, 11, true);
            WriteAttributeValue(" ", 2266, "14px;", 2267, 6, true);
            WriteAttributeValue(" ", 2272, "font-weight:", 2273, 13, true);
            WriteAttributeValue(" ", 2285, "700;", 2286, 5, true);
            WriteAttributeValue(" ", 2290, "", 2291, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                    <label");
            BeginWriteAttribute("style", " style=\"", 2337, "\"", 2451, 11);
            WriteAttributeValue("", 2345, "background-color:", 2345, 17, true);
#nullable restore
#line 34 "C:\Users\tanyapornk.std\Desktop\REFund\REFund\REFund\Views\Request\MyApprove.cshtml"
WriteAttributeValue(" ", 2362, item.Workflow.Status.FontColor, 2363, 31, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2394, ";", 2394, 1, true);
            WriteAttributeValue(" ", 2395, "border-radius:", 2396, 15, true);
            WriteAttributeValue(" ", 2410, "8px;", 2411, 5, true);
            WriteAttributeValue(" ", 2415, "padding:", 2416, 9, true);
            WriteAttributeValue(" ", 2424, "4px", 2425, 4, true);
            WriteAttributeValue(" ", 2428, "4px;", 2429, 5, true);
            WriteAttributeValue(" ", 2433, "margin-top:", 2434, 12, true);
            WriteAttributeValue(" ", 2445, "6px;", 2446, 5, true);
            WriteAttributeValue(" ", 2450, "", 2451, 1, true);
            EndWriteAttribute();
            WriteLiteral("></label>&nbsp;&nbsp;");
#nullable restore
#line 34 "C:\Users\tanyapornk.std\Desktop\REFund\REFund\REFund\Views\Request\MyApprove.cshtml"
                                                                                                                                                                             Write(item.Workflow.Status.StatusName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </label>\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 38 "C:\Users\tanyapornk.std\Desktop\REFund\REFund\REFund\Views\Request\MyApprove.cshtml"
                    }
                

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            </tbody>
        </table>
    </div>
</div>
<script type=""text/javascript"">
        $(document).ready(function () {
            $('#tblMyRequest').dataTable({
                ""pageLength"": 10,
                ""lengthMenu"": [10, 20, 50, 75, 100], // ตัวเลือกใน Show entries
                ""lengthChange"": true // แสดง dropdown เลือกจำนวน entries
            });


        });

    /* sidebar */
    const body = document.querySelector('body');
    const sidebar = document.getElementById(""navtag"");
    const toggle = body.querySelector("".toggle"");

    toggle.addEventListener(""click"", () => {
        console.log(""Toggle button clicked!"");
        toggle.classList.toggle('rotate');
        sidebar.classList.toggle(""close"");
    });


</script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<REFund.Models.Request>> Html { get; private set; }
    }
}
#pragma warning restore 1591
