using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;


namespace R5T.E0064.W001.N004
{
    public class TableOfContentsEnd : IComponent
    {
        public void Attach(RenderHandle renderHandle)
        {
            TableOfContentsOutlet.RenderTableOfContents();
        }

        public Task SetParametersAsync(ParameterView parameters)
        {
            // Do nothing.
            return Task.CompletedTask;
        }
    }
}
