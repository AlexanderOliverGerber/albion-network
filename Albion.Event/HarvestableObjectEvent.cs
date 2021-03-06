﻿// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

using Albion.Common;
using Albion.Network;
using System;
using System.Collections.Generic;

namespace Albion.Event
{
    public class HarvestableObjectEvent : BaseEvent
    {
        public HarvestableObjectEvent(Dictionary<byte, object> parameters) : base(parameters)
        {
            var position = (float[])parameters[3];

            Id = Convert.ToInt32(parameters[0]);
            Type = (HarvestableType)Enum.Parse(typeof(HarvestableType), $"{parameters[1]}");
            Tier = (byte)parameters[2];
            Position = new Position(position[0], position[1]);
            Size = (byte)parameters[4];
        }

        public int Id { get; }
        public HarvestableType Type { get; }
        public byte Tier { get; }
        public Position Position { get; }
        public byte Size { get; }
    }
}
