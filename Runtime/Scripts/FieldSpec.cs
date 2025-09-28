using System;
using System.Collections.Generic;
using UnityEngine;

namespace KasaiFudo.DynamicPanels
{
    [Serializable]
    public class FieldSpec
    {
        [Header("Basic")]
        [field: SerializeField] public string Id {get; private set;}
        [field: SerializeField] public FieldType Type {get; private set;}
        [field: SerializeField] public string Label  {get; private set;}

        [Header("Options")][Tooltip("For example it can be enums for string or some other values")]
        [field: SerializeField] public string[] Options {get; private set;}

        [Header("Grouping")]
        [field: SerializeField] public string Group  {get; private set;}
        [field: SerializeField] public int Order {get; private set;}

        [Header("Visibility")]
        [field: SerializeField] public List<Condition> VisibleIf {get; private set;}
    }
}