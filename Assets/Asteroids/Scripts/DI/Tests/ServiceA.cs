namespace Asteroids.Scripts.DI.Tests
{
	public class ServiceA
	{
		private ServiceB _serviceB;

		public ServiceA(ServiceB serviceB)
		{
			_serviceB = serviceB;
		}
	}
}