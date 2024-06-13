using System;

namespace Asteroids.Scripts.ECS.Exceptions
{
	public class AddComponentException : Exception
	{
		public AddComponentException(string message) : base(message) { }
	}
}