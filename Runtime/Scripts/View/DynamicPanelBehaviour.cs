using System;
using System.Collections.Generic;
using UnityEngine;

namespace KasaiFudo.DynamicPanels
{
    public class DynamicPanelBehaviour : MonoBehaviour
    {
        [SerializeField] private Transform _container;
        [SerializeField] private SpecsData _specsData;
        [SerializeField] private RendererRegistry _registry;

        protected IDynamicPanel _dynamic;

        public virtual void Initialize()
        {
            var factory = CreateFactory();
            
            _dynamic = new DefaultDynamicPanel(_container, factory, _specsData);
        }

        public void Build(IDataContext context, List<FieldSpec> specs = null)
        {
            _dynamic.Build(context, specs);
        }

        protected virtual IUIElementFactory CreateFactory()
        {
            // Default implementation can be replaced in subclasses
            return new DefaultUIFactory(_registry);
        }
        
    }
}