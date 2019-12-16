using System;
using System.Collections.Generic;
using System.Reflection;

namespace Albion.Network
{
    public class DefaultDataMapper : IDataMapper
    {
        public T MapFromParameters<T>(Dictionary<byte, object> parameters)
        {
            object instance = Activator.CreateInstance(typeof(T));

            Type objType = typeof(T);
            PropertyInfo[] properties = objType.GetProperties();

            for (byte i = 0; i < properties.Length; i++)
            {
                byte index;

                PropertyInfo property = properties[i];
                PropertyMapperAttribute propertyAttributer = property.GetCustomAttribute<PropertyMapperAttribute>();
                if (propertyAttributer != null)
                {
                    index = propertyAttributer.Index;
                }
                else
                {
                    index = i;
                }

                if (parameters.TryGetValue(index, out object parameter))
                {
                    var propertyMapper = new PropertyMapper(property);
                    propertyMapper.Deserialize(instance, parameter);
                }
            }

            return (T)instance;
        }
    }
}
