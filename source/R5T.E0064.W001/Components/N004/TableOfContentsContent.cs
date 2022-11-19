using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;


namespace R5T.E0064.W001.N004
{
    public class TableOfContentsContent : IComponent
    {
        /// <summary>
        /// The "HowToSeeMetaTags" in &lt;a href="#HowToSeeMetaTags" &gt;...
        /// </summary>
        [Parameter]
        public string Identity { get; set; }

        /// <summary>
        /// The "How to see Meta tags" in &lt;a&gt;How to see meta tags&lt;/a&gt;
        /// </summary>
        [Parameter]
        public string Text { get; set; }

        /// <summary>
        /// Goes from 1 (h1) to 6 (h6).
        /// </summary>
        [Parameter]
        public int Level { get; set; }


        public void Attach(RenderHandle renderHandle)
        {
            // Do nothing.
        }

        public Task SetParametersAsync(ParameterView parameters)
        {
            parameters.SetParameterProperties(this);

            // Add table of contents node.
            var node = new TableOfContentsNode
            {
                Identity = this.Identity,
                Text = this.Text,
                Level = this.Level,
            };

            TableOfContentsOutlet.TableOfContents.AddNode(node);

            return Task.CompletedTask;
        }
    }
}
