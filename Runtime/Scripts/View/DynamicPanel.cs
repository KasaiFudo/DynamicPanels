using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace KasaiFudo.DynamicPanels
{
    public abstract class DynamicPanel : IDynamicPanel
    {
        protected readonly Transform _container;
        protected readonly IUIElementFactory _factory;
        protected readonly SpecsData _specsData;

        public event Action OnValueChanged;

        protected DynamicPanel(Transform container, IUIElementFactory factory, SpecsData specsData)
        {
            _container = container;
            _factory = factory;
            _specsData = specsData;
        }

        /// <summary>
        /// Builds the dynamic panel UI by creating renderers for fields defined in the provided specifications
        /// and binding them to the specified data context.
        /// </summary>
        /// <param name="context">The data context used for binding the field renderers.</param>
        /// <param name="specs">Optional list of field specifications used for constructing the panel.
        /// If not provided, default specifications from the panel's SpecsData will be used.</param>
        public void Build(IDataContext context, List<FieldSpec> specs = null)
        {
            if (_container == null)
                throw new System.NullReferenceException("DynamicPanel: Container is null.");

            foreach (Transform child in _container)
                Object.Destroy(child.gameObject);

            foreach (var spec in specs ?? _specsData.Specs)
            {
                if (!IsVisible(spec, context)) continue;

                var fieldRenderer = _factory.CreateRenderer(spec.Type, _container);
                fieldRenderer.Bind(spec, context, OnValueChanged);
            }
        }

        private bool IsVisible(FieldSpec spec, IDataContext parameters)
        {
            return spec.VisibleIf == null || spec.VisibleIf.All(c => c.Evaluate(parameters));
        }
    }
}
