using System.Collections.Generic;
using UnityEngine;

namespace DynamicPanels.Scripts
{
    [CreateAssetMenu(fileName = "SpecsData", menuName = "Scriptable Objects/SpecsData")]
    public class SpecsData : ScriptableObject
    {
        [field: SerializeField] public List<FieldSpec> Specs { get; private set; }
    }
}
