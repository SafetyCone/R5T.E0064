using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;


namespace R5T.E0064.W001.N004
{
    public class TableOfContentsOutlet : IComponent
    {
        #region Static

        private static RenderHandle RenderHandle { get; set; }

        public static TableOfContents TableOfContents { get; private set; } = new TableOfContents();


        public static void RenderTableOfContents()
        {
            TableOfContentsOutlet.RenderHandle.Dispatcher.InvokeAsync(
                () => TableOfContentsOutlet.RenderHandle.Render(
                    TableOfContentsOutlet.RenderTableOfContentsRenderFragment));

            //TableOfContentsOutlet.RenderHandle.Render(TableOfContentsOutlet.RenderTableOfContentsRenderFragment);
        }

        private static void RenderTableOfContentsRenderFragment(RenderTreeBuilder builder)
        {
            var renderFragments = TableOfContentsOutlet.TableOfContents.Nodes
                .Select(node => TableOfContentsOutlet.RenderTableOfContentsRenderFragment(node))
                .Now();

            builder.OpenComponent<TableOfContentsRoot>(0);
            builder.AddAttribute(1, nameof(TableOfContentsRoot.ChildRenderFragments), renderFragments);
            builder.CloseComponent();
        }

        private static RenderFragment RenderTableOfContentsRenderFragment(
            TableOfContentsNode node)
        {
            var isLeaf = node.ChildNodes.None();
            if (isLeaf)
            {
                return builder =>
                {
                    builder.OpenComponent<TableOfContentsItemLeaf>(0);
                    builder.AddAttribute(1, nameof(TableOfContentsItemLeaf.Node), node);
                    builder.CloseComponent();
                };
            }
            else
            {
                return builder =>
                {
                    var childRenderFragments = node.ChildNodes
                        .Select(childNode => TableOfContentsOutlet.RenderTableOfContentsRenderFragment(
                            childNode))
                        .ToArray();

                    builder.OpenComponent<TableOfContentsItemBranch>(0);
                    builder.AddAttribute(1, nameof(TableOfContentsItemBranch.Node), node);
                    builder.AddAttribute(2, nameof(TableOfContentsItemBranch.ChildRenderFragments), childRenderFragments);
                    builder.CloseComponent();
                };
            }
        }

        #endregion


        public void Attach(RenderHandle renderHandle)
        {
            TableOfContentsOutlet.RenderHandle = renderHandle;
        }

        public Task SetParametersAsync(ParameterView parameters)
        {
            // Do nothing.
            return Task.CompletedTask;
        }
    }
}
