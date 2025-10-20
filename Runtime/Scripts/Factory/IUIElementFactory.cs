using UnityEngine;

namespace KasaiFudo.DynamicPanels
{
    public interface IUIElementFactory
    {
        IFieldRenderer CreateRenderer(FieldType type, Transform parent);
    }
}