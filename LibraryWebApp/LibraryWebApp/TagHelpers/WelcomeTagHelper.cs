using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWebApp.TagHelpers
{
        [HtmlTargetElement("welcome-tag-helper")]
        public class WelcomeTagHelper : TagHelper
        {
            public string Name { get; set; }
            public override void Process(TagHelperContext context, TagHelperOutput output)
            {
                output.TagName = "WelcomeTagHelper";
                output.TagMode = TagMode.StartTagAndEndTag;

                var sb = new StringBuilder();
                var b = this.Name.IndexOf("@");
                string c = this.Name.Substring(0, b);

                    
            sb.AppendFormat("<span>Hello {0}!</span>", c);

                output.PreContent.SetHtmlContent(sb.ToString());
            }
        }
}
