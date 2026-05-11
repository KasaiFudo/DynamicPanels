using UnityEngine;

namespace KasaiFudo.DynamicPanels
{
    public interface IUIElementFactory
    {
        IFieldRenderer CreateRenderer(string renderKey, Transform parent);
    }
}