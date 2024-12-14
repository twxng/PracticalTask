using Microsoft.AspNetCore.Razor.TagHelpers;

namespace PracticalTask.TagHelpers
{
    [HtmlTargetElement("card")]
    public class CardTagHelper : TagHelper
    {
        [HtmlAttributeName("header")]
        public string Header { get; set; }

        [HtmlAttributeName("footer")]
        public string Footer { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.SetAttribute("class", "card");

            var header = string.IsNullOrEmpty(Header) ? "" : 
                $"<div class=\"card-header\">{Header}</div>";
            
            var footer = string.IsNullOrEmpty(Footer) ? "" : 
                $"<div class=\"card-footer\">{Footer}</div>";

            output.PreContent.SetHtmlContent(header + "<div class=\"card-body\">");
            output.PostContent.SetHtmlContent("</div>" + footer);
        }
    }
} 