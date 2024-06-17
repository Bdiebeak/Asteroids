using Asteroids.Scripts.DI.Builder;
using Asteroids.Scripts.DI.Describers;
using Asteroids.Scripts.DI.Exceptions;
using Asteroids.Scripts.DI.Resolver;
using NUnit.Framework;

namespace Asteroids.Scripts.DI.Tests
{
	public class ContainerExceptionsTester
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
		public void TestAbstractBinding()
		{
			IContainerBuilder builder = new ContainerBuilder();
			builder.Register(new TypeDependencyDescriber(Lifetime.Singleton, typeof(ITestService), typeof(ITestService)));
			IContainerResolver containerResolver = builder.Build();

			Assert.Throws<InstanceCreationException>(() => containerResolver.Resolve<ITestService>());
		}
	}
}