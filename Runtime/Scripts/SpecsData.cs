using System.Collections.Generic;
using UnityEngine;

namespace KasaiFudo.DynamicPanels
{
    [CreateAssetMenu(fileName = "SpecsData", menuName = "Scriptable Objects/SpecsData")]
    public class SpecsData : ScriptableObject
    {
        [field: SerializeField] public List<FieldSpec> Specs { get; private set; }
    }
}
