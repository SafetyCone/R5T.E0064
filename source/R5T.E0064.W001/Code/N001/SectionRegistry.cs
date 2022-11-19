using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

using Microsoft.AspNetCore.Components;


namespace R5T.E0064.W001.N001
{
    internal class SectionRegistry
    {
        private static readonly ConditionalWeakTable<Dispatcher, SectionRegistry> _registries = new();

        private readonly Dictionary<string, List<Action<RenderFragment>>> _subscriptions = new();

        public static SectionRegistry GetRegistry(RenderHandle renderHandle)
        {
            return _registries.GetOrCreateValue(renderHandle.Dispatcher);
        }

        public void Subscribe(string name, Action<RenderFragment> callback)
        {
            if (!_subscriptions.TryGetValue(name, out var existingList))
            {
                existingList = new List<Action<RenderFragment>>();
                _subscriptions.Add(name, existingList);
            }

            existingList.Add(callback);
        }

        public void Unsubscribe(string name, Action<RenderFragment> callback)
        {
            if (name != null && _subscriptions.TryGetValue(name, out var existingList))
            {
                existingList.Remove(callback);
            }
        }

        public void SetContent(string name, RenderFragment content)
        {
            if (_subscriptions.TryGetValue(name, out var existingList))
            {
                foreach (var callback in existingList)
                {
                    callback(content);
                }
            }
        }
    }
}
