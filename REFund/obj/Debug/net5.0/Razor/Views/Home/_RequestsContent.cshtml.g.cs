#pragma checksum "C:\Users\tanyapornk.std\Desktop\REFund\REFund\REFund\Views\Home\_RequestsContent.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6462155fd3461a5ce1f50767748c293a392a9d3f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home__RequestsContent), @"mvc.1.0.view", @"/Views/Home/_RequestsContent.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6462155fd3461a5ce1f50767748c293a392a9d3f", @"/Views/Home/_RequestsContent.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"71ec165c6f0a0c3df2686d9b8ad97259cf7ba597", @"/Views/_ViewImports.cshtml")]
    public class Views_Home__RequestsContent : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div class=""row "">
    <div class=""row "">
        <div class=""col-1""></div>
        <div class=""col "" style=""left:5px;"">
            <p style=""margin-top: 40px; font-size: 20px; font-family: Inter; font-weight: 500; line-height: 0.5; text-align:center;"">แจ้งขอเบิกค่ารักษาพยาบาล</p>
            <p style=""font-size: 16px; font-family: Inter; font-weight: 400; line-height: 0.5; text-align: center;"">Medical and Dental Claim</p>
        </div>
        <div class=""col-2 "" style=""left:5px;"">
            <p style=""margin-top: 50px; font-size: 12px; font-family: Inter; font-weight: 300; line-height: 0.5; text-align:center;"">เลขที่ </p>
            <p style=""font-size: 12px; font-family: Inter; font-weight: 300; line-height: 0.5; text-align: center;"">No.</p>
        </div>
    </div>
    <div class=""row "" style=""left:5px;"">
        <div class=""col-1""></div>
        <div class=""col "" style=""left:5px;"">
            <p style=""margin-top: 30px; font-size: 12px;  font-weight: 500; line-height: 0.5; text-align");
            WriteLiteral(@":center;"">วันที่ <span id=""thaiDate"" style=""font-size: 12px;  font-weight: 500;""></span></p>
            <p style=""font-size: 12px;  font-weight: 500; line-height: 0.5; text-align: center;"">Date <span id=""englishDate"" style=""font-size: 12px; font-weight: 500;""></span></p>
        </div>
        <div class=""col-2 "" style=""left:5px;"">
            <p style=""margin-top: 30px; font-size: 12px; font-family: Inter; font-weight: 300; line-height: 0.5; text-align:center;"">อายุการทำงาน <span id=""experienceTH""></span></p>
            <p style=""font-size: 12px; font-family: Inter; font-weight: 300; line-height: 0.5; text-align: center;"">Experience <span id=""experienceEN""></span></p>
        </div>
    </div>
    <div class=""row "">
        <div class=""col-1""></div>
        <div style=""left:20px; width:150px;"">
            <p style=""margin-top: 40px; margin-left: 20px; font-size: 12px;  font-weight: 400; line-height: 0.5;"">รหัสพนักงาน :</p>
            <p style=""font-size: 12px; margin-left: 20px; font-weight: ");
            WriteLiteral(@"400; line-height: 0.5; "">Employee ID</p>
        </div>
        <div class=""col-1 "" style=""left:5px;"">
            <input type=""text"" name=""empID"" class="" form-control"" style=""margin-top: 40px; margin-left:-40px; background: #D9D9D9; border-radius: 0; width:170px; "" />

        </div>
        <div style=""left: 5px; width: 150px;"">
            <p style=""margin-top: 40px; margin-left: 70px; font-size: 12px;  font-weight: 400; line-height: 0.5;"">ชื่อ :</p>
            <p style=""font-size: 12px; margin-left: 70px; font-weight: 400; line-height: 0.5; "">Name</p>
        </div>
        <div class=""col-2 "" style=""left:30px;"">
            <input type=""text"" name=""name"" class="" form-control"" style=""margin-top: 40px; margin-left: -50px; background: #D9D9D9; border-radius: 0; width: 300px; "" />

        </div>
    </div>
    <div class=""row "">
        <div class=""col-1""></div>
        <div style=""left:20px; width:150px;"">
            <p style=""margin-top: 40px; margin-left: 20px; font-size: 12px;  font-");
            WriteLiteral(@"weight: 400; line-height: 0.5;"">วันที่เริ่มงาน :</p>
            <p style=""font-size: 12px; margin-left: 20px; font-weight: 400; line-height: 0.5; "">Start Date</p>
        </div>
        <div class=""col-1 "" style=""left:5px;"">
            <input type=""text"" name=""startDate"" class="" form-control"" style=""margin-top: 40px; margin-left:-40px; background: #D9D9D9; border-radius: 0; width:140px; "" />

        </div>
        <div style=""left: 5px; width: 150px;"">
            <p style=""margin-top: 40px; margin-left: 70px; font-size: 12px;  font-weight: 400; line-height: 0.5;"">ตำแหน่ง :</p>
            <p style=""font-size: 12px; margin-left: 70px; font-weight: 400; line-height: 0.5; "">Position</p>
        </div>
        <div class=""col-2 "" style=""left:30px;"">
            <input type=""text"" name=""position"" class="" form-control"" style=""margin-top: 40px; margin-left: -50px; background: #D9D9D9; border-radius: 0; width: 170px; "" />

        </div>
        <div style=""left: 5px; width: 150px;"">
            <");
            WriteLiteral(@"p style=""margin-top: 40px; margin-left: 30px; font-size: 12px;  font-weight: 400; line-height: 0.5;"">แผนก :</p>
            <p style=""font-size: 12px; margin-left: 30px; font-weight: 400; line-height: 0.5; "">Department</p>
        </div>
        <div class=""col-2 "" style=""left:30px;"">
            <input type=""text"" name=""department"" class="" form-control"" style=""margin-top: 40px; margin-left: -50px; background: #D9D9D9; border-radius: 0; width: 200px; "" />

        </div>
    </div>
    <div class=""row "">
        <div class=""col-1""></div>
        <div style=""left:20px; width:250px;"">
            <p style=""margin-top: 40px; margin-left: 20px; font-size: 12px; font-weight: 400; line-height: 0.5; color: #3383AF; text-decoration: underline;"">เลือกเรื่องที่ต้องการขอเบิกเงิน</p>
            <p style=""font-size: 12px; margin-left: 20px; font-weight: 400; line-height: 0.5; color: #3383AF; text-decoration: underline; "">Please select the title</p>
        </div>
    </div>
    <div class=""row "">
        ");
            WriteLiteral("<div class=\"col-1\"></div>\r\n        <div class=\"col-5\">\r\n            <select class=\"form-select\" id=\"Title\" style=\"margin-top: 5px; margin-left: 13px; width: 400px; \">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6462155fd3461a5ce1f50767748c293a392a9d3f8747", async() => {
                WriteLiteral("ขอเบิกค่ารักษาพยาบาล   Medical and Dental Claim");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6462155fd3461a5ce1f50767748c293a392a9d3f9762", async() => {
                WriteLiteral("พิธีฌาปนกิจศพ   The Death Of Family’s  Member");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6462155fd3461a5ce1f50767748c293a392a9d3f10775", async() => {
                WriteLiteral("พิธีสมรส  Marriage");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6462155fd3461a5ce1f50767748c293a392a9d3f11762", async() => {
                WriteLiteral("พิธีอุปสมบท Ordination");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6462155fd3461a5ce1f50767748c293a392a9d3f12753", async() => {
                WriteLiteral("คลอดบุตร  Childbirth");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6462155fd3461a5ce1f50767748c293a392a9d3f13742", async() => {
                WriteLiteral("สาธารณะภัย  Public Danger");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6462155fd3461a5ce1f50767748c293a392a9d3f14736", async() => {
                WriteLiteral("สาธารณะประโยชน์  Public Purpose");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6462155fd3461a5ce1f50767748c293a392a9d3f15736", async() => {
                WriteLiteral("กิจกรรมเพื่อสังคม  CSR Activity");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            </select>
        </div>
    </div>
    <div class=""row "">
        <div class=""col-1""></div>
        <div style=""left: 20px; width: 400px; margin-top: 10px; margin-left: 17px; "">
            <table class=""table table-bordered"">
                <tr>
                    <th style=""font-size: 12px; font-weight: 400;"">
                        สิทธิ์ที่ได้<br>
                        Quota
                    </th>
                    <th style=""font-size: 12px; font-weight: 400;"">
                        ใช้ไป<br>
                        Used
                    </th>
                    <th style=""font-size: 12px; font-weight: 400;"">
                        ยอดคงเหลือ<br>
                        Left
                    </th>
                </tr>
                <tr>
                    <td style=""font-size: 12px; font-weight: 400;"">xxxx บ.</td>
                    <td style=""font-size: 12px; font-weight: 400;"">xxxx บ.</td>
                    <td style=""font-size: 12px; fo");
            WriteLiteral(@"nt-weight: 400;"">xxxx บ.</td>
                </tr>
            </table>
        </div>
    </div>
    <div class=""row"">
        <div class=""col-1""></div>
        <div style=""left: 5px; width: 150px;"">
            <p style=""margin-top: 30px; margin-left: 30px; font-size: 12px;  font-weight: 400; line-height: 0.5;"">เป็นจำนวนเงิน :</p>
            <p style=""font-size: 12px; margin-left: 30px; font-weight: 400; line-height: 0.5; "">Amount</p>
        </div>
        <div style=""left: 30px; width: 120px;"">
            <input type=""text"" name=""Amount"" class="" form-control"" style=""margin-top: 30px; margin-left: -30px; background: #D9D9D9; border-radius: 0; width: 100px; "" />

        </div>
        <div style=""left: 1px; width: 50px;"">
            <p style=""margin-top: 30px; margin-left: -27px; font-size: 12px; font-weight: 400; line-height: 0.5;"">บาท</p>
            <p style=""font-size: 12px; margin-left: -27px; font-weight: 400; line-height: 0.5; "">Bath</p>
        </div>
        <div class=""col-");
            WriteLiteral(@"1""></div>
        <div class=""col-6"" style=""left: 30px; width: 50px;"">
            <p style=""margin-top: 30px; margin-left: -7px; font-size: 12px; font-weight: 400; line-height: 0.5;"">เป็นจำนวนเงินตัวอักษร&nbsp;&nbsp;<span id=""AmountTH""></span></p>
            <p style=""font-size: 12px; margin-left: -7px; font-weight: 400; line-height: 0.5; "">Amount in letter&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span id=""AmountEN""></span></p>
        </div>
    </div>
    <div class=""row"">
        <div class=""col-1""></div>
        <div style=""left: 5px; width: 130px;"">
            <p style=""margin-top: 30px; margin-left: 30px; font-size: 12px;  font-weight: 400; line-height: 0.5;"">รายละเอียด :</p>
            <p style=""font-size: 12px; margin-left: 30px; font-weight: 400; line-height: 0.5; "">Detail</p>
        </div>
        <div class=""col-4"" style=""left: 30px; "">
            <textarea class=""form-control"" id=""detail"" rows=""3"" style=""margin-top: 30px; margin-left: -30px;""></textarea>
        </");
            WriteLiteral(@"div>
    </div>
    <div class=""row"">
        <div class=""col-1""></div>
        <div style=""left: 5px; width: 300px;"">
            <p style=""margin-top: 30px; margin-left: 30px; font-size: 12px;  font-weight: 400; line-height: 0.5;"">เบิกให้ผู้ใด&nbsp; (To whom)</p>
        </div>
    </div>
    <div class=""row"">
        <div class=""col-1""></div>
        <div style=""left: 5px; width: 200px; margin-left: 50px;"">
            <input class=""form-check-input"" type=""radio"" name=""whom"" id=""whom_yourself"" value=""yourself"" onclick=""handleRadioClick(this)"">
            <label class=""form-check-label"" style=""font-size: 12px; font-weight: 400;"">&nbsp;1) ตนเอง (yourself)</label>
        </div>
        <div style=""left: 5px; width: 200px;"">
            <input class=""form-check-input"" type=""radio"" name=""whom"" id=""whom_offspring"" value=""offspring"" onclick=""handleRadioClick(this)"">
            <label class=""form-check-label"" style=""font-size: 12px; font-weight: 400;"">&nbsp;2) บุตร (offspring)</label>
        <");
            WriteLiteral(@"/div>
        <div style=""left: 5px; width: 200px;"">
            <input class=""form-check-input"" type=""radio"" name=""whom"" id=""whom_Spouse"" value=""Spouse"" onclick=""handleRadioClick(this)"">
            <label class=""form-check-label"" style=""font-size: 12px; font-weight: 400;"">&nbsp;3) คู่สมรส(Spouse)</label>
        </div>
        <div style=""left: 5px; width: 250px;"">
            <input class=""form-check-input"" type=""radio"" name=""whom"" id=""whom_Parent"" value=""Parent"" onclick=""handleRadioClick(this)"">
            <label class=""form-check-label"" style=""font-size: 12px; font-weight: 400;"">&nbsp;4) บิดา, มารดา (Father, Mother)</label>
        </div>
        <div style=""left: 5px; width: 300px;"">
            <!-- Dummy option to simulate unchecking -->
            <input class=""form-check-input"" type=""radio"" name=""whom"" id=""whom_none""");
            BeginWriteAttribute("value", " value=\"", 10882, "\"", 10890, 0);
            EndWriteAttribute();
            WriteLiteral(@" style=""display:none"">
        </div>
    </div>
    <div class=""row"">
        <div class=""col-1""></div>
        <div style=""left: 5px; width: 300px;"">
            <p style=""margin-top: 30px; margin-left: 30px; font-size: 12px;  font-weight: 400; line-height: 0.5;"">โดยมีเอกสารแนบ ดังนี้</p>
            <p style=""font-size: 12px; margin-left: 30px; font-weight: 400; line-height: 0.5; "">By attached below document</p>
        </div>
    </div>
    <div class=""row"">
        <div class=""col-1""></div>
        <div style=""left: 5px; width: 400px;"">
            <table class=""table table-bordered"" style=""font-size: 12px; margin-left: 30px; font-weight: 400; line-height: 0.5; "">
                <tr>
                    <td><input class=""form-check-input"" type=""checkbox""");
            BeginWriteAttribute("value", " value=\"", 11676, "\"", 11684, 0);
            EndWriteAttribute();
            WriteLiteral(@" style=""margin-left: -2px; margin-top: -7px; width: 20px; height: 20px; "" id=""defaultCheck1""></td>
                    <td><label class=""form-check-label"" for=""defaultCheck1"">1)ใบเสร็จ (Receipt)</label></td>
                </tr>
                <tr>
                    <td><input class=""form-check-input"" type=""checkbox""");
            BeginWriteAttribute("value", " value=\"", 12011, "\"", 12019, 0);
            EndWriteAttribute();
            WriteLiteral(@" style=""margin-left: -2px; margin-top: -7px; width: 20px; height: 20px; "" id=""defaultCheck1""></td>
                    <td><label class=""form-check-label"" for=""defaultCheck1"">2)ใบรับรองแพทย์  (Medical certificate) </label></td>
                <tr>
                    <td><input class=""form-check-input"" type=""checkbox""");
            BeginWriteAttribute("value", " value=\"", 12343, "\"", 12351, 0);
            EndWriteAttribute();
            WriteLiteral(@" style=""margin-left: -2px; margin-top: -7px; width: 20px; height: 20px; "" id=""defaultCheck1""></td>
                    <td><label class=""form-check-label"" for=""defaultCheck1"">3)ใบรับรองการเป็นบุตร  (child certificate)</label></td>
                </tr>
            </table>
        </div>
    </div>
    <div class=""row"">
        <div class=""col-1""></div>
        <div style=""left: 5px; width: 170px;"">
            <p style=""margin-top: 10px; margin-left: 30px; font-size: 12px;  font-weight: 400; line-height: 0.5;"">แนบไฟล์ </p>
            <p style=""font-size: 12px; margin-left: 30px; font-weight: 400; line-height: 0.5; "">Example file input</p>
        </div>
    </div>
    <div class=""row"">
        <div class=""col-1""></div>
        <div class=""col-4"" style=""left: 30px; "">
            <input type=""file"" class=""form-control-file"" id=""File1"" style=""margin-top: 5px; "">
        </div>
    </div>
    <div class=""row"">
        <div class=""col-9""></div>
        <div class=""col"">
            <button");
            WriteLiteral(@" type=""submit"" class=""btn mb-2"" style=""background-color: #3383AF; margin-top: 30px; margin-left: 50px; color: white; width: 150px; height: 50px; font-size: 20px; font-weight: 600; "">Submit</button>
        </div>
    </div>
</div>
    <script type=""text/javascript"">
        $(document).ready(function () {
            let today = new Date().toISOString().slice(0, 10);
            let [year, month, day] = today.split('-');
            let formattedDate = `${month}/${day}/${year}`;
            let AmountinLetter = ""(....................................................................................................................................)"";
            $(""#englishDate"").text(formattedDate);
            $(""#thaiDate"").text(formattedDate);
            $(""#AmountTH"").text(AmountinLetter);
            $(""#AmountEN"").text(AmountinLetter);
           
        });
        var previousRadio = null;

        function handleRadioClick(radio) {
            if (radio === previousRadio) {
       ");
            WriteLiteral(@"         // If the clicked radio is the same as the previous one, uncheck it
                radio.checked = false;
                previousRadio = null;
            } else {
                // Update the previousRadio variable and handle the click as usual
                previousRadio = radio;
            }
        }
        
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
