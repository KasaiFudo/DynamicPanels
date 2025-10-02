using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace KasaiFudo.DynamicPanels
{
    public class ToggleRenderer : FieldRenderer
    {
        [SerializeField] private UISwitcher _toggle;
        [SerializeField] private TMP_Text _label;
        [SerializeField] private Image _icon;

        public override void Bind(FieldSpec spec, IDataContext context, Action onValueChanged = null)
        {
            _label.text = spec.Label;
            _toggle.isOn = (bool)context.GetValue(spec.Id);
            
            if(_icon != null && spec.Icon != null)
                _icon.sprite = spec.Icon;

            _toggle.onValueChanged.AddListener(val =>
            {
                context.SetValue(spec.Id, val);
                onValueChanged?.Invoke();
            });
        }
    }
}
