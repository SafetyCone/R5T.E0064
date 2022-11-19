using System;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;


namespace R5T.E0064.W001.N001
{
    public sealed class HeadOutlet : ComponentBase
    {
        public const string HeadSectionOutletName = "head";


        /// <inheritdoc/>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            // Render the rest of the head metadata
            builder.OpenComponent<SectionOutlet>(0);
            builder.AddAttribute(1, nameof(SectionOutlet.Name), HeadSectionOutletName);
            builder.CloseComponent();
        }
    }
}
