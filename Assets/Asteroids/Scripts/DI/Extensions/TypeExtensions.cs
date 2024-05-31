using System;
using System.Collections.Generic;

namespace Asteroids.Scripts.DI.Extensions
{
	public static class TypeExtensions
	{
		public static IReadOnlyList<Type> GetInterfaces(this Type type)
		{
			return type.GetInterfaces();
		}
	}
}