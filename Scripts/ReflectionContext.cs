using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DynamicPanels.Scripts
{
    public class DynamicDataContext<T> : IDataContext where T : class
    {
        private readonly T _target;
        private readonly Dictionary<string, PropertyInfo> _properties;

        public event Action<string, object> OnValueChanged;

        public DynamicDataContext(T target)
        {
            _target = target ?? throw new ArgumentNullException(nameof(target));

            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
            _properties = properties.ToDictionary(p => p.Name, p => p);
        }

        /// <summary>
        /// Retrieves the value of the property identified by the specified id from the target object.
        /// </summary>
        /// <param name="id">The identifier of the property to retrieve.</param>
        /// <returns>The value of the property identified by the given id.</returns>
        /// <exception cref="ArgumentException">Thrown if the property with the specified id is not found on the target object.</exception>
        public object GetValue(string id)
        {
            if (_properties.TryGetValue(id, out var prop))
                return prop.GetValue(_target);

            throw new ArgumentException($"Property '{id}' not found on {typeof(T).Name}");
        }

        /// <summary>
        /// Sets the value of the property identified by the specified id on the target object.
        /// </summary>
        /// <param name="id">The identifier of the property to set.</param>
        /// <param name="value">The value to set.</param>
        /// <exception cref="ArgumentException">Thrown if the property with the specified id is not found on the target object.</exception>
        public void SetValue(string id, object value)
        {
            if (_properties.TryGetValue(id, out var prop))
            {
                var converted = ConvertValue(value, prop.PropertyType);
                prop.SetValue(_target, converted);
                OnValueChanged?.Invoke(id, converted);
            }
            else
            {
                throw new ArgumentException($"Property '{id}' not found on {typeof(T).Name}");
            }
        }

        private object ConvertValue(object value, Type targetType)
        {
            if (value == null) return null;

            if (targetType.IsEnum)
            {
                if (value is string s) return Enum.Parse(targetType, s);
                if (value.GetType().IsPrimitive) return Enum.ToObject(targetType, value);
            }

            return Convert.ChangeType(value, targetType);
        }
    }
    
    /*public class ParametersContext : DynamicDataContext<Parameters>
    {
        public ParametersContext(Parameters parameters) : base(parameters)
        {
        }
    }

    public class DebugResolverContext : DynamicDataContext<DebugResolver>
    {
        public DebugResolverContext(DebugResolver debugResolver) : base(debugResolver)
        {
        }
    }*/
}
