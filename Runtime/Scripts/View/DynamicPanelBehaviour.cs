using System;
using System.Collections.Generic;
using UnityEngine;

namespace KasaiFudo.DynamicPanels
{
    public class DynamicPanelBehaviour : MonoBehaviour
    {
        [SerializeField] protected Transform _container;
        [SerializeField] protected SpecsData _specsData;
        [SerializeField] protected RendererRegistry _registry;

        protected IDynamicPanel _dynamic;
        protected bool _isInitialized = false;

        public virtual void Initialize()
        {
            if(_isInitialized)
                return;
            
            var factory = CreateFactory();
            
            _dynamic = new DefaultDynamicPanel(_container, factory, _specsData);
            
            _isInitialized = true;
        }

        public void Build(IDataContext context = null, List<FieldSpec> specs = null)
        {
            _dynamic.Build(specs, context);
        }

        protected virtual IUIElementFactory CreateFactory()
        {
            // Default implementation can be replaced in subclasses
            return new DefaultUIFactory(_registry);
        }
        
    }
}