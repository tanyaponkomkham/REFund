#pragma checksum "C:\Users\tanyapornk.std\Desktop\REFund\REFund\REFund\Views\Request\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e4f8fad1554ce23895dc540c1b176b1e130b87c0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Request_Index), @"mvc.1.0.view", @"/Views/Request/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e4f8fad1554ce23895dc540c1b176b1e130b87c0", @"/Views/Request/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"71ec165c6f0a0c3df2686d9b8ad97259cf7ba597", @"/Views/_ViewImports.cshtml")]
    public class Views_Request_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<REFund.Models.Request>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\tanyapornk.std\Desktop\REFund\REFund\REFund\Views\Request\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"row\">\r\n");
            WriteLiteral(@"    <input id=""empID"" name=""empID"" type=""hidden"" "" />
    <label style=""font-size: 24px; margin-top: 50px; margin-left: 10px; font-weight: 700; line-height: 0.5; color: #3383AF; "">All Request</label>
    <div class=""col"" style="" margin-top: 10px;"">
        <table class=""table table-bordered"" id=""tblMyRequest"" style=""font-size: 12px; margin-top: 40px; font-weight: 400; line-height: 0.5; border-color: #3383AF;"">
            <thead>
                <tr>
                    <th style=""background-color: #3383AF; color: white; width: 13%;"">ID</th>
                    <th style=""background-color: #3383AF; color: white; width: 45%;"">Request</th>
                    <th style=""background-color: #3383AF; color: white; width: 15%; text-align: center;"">Employee</th>
                    <th style=""background-color: #3383AF; color: white; width: 15%; text-align: center;"">Date</th>
                    <th style=""background-color: #3383AF; color: white; width: 12%; text-align: center;"">Status</th>
                ");
            WriteLiteral("</tr>\r\n            </thead>\r\n            <tbody>\r\n");
#nullable restore
#line 23 "C:\Users\tanyapornk.std\Desktop\REFund\REFund\REFund\Views\Request\Index.cshtml"
                  foreach (var item in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                     <td style=\"text-align: center; vertical-align: middle; \">\r\n                                     <a");
            BeginWriteAttribute("href", " href=\"", 1547, "\"", 1579, 2);
            WriteAttributeValue("", 1554, "/Request/Edit?id=", 1554, 17, true);
#nullable restore
#line 27 "C:\Users\tanyapornk.std\Desktop\REFund\REFund\REFund\Views\Request\Index.cshtml"
WriteAttributeValue("", 1571, item.Id, 1571, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" target=\"_blank\">");
#nullable restore
#line 27 "C:\Users\tanyapornk.std\Desktop\REFund\REFund\REFund\Views\Request\Index.cshtml"
                                                                                    Write(item.RequestNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a> \r\n                                     </td>\r\n                                    <td style=\"vertical-align: middle; \">");
#nullable restore
#line 29 "C:\Users\tanyapornk.std\Desktop\REFund\REFund\REFund\Views\Request\Index.cshtml"
                                                                    Write(item.Category.CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td style=\"text-align: center; vertical-align: middle; \">");
#nullable restore
#line 30 "C:\Users\tanyapornk.std\Desktop\REFund\REFund\REFund\Views\Request\Index.cshtml"
                                                                                        Write(item.EmployeeId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td style=\"text-align: center; vertical-align: middle; \">");
#nullable restore
#line 31 "C:\Users\tanyapornk.std\Desktop\REFund\REFund\REFund\Views\Request\Index.cshtml"
                                                                                        Write(item.CreateAt);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td style=\"text-align: center; vertical-align: middle; \">\r\n                                        <label");
            BeginWriteAttribute("style", " style=\"", 2145, "\"", 2365, 20);
            WriteAttributeValue("", 2153, "background-color:", 2153, 17, true);
#nullable restore
#line 33 "C:\Users\tanyapornk.std\Desktop\REFund\REFund\REFund\Views\Request\Index.cshtml"
WriteAttributeValue(" ", 2170, item.Workflow.Status.BackgroundColor, 2171, 37, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2208, ";", 2208, 1, true);
            WriteAttributeValue(" ", 2209, "color:", 2210, 7, true);
#nullable restore
#line 33 "C:\Users\tanyapornk.std\Desktop\REFund\REFund\REFund\Views\Request\Index.cshtml"
WriteAttributeValue("", 2216, item.Workflow.Status.FontColor, 2216, 31, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2247, ";", 2247, 1, true);
            WriteAttributeValue(" ", 2248, "border-radius:", 2249, 15, true);
            WriteAttributeValue(" ", 2263, "8px;", 2264, 5, true);
            WriteAttributeValue(" ", 2268, "padding:", 2269, 9, true);
            WriteAttributeValue(" ", 2277, "6px", 2278, 4, true);
            WriteAttributeValue(" ", 2281, "6px;", 2282, 5, true);
            WriteAttributeValue(" ", 2286, "display:", 2287, 9, true);
            WriteAttributeValue(" ", 2295, "inline-flex;", 2296, 13, true);
            WriteAttributeValue(" ", 2308, "align-items:", 2309, 13, true);
            WriteAttributeValue(" ", 2321, "center;", 2322, 8, true);
            WriteAttributeValue(" ", 2329, "font-size:", 2330, 11, true);
            WriteAttributeValue(" ", 2340, "14px;", 2341, 6, true);
            WriteAttributeValue(" ", 2346, "font-weight:", 2347, 13, true);
            WriteAttributeValue(" ", 2359, "700;", 2360, 5, true);
            WriteAttributeValue(" ", 2364, "", 2365, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                            <label");
            BeginWriteAttribute("style", " style=\"", 2419, "\"", 2533, 11);
            WriteAttributeValue("", 2427, "background-color:", 2427, 17, true);
#nullable restore
#line 34 "C:\Users\tanyapornk.std\Desktop\REFund\REFund\REFund\Views\Request\Index.cshtml"
WriteAttributeValue(" ", 2444, item.Workflow.Status.FontColor, 2445, 31, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2476, ";", 2476, 1, true);
            WriteAttributeValue(" ", 2477, "border-radius:", 2478, 15, true);
            WriteAttributeValue(" ", 2492, "8px;", 2493, 5, true);
            WriteAttributeValue(" ", 2497, "padding:", 2498, 9, true);
            WriteAttributeValue(" ", 2506, "4px", 2507, 4, true);
            WriteAttributeValue(" ", 2510, "4px;", 2511, 5, true);
            WriteAttributeValue(" ", 2515, "margin-top:", 2516, 12, true);
            WriteAttributeValue(" ", 2527, "6px;", 2528, 5, true);
            WriteAttributeValue(" ", 2532, "", 2533, 1, true);
            EndWriteAttribute();
            WriteLiteral("></label>&nbsp;&nbsp;");
#nullable restore
#line 34 "C:\Users\tanyapornk.std\Desktop\REFund\REFund\REFund\Views\Request\Index.cshtml"
                                                                                                                                                                                     Write(item.Workflow.Status.StatusName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </label>\r\n                                    </td>\r\n                                </tr>\r\n");
#nullable restore
#line 38 "C:\Users\tanyapornk.std\Desktop\REFund\REFund\REFund\Views\Request\Index.cshtml"
                        }
                    

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                </tbody>
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
