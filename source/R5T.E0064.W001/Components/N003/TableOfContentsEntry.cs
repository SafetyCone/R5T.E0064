using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;

using R5T.E0064.W001.N001;


namespace R5T.E0064.W001.N003
{
    public class TableOfContentsEntry : IComponent
    {
        //private SectionRegistry Registry { get; set; }


        [Parameter]
        public string HeadingIdentity { get; set; }
        [Parameter]
        public int HeadingLevel { get; set; }


        public void Attach(RenderHandle renderHandle)
        {
            //this.Registry = SectionRegistry.GetRegistry(renderHandle);
        }

        public Task SetParametersAsync(ParameterView parameters)
        {
            parameters.SetParameterProperties(this);

            //this.Registry.SetContent("table-of-contents" ChildContent);

            return Task.CompletedTask;
        }
    }
}
