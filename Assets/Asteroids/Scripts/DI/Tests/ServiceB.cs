namespace Asteroids.Scripts.DI.Tests
{
	public class ServiceB
	{
		private ServiceA _serviceA;

		public ServiceB(ServiceA serviceA)
		{
			_serviceA = serviceA;
		}
	}
}