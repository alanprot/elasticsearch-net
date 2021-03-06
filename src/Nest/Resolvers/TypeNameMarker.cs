﻿using System;
using Nest.Resolvers.Converters;
using Newtonsoft.Json;

namespace Nest.Resolvers
{
	[JsonConverter(typeof(TypeNameMarkerConverter))]
	public class TypeNameMarker : IEquatable<TypeNameMarker>
	{
		public string Name { get; set; }
		public Type Type { get; set; }

		public static TypeNameMarker Create(Type type)
		{
			return GetTypeNameForType(type);
		}

		public static TypeNameMarker Create<T>() where T : class
		{
			return GetTypeNameForType(typeof(T));
		}

		private static TypeNameMarker GetTypeNameForType(Type type)
		{
			return new TypeNameMarker { Type = type };
		}

		public static implicit operator TypeNameMarker(string typeName)
		{
			return typeName == null ? null : new TypeNameMarker { Name = typeName };
		}

		public static implicit operator TypeNameMarker(Type type)
		{
			return type == null ? null : new TypeNameMarker { Type = type };
		}

		public override int GetHashCode()
		{
			if (this.Name != null)
				return this.Name.GetHashCode();
			return this.Type != null ? this.Type.GetHashCode() : 0;
		}
		public bool Equals(TypeNameMarker other)
		{
			return other != null && this.GetHashCode() == other.GetHashCode();
		}
	}
}