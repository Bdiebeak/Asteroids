using System;
using Asteroids.Scripts.DI.Builder;
using Asteroids.Scripts.DI.Container;
using Asteroids.Scripts.DI.Describers;
using NUnit.Framework;

namespace Asteroids.Scripts.DI.Tests
{
	public class ContainerTester
	{
		[Test]
		public void TestUnregisteredDependency()
		{
			IContainerBuilder builder = new ContainerBuilder();
			IContainer container = builder.Build();

			Assert.Throws<InvalidOperationException>(() => container.Resolve<ITestService>());
		}

		[Test]
		public void TestCycledDependencies()
		{
			IContainerBuilder builder = new ContainerBuilder();
			builder.Register(new TypeDependencyDescriber(Lifetime.Singleton, typeof(ServiceA), typeof(ServiceA)));
			builder.Register(new TypeDependencyDescriber(Lifetime.Singleton, typeof(ServiceB), typeof(ServiceB)));

			IContainer container = builder.Build();

			Assert.Throws<InvalidOperationException>(() => container.Resolve<ServiceA>());
			Assert.Throws<InvalidOperationException>(() => container.Resolve<ServiceB>());
		}

		[Test]
		public void TestTypesMismatch()
		{
			IContainerBuilder builder = new ContainerBuilder();

			Assert.Throws<InvalidOperationException>(() => builder.Register(new TypeDependencyDescriber(Lifetime.Singleton, typeof(ServiceA), typeof(ServiceB))));
		}

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
	}
}