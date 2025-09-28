using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace KasaiFudo.DynamicPanels
{
    [Serializable]
    public class Condition 
    {
        [SerializeField] private string _settingId;
        [SerializeField] private string _op;        // "==", "!=", ">", "<", "in"
        [SerializeField] private string _propertyValue; // храним как string, парсим по типу цели

        public bool Evaluate(IDataContext context)
        {
            if (context == null || string.IsNullOrEmpty(_settingId))
                return false;

            var prop = context.GetType().GetProperty(_settingId);
            if (prop == null)
            {
                UnityEngine.Debug.LogWarning($"Property by id {_settingId} is null");
                return false;
            }

            var targetValue = prop.GetValue(context);
            if (targetValue == null) return false;

            var expectedValue = Convert.ChangeType(_propertyValue, prop.PropertyType);

            if (expectedValue == null)
            {
                UnityEngine.Debug.LogWarning($"Can't convert property {prop.Name} value to expected type {prop.PropertyType.Name}");
                return false;
            }

            switch (_op)
            {
                case "==": return Equals(targetValue, expectedValue);
                case "!=": return !Equals(targetValue, expectedValue);

                case ">":
                    return Compare(targetValue, expectedValue) > 0;
                case "<":
                    return Compare(targetValue, expectedValue) < 0;

                case "in":
                    if (expectedValue is IEnumerable list)
                    {
                        foreach (var item in list)
                            if (Equals(item, targetValue))
                                return true;
                    }
                    return false;

                default:
                    UnityEngine.Debug.LogWarning($"Condition: неподдерживаемая операция {_op}");
                    return false;
            }
        }

        private int Compare(object a, object b)
        {
            if (a is IComparable ca && b != null)
                return ca.CompareTo(b);
            throw new InvalidOperationException($"Condition: объекты {a} и {b} не поддерживают сравнение");
        }
    }
}
