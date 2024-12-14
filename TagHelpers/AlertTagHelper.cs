using Microsoft.AspNetCore.Razor.TagHelpers;

namespace PracticalTask.TagHelpers
{
    [HtmlTargetElement("alert")]
    public class AlertTagHelper : TagHelper
    {
        [HtmlAttributeName("type")]
        public string Type { get; set; } = "info";

        [HtmlAttributeName("dismissible")]
        public bool Dismissible { get; set; } = false;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            var cssClass = $"alert alert-{Type}";
            
            if (Dismissible)
            {
                cssClass += " alert-dismissible fade show";
                output.PostContent.AppendHtml(
                    "<button type=\"button\" class=\"btn-close\" " +
                    "data-bs-dismiss=\"alert\" aria-label=\"Close\"></button>");
            }
            
            output.Attributes.SetAttribute("class", cssClass);
            output.Attributes.SetAttribute("role", "alert");
        }
    }
} 