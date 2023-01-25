using System;

using Microsoft.AspNetCore.Components;


namespace R5T.E0064.W001.N005.Internal
{
    public class HeadingBase : ComponentBase
    {
        [Parameter]
        public string Value { get; set; }

        public string Identity
        {
            get
            {
                var identity = HtmlIdentityOperator.Instance.GetHeadingIdentity(this.Value);
                return identity;
            }
        }

        /// <summary>
        /// Default is true.
        /// </summary>
        [Parameter]
        public bool IncludeInTableOfContents { get; set; } = true;
    }
}
