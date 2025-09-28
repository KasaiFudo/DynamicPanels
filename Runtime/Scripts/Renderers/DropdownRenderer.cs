using System;
using System.Linq;
using TMPro;
using UnityEngine;

namespace KasaiFudo.DynamicPanels
{
    public class DropdownRenderer : FieldRenderer
    {
        [SerializeField] private TMP_Dropdown _dropdown;
        [SerializeField] private TMP_Text _label;
        private string[] _options;
        
        public override void Bind(FieldSpec spec, IDataContext context, Action onValueChanged = null)
        {
            _options = spec.Options;

            _label.text = spec.Label;
            _dropdown.ClearOptions();
            _dropdown.AddOptions(_options.ToList());
            
            var currentString = context.GetValue(spec.Id)?.ToString();
            var index = Array.IndexOf(_options, currentString);
            
            if (index < 0) index = 0;
            
            _dropdown.value = index;
            
            _dropdown.onValueChanged.AddListener(i =>
            {
                context.SetValue(spec.Id, _options[i]);
                onValueChanged?.Invoke();
            });

        }
    }
}