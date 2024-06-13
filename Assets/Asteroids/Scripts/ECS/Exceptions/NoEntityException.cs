using System;

namespace Asteroids.Scripts.ECS.Exceptions
{
	public class NoEntityException : Exception
	{
		public NoEntityException(string message) : base(message) { }
	}
}