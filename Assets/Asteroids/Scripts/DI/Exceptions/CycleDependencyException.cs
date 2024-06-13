using System;

namespace Asteroids.Scripts.DI.Exceptions
{
	public class CycleDependencyException : Exception
	{
		public CycleDependencyException(string message) : base(message) { }
	}
}