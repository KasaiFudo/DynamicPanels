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

        public IFieldRenderer CreateRenderer(FieldType type, Transform parent)
        {
            var prefab = _registry.GetRenderer(type);
            
            return Object.Instantiate(prefab, parent);
        }
    }
}