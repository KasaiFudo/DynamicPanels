using System;
using UnityEngine;

namespace KasaiFudo.DynamicPanels
{
    public abstract class FieldRenderer : MonoBehaviour
    {
        public abstract void Bind(FieldSpec spec, IDataContext context, Action onValueChanged = null);
    }
}
