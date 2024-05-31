using Asteroids.Scripts.DI.Container;
using NUnit.Framework;

namespace Asteroids.Scripts.DI.Tests
{
	public class ContainerTester
	{
		private interface ITestInterface
		{
			int TestInt { get; }
			void TestFunction();
		}

		private class TestClass : ITestInterface
		{
			public int TestInt { get; }

			public void TestFunction()
			{
			}
		}

		[Test]
		public void NewTestScriptSimplePasses()
		{
			DependencyContainer container = new();
			container.Register<TestClass>().As(typeof(ITestInterface));

			ITestInterface testInterface = container.Resolve<ITestInterface>();
			Assert.NotNull(testInterface);
			Assert.Zero(testInterface.TestInt);

			// TODO: throw exception - can't find constructor.
			// container.Register<ITestInterface>();

			// TODO: throw exception - already registered.
			// container.Register<TestClass>();
			// container.Register<TestClass>();

			// TODO: throw if types mismatch.
			// container.Register<TestClass>().As(typeof(ITestInterface));
		}
	}
}