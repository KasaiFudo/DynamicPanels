using System;
using UnityEngine;

namespace DynamicPanels.Scripts
{
    public abstract class FieldRenderer : MonoBehaviour
    {
        public abstract void Bind(FieldSpec spec, IDataContext context, Action onValueChanged = null);
    }
}
