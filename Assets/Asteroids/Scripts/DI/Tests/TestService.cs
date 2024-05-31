namespace Asteroids.Scripts.DI.Tests
{
	public class TestService : ITestService
	{
		public int Value { get; }

		public TestService() { }

		public TestService(int value)
		{
			Value = value;
		}
	}
}