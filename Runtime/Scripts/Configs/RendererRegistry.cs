using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace KasaiFudo.DynamicPanels
{
    [CreateAssetMenu(fileName = "RendererRegistry", menuName = "Scriptable Objects/RendererRegistry")]
    public class RendererRegistry : ScriptableObject
    {
        [Serializable]
        private struct Entry
        {
            public string RendererKey;
            public FieldRenderer Prefab;
        }

        [SerializeField] private List<Entry> _entries;

        private Dictionary<string, FieldRenderer> _map;

        private void OnEnable()
        {
            if(_entries == null) return;
            
            _map = _entries.ToDictionary(e => e.RendererKey, e => e.Prefab);
        }

        public FieldRenderer GetRenderer(string rendererKey)
        {
            if (_map.TryGetValue(rendererKey, out var prefab))
                return prefab;
            
            throw new Exception($"No renderer registered for key {rendererKey}");
        }
    }
}

