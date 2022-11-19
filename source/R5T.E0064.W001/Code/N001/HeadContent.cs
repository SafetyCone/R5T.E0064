using System;

using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components;


namespace R5T.E0064.W001.N001
{
    public sealed class HeadContent : ComponentBase
    {
        /// <summary>
        /// Gets or sets the content to be rendered in <see cref="HeadOutlet"/> instances.
        /// </summary>
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        /// <inheritdoc/>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenComponent<SectionContent>(0);
            builder.AddAttribute(1, nameof(SectionContent.Name), HeadOutlet.HeadSectionOutletName);
            builder.AddAttribute(2, nameof(SectionContent.ChildContent), ChildContent);
            builder.CloseComponent();
        }
    }
}
