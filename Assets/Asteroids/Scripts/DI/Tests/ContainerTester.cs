using Asteroids.Scripts.DI.Builder;
using Asteroids.Scripts.DI.Describers;
using Asteroids.Scripts.DI.Exceptions;
using Asteroids.Scripts.DI.Resolver;
using NUnit.Framework;

namespace Asteroids.Scripts.DI.Tests
{
	public class ContainerTester
	{
		[Test]
		public void TestUnregisteredDependency()
		{
			IContainerBuilder builder = new ContainerBuilder();
			IContainerResolver containerResolver = builder.Build();

			Assert.Throws<RegistrationException>(() => containerResolver.Resolve<ITestService>());
		}

		[Test]
		public void TestCycledDependencies()
		{
			IContainerBuilder builder = new ContainerBuilder();
			builder.Register(new TypeDependencyDescriber(Lifetime.Singleton, typeof(ServiceA), typeof(ServiceA)));
			builder.Register(new TypeDependencyDescriber(Lifetime.Singleton, typeof(ServiceB), typeof(ServiceB)));

			IContainerResolver containerResolver = builder.Build();

			Assert.Throws<CycleDependencyException>(() => containerResolver.Resolve<ServiceA>());
			Assert.Throws<CycleDependencyException>(() => containerResolver.Resolve<ServiceB>());
		}

		[Test]
		public void TestTypesMismatch()
		{
			IContainerBuilder builder = new ContainerBuilder();

			Assert.Throws<RegistrationException>(() => builder.Register(new TypeDependencyDescriber(Lifetime.Singleton, typeof(ServiceA), typeof(ServiceB))));
		}

		[Test]
		public void TestCreationWithoutConstructor()
		{
			IContainerBuilder builder = new ContainerBuilder();
			builder.Register(new TypeDependencyDescriber(Lifetime.Singleton, typeof(ITestService), typeof(ITestService)));
			IContainerResolver containerResolver = builder.Build();

			Assert.Throws<InstanceCreationException>(() => containerResolver.Resolve<ITestService>());
		}

		[Test]
		public void TestInstanceDependency()
		{
			IContainerBuilder builder = new ContainerBuilder();
			ITestService bindingService = new TestService();
			builder.Register(new InstanceDependencyDescriber(typeof(ITestService), bindingService));

			IContainerResolver containerResolver = builder.Build();
			ITestService resolvedService = containerResolver.Resolve<ITestService>();

			Assert.AreEqual(bindingService, resolvedService);
		}

		[Test]
		public void TestTypeDependency()
		{
			IContainerBuilder builder = new ContainerBuilder();
			builder.Register(new TypeDependencyDescriber(Lifetime.Singleton, typeof(ITestService), typeof(TestService)));

			IContainerResolver containerResolver = builder.Build();
			ITestService resolvedService = containerResolver.Resolve<ITestService>();

			Assert.NotNull(resolvedService);
			Assert.IsInstanceOf<TestService>(resolvedService);
		}

		[Test]
		public void TestSelfTypeDependency()
		{
			IContainerBuilder builder = new ContainerBuilder();
			builder.Register(new TypeDependencyDescriber(Lifetime.Singleton, typeof(TestService), typeof(TestService)));

			IContainerResolver containerResolver = builder.Build();
			TestService resolvedService = containerResolver.Resolve<TestService>();

			Assert.NotNull(resolvedService);
			Assert.IsInstanceOf<TestService>(resolvedService);
		}

		[Test]
		public void TestSingletonResolving()
		{
			IContainerBuilder builder = new ContainerBuilder();
			builder.Register(new TypeDependencyDescriber(Lifetime.Singleton, typeof(ITestService), typeof(TestService)));

			IContainerResolver containerResolver = builder.Build();
			ITestService firstResolvedService = containerResolver.Resolve<ITestService>();
			ITestService secondResolvedService = containerResolver.Resolve<ITestService>();

			Assert.AreEqual(firstResolvedService, secondResolvedService);
		}

		[Test]
		public void TestTransientResolving()
		{
			IContainerBuilder builder = new ContainerBuilder();
			builder.Register(new TypeDependencyDescriber(Lifetime.Transient, typeof(ITestService), typeof(TestService)));

			IContainerResolver containerResolver = builder.Build();
			ITestService firstResolvedService = containerResolver.Resolve<ITestService>();
			ITestService secondResolvedService = containerResolver.Resolve<ITestService>();

			Assert.AreNotEqual(firstResolvedService, secondResolvedService);
		}

		[Test]
		public void TestSelfBinding()
		{
			IContainerBuilder builder = new ContainerBuilder();
			IContainerResolver containerResolver = builder.Build();
			IContainerResolver resolvedContainer = containerResolver.Resolve<IContainerResolver>();

			Assert.AreEqual(containerResolver, resolvedContainer);
		}
	}
}