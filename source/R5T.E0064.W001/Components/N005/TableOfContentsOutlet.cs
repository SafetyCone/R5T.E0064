﻿using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;

using System.Extensions;

using R5T.E0064.W001.N006;


namespace R5T.E0064.W001.N005.Internal
{
    public class TableOfContentsOutlet : IComponent
    {
        private RenderHandle RenderHandle { get; set; }
        private EventNofifier FinishedEventNotifier { get; } = new EventNofifier();

        [Inject]
        private NotificationService NotificationService { get; set; }

        [CascadingParameter(Name = "NodeTree")]
        public TableOfContentsNodeTree NodeTree { get; set; }

        [Parameter]
        public string NotificationChannelName { get; set; }


        public TableOfContentsOutlet()
        {
            this.FinishedEventNotifier.NotificationHandler += FinishedEventNotifier_NotificationHandler;
        }

        public void Attach(RenderHandle renderHandle)
        {
            this.RenderHandle = renderHandle;
        }

        public Task SetParametersAsync(ParameterView parameters)
        {
            Console.WriteLine("Called how many times?");

            parameters.SetParameterProperties(this);

            // The set parameters method might be called multiple times (for example, when changing the component and reloading, to detect differences).
            // This is ok, since the channel name should be unique to the table of contents.
            this.NotificationService.ChannelsByName.AddOrReplaceValue(
                this.NotificationChannelName,
                this.FinishedEventNotifier);

            return Task.CompletedTask;
        }

        private void FinishedEventNotifier_NotificationHandler(object sender, EventArgs e)
        {
            TableOfContentsNodeOperations.Instance.RenderTableOfContents(
                this.RenderHandle,
                this.NodeTree);

            NotificationService.ChannelsByName.Remove(this.NotificationChannelName);
        }
    }
}
