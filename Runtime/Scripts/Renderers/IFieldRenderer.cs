using System;

namespace KasaiFudo.DynamicPanels
{
    public interface IFieldRenderer
    {
        void Bind(FieldSpec spec, IDataContext context, Action onValueChanged = null);
    }
}