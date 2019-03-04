#pragma checksum "I:\data\MyProjects\GitHub\dotnet-core-blockchain\BlockChain\BlockChain\Views\Home\CoinBase.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cf99d58ab99f95c8af45d6f4a09e5d8b650203ee"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_CoinBase), @"mvc.1.0.view", @"/Views/Home/CoinBase.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/CoinBase.cshtml", typeof(AspNetCore.Views_Home_CoinBase))]
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
#line 1 "I:\data\MyProjects\GitHub\dotnet-core-blockchain\BlockChain\BlockChain\Views\_ViewImports.cshtml"
using BlockChain;

#line default
#line hidden
#line 2 "I:\data\MyProjects\GitHub\dotnet-core-blockchain\BlockChain\BlockChain\Views\_ViewImports.cshtml"
using BlockChain.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cf99d58ab99f95c8af45d6f4a09e5d8b650203ee", @"/Views/Home/CoinBase.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f01fe8973a7ff96578a512b188a8ab2031f331b5", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_CoinBase : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-horizontal"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "I:\data\MyProjects\GitHub\dotnet-core-blockchain\BlockChain\BlockChain\Views\Home\CoinBase.cshtml"
  
    ViewData["Title"] = "CoinBase";
    Layout = null;

#line default
#line hidden
            BeginContext(66, 542, true);
            WriteLiteral(@"
<link rel=""stylesheet"" href=""/blockchain/stylesheets/lib/bootstrap.min.css""><link rel=""stylesheet"" href=""/blockchain/stylesheets/lib/bootstrap-theme.min.css""><link rel=""stylesheet"" href=""/blockchain/stylesheets/lib/bootstrap-horizon.css""><link rel=""stylesheet"" href=""/blockchain/stylesheets/lib/ladda-themeless.min.css""><link rel=""stylesheet"" href=""/blockchain/stylesheets/lib/ie10-viewport-bug-workaround.css""><link rel=""stylesheet"" href=""/blockchain/stylesheets/blockchain.css"">


<div class=""container-fluid"">
    <h2>CoinBase</h2>
");
            EndContext();
#line 12 "I:\data\MyProjects\GitHub\dotnet-core-blockchain\BlockChain\BlockChain\Views\Home\CoinBase.cshtml"
      
        var blocks = ViewBag.Blocks as List<Block>;
    

#line default
#line hidden
            BeginContext(676, 35, true);
            WriteLiteral("    <div class=\"row row-horizon\">\r\n");
            EndContext();
#line 16 "I:\data\MyProjects\GitHub\dotnet-core-blockchain\BlockChain\BlockChain\Views\Home\CoinBase.cshtml"
          
            int i = 1;
            int j = 1;
        

#line default
#line hidden
            BeginContext(782, 8, true);
            WriteLiteral("        ");
            EndContext();
#line 20 "I:\data\MyProjects\GitHub\dotnet-core-blockchain\BlockChain\BlockChain\Views\Home\CoinBase.cshtml"
         foreach (var block in blocks)
        {

#line default
#line hidden
            BeginContext(833, 133, true);
            WriteLiteral("        <div class=\"col-xs-7\" style=\"\">\r\n            <div id=\"block1chain1well\" class=\"well well-success\" style=\"\">\r\n                ");
            EndContext();
            BeginContext(966, 3098, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cf99d58ab99f95c8af45d6f4a09e5d8b650203ee5720", async() => {
                BeginContext(996, 403, true);
                WriteLiteral(@"
                    <div class=""form-group"">
                        <label for=""block1chain1number"" class=""col-sm-2 control-label"">Block:</label>
                        <div class=""col-sm-10"">
                            <div class=""input-group"">
                                <span class=""input-group-addon"">#</span>
                                <input id=""block1chain1number"" type=""text""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1399, "\"", 1409, 1);
#line 30 "I:\data\MyProjects\GitHub\dotnet-core-blockchain\BlockChain\BlockChain\Views\Home\CoinBase.cshtml"
WriteAttributeValue("", 1407, i, 1407, 2, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1410, 389, true);
                WriteLiteral(@" onkeyup=""updateChain(1, 1);"" class=""form-control"">
                            </div>
                        </div>
                    </div>
                    <div class=""form-group"">
                        <label for=""block1chain1nonce"" class=""col-sm-2 control-label"">Nonce:</label><div class=""col-sm-10"">
                            <input id=""block1chain1nonce"" type=""text""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1799, "\"", 1819, 1);
#line 36 "I:\data\MyProjects\GitHub\dotnet-core-blockchain\BlockChain\BlockChain\Views\Home\CoinBase.cshtml"
WriteAttributeValue("", 1807, block.Proof, 1807, 12, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1820, 261, true);
                WriteLiteral(@" onkeyup=""updateChain(1, 1);"" class=""form-control"">
                        </div>
                    </div><div class=""form-group"">
                        <label class=""col-sm-2 control-label"">Tx:</label>
                        <div class=""col-sm-10"">
");
                EndContext();
#line 41 "I:\data\MyProjects\GitHub\dotnet-core-blockchain\BlockChain\BlockChain\Views\Home\CoinBase.cshtml"
                             foreach (var item in block.Transactions)
                                {

#line default
#line hidden
                BeginContext(2187, 203, true);
                WriteLiteral("                            <div class=\"input-group\">\r\n                                <div class=\"input-group-addon\">$</div>\r\n                                <input id=\"block1chain1tx0value\" type=\"text\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2390, "\"", 2410, 1);
#line 45 "I:\data\MyProjects\GitHub\dotnet-core-blockchain\BlockChain\BlockChain\Views\Home\CoinBase.cshtml"
WriteAttributeValue("", 2398, item.Amount, 2398, 12, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2411, 170, true);
                WriteLiteral(" onkeyup=\"updateChain(1, 1);\" class=\"form-control\">\r\n                                <div class=\"input-group-addon\">From:</div><input id=\"block1chain1tx0from\" type=\"text\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2581, "\"", 2601, 1);
#line 46 "I:\data\MyProjects\GitHub\dotnet-core-blockchain\BlockChain\BlockChain\Views\Home\CoinBase.cshtml"
WriteAttributeValue("", 2589, item.Sender, 2589, 12, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2602, 168, true);
                WriteLiteral(" onkeyup=\"updateChain(1, 1);\" class=\"form-control\"><div class=\"input-group-addon\">-&gt;</div>\r\n                                <input id=\"block1chain1tx0to\" type=\"text\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2770, "\"", 2793, 1);
#line 47 "I:\data\MyProjects\GitHub\dotnet-core-blockchain\BlockChain\BlockChain\Views\Home\CoinBase.cshtml"
WriteAttributeValue("", 2778, item.Recipient, 2778, 15, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2794, 89, true);
                WriteLiteral(" onkeyup=\"updateChain(1, 1);\" class=\"form-control\">\r\n                            </div>\r\n");
                EndContext();
#line 49 "I:\data\MyProjects\GitHub\dotnet-core-blockchain\BlockChain\BlockChain\Views\Home\CoinBase.cshtml"
                                    j++;
                                }

#line default
#line hidden
                BeginContext(2960, 64, true);
                WriteLiteral("\r\n\r\n                        </div>\r\n                    </div>\r\n");
                EndContext();
                BeginContext(4041, 16, true);
                WriteLiteral("                ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4064, 42, true);
            WriteLiteral("\r\n\r\n            </div>\r\n\r\n        </div>\r\n");
            EndContext();
#line 70 "I:\data\MyProjects\GitHub\dotnet-core-blockchain\BlockChain\BlockChain\Views\Home\CoinBase.cshtml"
            i++;
        }

#line default
#line hidden
            BeginContext(4135, 24, true);
            WriteLiteral("\r\n\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
