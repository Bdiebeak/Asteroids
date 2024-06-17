using Asteroids.Scripts.DI.Resolver;

namespace Asteroids.Scripts.DI.Tests
{
	public class ServiceC
	{
		public ITestService Service { get; private set; }

		[Inject]
		public void Construct(ITestService service)
		{
			Service = service;
		}
	}
}