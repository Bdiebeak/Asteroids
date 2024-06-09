using System;

namespace Asteroids.Scripts.DI.Exceptions
{
	public class BaseContainerException : Exception
	{
		public BaseContainerException(string message, string hint) : base(hint != null ? $"{message}\nHint: {hint}" : message) { }
	}
}