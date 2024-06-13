using System;

namespace Asteroids.Scripts.DI.Exceptions
{
	public class InstanceCreationException : Exception
	{
		public InstanceCreationException(string message) : base(message) { }
	}
}