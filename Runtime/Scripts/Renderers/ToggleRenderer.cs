using System;
using TMPro;
using UnityEngine;

namespace KasaiFudo.DynamicPanels
{
    public class ToggleRenderer : FieldRenderer
    {
        [SerializeField] private UISwitcher _toggle;
        [SerializeField] private TMP_Text _label;

        public override void Bind(FieldSpec spec, IDataContext context, Action onValueChanged = null)
        {
            _label.text = spec.Label;
            _toggle.isOn = (bool)context.GetValue(spec.Id);

            _toggle.onValueChanged.AddListener(val =>
            {
                context.SetValue(spec.Id, val);
                onValueChanged?.Invoke();
            });
        }
    }
}
