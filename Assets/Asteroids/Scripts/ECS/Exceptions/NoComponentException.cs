using System;

namespace Asteroids.Scripts.ECS.Exceptions
{
	public class NoComponentException : Exception
	{
		public NoComponentException(string message) : base(message) { }
	}
}