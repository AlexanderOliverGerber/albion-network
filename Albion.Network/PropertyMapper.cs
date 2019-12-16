using System;
using System.Reflection;

namespace Albion.Network
{
    public class PropertyMapper
    {
        public PropertyMapper(PropertyInfo property)
        {
            Property = property;

            if (property.PropertyType == typeof(short))
            {
                Deserialize = new Deserializer(SetValue);

                return;
            }

            if (property.PropertyType == typeof(int))
            {
                Deserialize = new Deserializer(SetValue);

                return;
            }

            if (property.PropertyType == typeof(long))
            {
                Deserialize = new Deserializer(SetValue);

                return;
            }

            if (property.PropertyType == typeof(bool))
            {
                Deserialize = new Deserializer(SetValue);

                return;
            }

            if (property.PropertyType == typeof(float))
            {
                Deserialize = new Deserializer(SetValue);

                return;
            }

            if (property.PropertyType == typeof(Guid))
            {
                Deserialize = new Deserializer(SetGuid);

                return;
            }

            if (property.PropertyType == typeof(short[]))
            {
                Deserialize = new Deserializer(SetShortArray);

                return;
            }

            if (property.PropertyType == typeof(int[]))
            {
            }

            if (property.PropertyType == typeof(long[]))
            {
            }

            if (property.PropertyType == typeof(float[]))
            {
                Deserialize = new Deserializer(SetFloatArray);
            }

            Deserialize = new Deserializer(SetValue);
        }

        public PropertyInfo Property { get; }
        public Deserializer Deserialize { get; }

        public delegate void Deserializer(object instance, object parameter);

        private void SetValue(object instance, object parameter)
        {
            Property.SetValue(instance, parameter);
        }

        private void SetGuid(object instance, object parameter)
        {
            byte[] bytes = (byte[])parameter;
            var guid = new Guid(bytes);

            Property.SetValue(instance, guid);
        }

        private void SetFloatArray(object instance, object parameter)
        {
            float[] array = (float[])parameter;

            Property.SetValue(instance, array);
        }

        private void SetShortArray(object instance, object parameter)
        {
            short[] array;
            if (parameter is short[])
            {
                array = (short[])parameter;
            }
            else if (parameter is byte[] bytes)
            {
                array = new short[bytes.Length];
                for (int i = 0; i < bytes.Length; i++)
                {
                    array[i] = bytes[i];
                }
            }
            else
            {
                throw new AlbionException("");
            }

            Property.SetValue(instance, array);
        }

        private void SetIntArray(object instance, object parameter)
        {
            int[] array;
            if (parameter is int[])
            {
                array = (int[])parameter;
            }
            else if (parameter is short[])
            {
                short[] shorts = (short[])parameter;
                array = new int[shorts.Length];
                for (int i = 0; i < shorts.Length; i++)
                {
                    array[i] = (int)
                }
            }
            else if (parameter is byte[])
            {

            }
            else
            {
                throw new AlbionException("");
            }

            Property.SetValue(instance, array);
        }
    }
}
