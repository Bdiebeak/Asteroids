using Asteroids.Scripts.DI.Builder;
using Asteroids.Scripts.DI.Container;
using Asteroids.Scripts.DI.Describers;
using Asteroids.Scripts.DI.Extensions;
using NUnit.Framework;

namespace Asteroids.Scripts.DI.Tests
{
	public class ContainerTester
	{
		[Test]
		public void TestInstanceDependency()
		{
			IContainerBuilder builder = new ContainerBuilder();
			ITestService bindingService = new TestService();
			builder.Register(new InstanceDependencyDescriber(typeof(ITestService), bindingService));

			IContainer container = builder.Build();
			ITestService resolvedService = container.Resolve<ITestService>();

			Assert.AreEqual(bindingService, resolvedService);
		}

		[Test]
		public void TestTypeDependency()
		{
			IContainerBuilder builder = new ContainerBuilder();
			builder.Register(new TypeDependencyDescriber(Lifetime.Singleton, typeof(ITestService), typeof(TestService)));

			IContainer container = builder.Build();
			ITestService resolvedService = container.Resolve<ITestService>();

			Assert.NotNull(resolvedService);
			Assert.IsInstanceOf<TestService>(resolvedService);
		}

		[Test]
		public void TestTypeDependencyWithoutConstructors()
		{
			IContainerBuilder builder = new ContainerBuilder();
			builder.Register(new TypeDependencyDescriber(Lifetime.Singleton, typeof(ITestService), typeof(TestServiceNoConstructors)));

			IContainer container = builder.Build();
			ITestService resolvedService = container.Resolve<ITestService>();

			Assert.NotNull(resolvedService);
			Assert.IsInstanceOf<TestServiceNoConstructors>(resolvedService);
		}

		[Test]
		public void TestSelfTypeDependency()
		{
			IContainerBuilder builder = new ContainerBuilder();
			builder.Register(new TypeDependencyDescriber(Lifetime.Singleton, typeof(TestService), typeof(TestService)));

			IContainer container = builder.Build();
			TestService resolvedService = container.Resolve<TestService>();

			Assert.NotNull(resolvedService);
			Assert.IsInstanceOf<TestService>(resolvedService);
		}

		[Test]
		public void TestSingletonResolving()
		{
			IContainerBuilder builder = new ContainerBuilder();
			builder.Register(new TypeDependencyDescriber(Lifetime.Singleton, typeof(ITestService), typeof(TestService)));

			IContainer container = builder.Build();
			ITestService firstResolvedService = container.Resolve<ITestService>();
			ITestService secondResolvedService = container.Resolve<ITestService>();

			Assert.AreEqual(firstResolvedService, secondResolvedService);
		}

		[Test]
		public void TestTransientResolving()
		{
			IContainerBuilder builder = new ContainerBuilder();
			builder.Register(new TypeDependencyDescriber(Lifetime.Transient, typeof(ITestService), typeof(TestService)));

			IContainer container = builder.Build();
			ITestService firstResolvedService = container.Resolve<ITestService>();
			ITestService secondResolvedService = container.Resolve<ITestService>();

			Assert.AreNotEqual(firstResolvedService, secondResolvedService);
		}

		[Test]
		public void TestSelfBinding()
		{
			IContainerBuilder builder = new ContainerBuilder();
			IContainer container = builder.Build();
			IContainer resolvedContainer = container.Resolve<IContainer>();

			Assert.AreEqual(container, resolvedContainer);
		}

		[Test]
		public void TestInjectInto()
		{
			IContainerBuilder builder = new ContainerBuilder();
			builder.Register(new TypeDependencyDescriber(Lifetime.Singleton, typeof(ITestService), typeof(TestService)));
			IContainer container = builder.Build();
			ServiceC serviceC = new ServiceC();
			container.InjectInto(serviceC);

			Assert.IsNotNull(serviceC.Service);
			Assert.AreEqual(serviceC.Service, container.Resolve<ITestService>());
		}
	}
}