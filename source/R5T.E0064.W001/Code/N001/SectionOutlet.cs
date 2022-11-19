using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;


namespace R5T.E0064.W001.N001
{
    public class SectionOutlet : IComponent, IDisposable
    {
        private static readonly RenderFragment EmptyRenderFragment = builder => { };

        private string _subscribedName;
        private SectionRegistry _registry;
        private Action<RenderFragment> _onChangeCallback;

        /// <summary>
        /// Gets or sets the name that determines which <see cref="SectionContent"/> instances will provide
        /// content to this instance.
        /// </summary>
        [Parameter] public string Name { get; set; } = default!;

        public void Attach(RenderHandle renderHandle)
        {
            _onChangeCallback = content =>
            {
                renderHandle.Render(content ?? EmptyRenderFragment);
            };
            _registry = SectionRegistry.GetRegistry(renderHandle);
        }

        public Task SetParametersAsync(ParameterView parameters)
        {
            var suppliedName = parameters.GetValueOrDefault<string>("Name");

            if (suppliedName != _subscribedName)
            {
                _registry.Unsubscribe(_subscribedName, _onChangeCallback);
                _registry.Subscribe(suppliedName, _onChangeCallback);
                _subscribedName = suppliedName;
            }

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _registry?.Unsubscribe(_subscribedName, _onChangeCallback);

            GC.SuppressFinalize(this);
        }
    }
}
