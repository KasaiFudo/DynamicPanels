using System;
using System.Collections.Generic;

namespace KasaiFudo.DynamicPanels
{
    public interface IDynamicPanel
    {
        event Action OnValueChanged;
        
        void Build(IDataContext context, List<FieldSpec> specs = null);
    }
}