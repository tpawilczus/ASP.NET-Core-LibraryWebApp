using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWebApp.TagHelpers
{
    [HtmlTargetElement("sub", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class CounterHelper : TagHelper
    {
        [HtmlAttributeName("AllBooks")]
        public double a { get; set; }

        [HtmlAttributeName("BorrowedBooks")]
        public double b { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "";
            output.Content.SetHtmlContent((a - b).ToString());
        }
    }
}
