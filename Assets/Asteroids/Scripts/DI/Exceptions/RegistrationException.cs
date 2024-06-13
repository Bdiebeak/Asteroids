using System;

namespace Asteroids.Scripts.DI.Exceptions
{
	public class RegistrationException : Exception
	{
		public RegistrationException(string message) : base(message) { }
	}
}