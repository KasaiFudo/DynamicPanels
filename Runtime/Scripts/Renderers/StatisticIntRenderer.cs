using System;
using TMPro;
using UnityEngine;

namespace KasaiFudo.DynamicPanels
{
    public class StatisticIntRenderer : FieldRenderer
    {
        [SerializeField] private TMP_Text _label;
        [SerializeField] private TMP_Text _value;
        public override void Bind(FieldSpec spec, IDataContext context, Action onValueChanged = null)
        {
            _label.text = spec.Label;
        
            _value.text = context.GetValue(spec.Id).ToString();
        }
    }
}
