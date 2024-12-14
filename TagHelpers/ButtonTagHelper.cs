using Microsoft.AspNetCore.Razor.TagHelpers;

namespace PracticalTask.TagHelpers
{
    [HtmlTargetElement("bs-button")]
    public class ButtonTagHelper : TagHelper
    {
        [HtmlAttributeName("type")]
        public string Type { get; set; } = "primary";

        [HtmlAttributeName("size")]
        public string Size { get; set; } = "";

        [HtmlAttributeName("outline")]
        public bool Outline { get; set; } = false;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "button";
            
            var btnClass = Outline ? $"btn btn-outline-{Type}" : $"btn btn-{Type}";
            
            if (!string.IsNullOrEmpty(Size))
            {
                btnClass += $" btn-{Size}";
            }
            
            output.Attributes.SetAttribute("class", btnClass);
            output.Attributes.SetAttribute("type", "button");
        }
    }
} 