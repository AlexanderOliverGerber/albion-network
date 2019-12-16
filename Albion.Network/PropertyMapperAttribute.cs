using System;

namespace Albion.Network
{
    public class PropertyMapperAttribute : Attribute
    {
        public PropertyMapperAttribute(byte index)
        {
            Index = index;
        }

        public byte Index { get; }
    }
}
