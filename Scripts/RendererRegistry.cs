using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DynamicPanels.Scripts
{
    [CreateAssetMenu(fileName = "RendererRegistry", menuName = "Scriptable Objects/RendererRegistry")]
    public class RendererRegistry : ScriptableObject
    {
        [Serializable]
        private struct Entry
        {
            public FieldType Type;
            public FieldRenderer Prefab;
        }

        [SerializeField] private List<Entry> _entries;

        private Dictionary<FieldType, FieldRenderer> _map;

        private void OnEnable()
        {
            if(_entries == null) return;
            
            _map = _entries.ToDictionary(e => e.Type, e => e.Prefab);
        }

        public FieldRenderer GetRenderer(FieldType type)
        {
            if (_map.TryGetValue(type, out var prefab))
                return prefab;
            
            throw new Exception($"No renderer registered for type {type}");
        }
    }
    
    public enum FieldType { Bool, Enum, Int, ModeStatistic }
}

