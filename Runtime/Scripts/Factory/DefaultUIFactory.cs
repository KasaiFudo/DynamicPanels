using UnityEngine;

namespace KasaiFudo.DynamicPanels
{
    public class DefaultUIFactory : IUIElementFactory
    {
        private readonly RendererRegistry _registry;

        public DefaultUIFactory(RendererRegistry registry)
        {
            _registry = registry;
        }

        public IFieldRenderer CreateRenderer(string renderKey, Transform parent)
        {
            var prefab = _registry.GetRenderer(renderKey);
            
            return Object.Instantiate(prefab, parent);
        }
    }
}