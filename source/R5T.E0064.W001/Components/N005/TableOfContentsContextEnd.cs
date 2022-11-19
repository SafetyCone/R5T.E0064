using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;


namespace R5T.E0064.W001.N005.Internal
{
    public class TableOfContentsContextEnd : IComponent
    {
        [Inject]
        public NotificationService NotificationService { get; set; }

        [Parameter]
        public string NotificationChannelName { get; set; }


        public void Attach(RenderHandle renderHandle)
        {
            // Do nothing.
        }

        public Task SetParametersAsync(ParameterView parameters)
        {
            parameters.SetParameterProperties(this);

            var channel = this.NotificationService.ChannelsByName[this.NotificationChannelName];

            channel.Notify();

            return Task.CompletedTask;
        }
    }
}
