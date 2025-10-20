using UnityEngine;

namespace KasaiFudo.DynamicPanels
{
    public sealed class DefaultDynamicPanel : DynamicPanel
    {
        public DefaultDynamicPanel(Transform container, IUIElementFactory factory, SpecsData specsData)
            : base(container, factory, specsData)
        {
        }
    }
}