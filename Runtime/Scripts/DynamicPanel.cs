using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace KasaiFudo.DynamicPanels
{
    public abstract class DynamicPanel : MonoBehaviour
    {
        [SerializeField] private Transform _container;
        [SerializeField] private RendererRegistry _registry;
        [SerializeField] protected SpecsData _specsData;

        /// <summary>
        /// Builds the dynamic panel UI by creating renderers for fields defined in the provided specifications
        /// and binding them to the specified data context.
        /// </summary>
        /// <param name="context">The data context used for binding the field renderers.</param>
        /// <param name="specs">Optional list of field specifications used for constructing the panel.
        /// If not provided, default specifications from the panel's SpecsData will be used.</param>
        protected void Build(IDataContext context, List<FieldSpec> specs = null)
        {
            foreach (Transform child in _container) Destroy(child.gameObject);

            foreach (var spec in specs ?? _specsData.Specs)
            {
                if (!IsVisible(spec, context)) continue;

                var prefab = _registry.GetRenderer(spec.Type); //Returns field renderer prefab
                var fieldRenderer = Instantiate(prefab, _container);
                fieldRenderer.Bind(spec, context, OnValueChanged);
            }
        }

        /// <summary>
        /// Called when any field value changes.
        /// </summary>
        protected virtual void OnValueChanged() {}

        private bool IsVisible(FieldSpec spec, IDataContext parameters)
        {
            return spec.VisibleIf == null || spec.VisibleIf.All(c => c.Evaluate(parameters));
        }
    }
}
