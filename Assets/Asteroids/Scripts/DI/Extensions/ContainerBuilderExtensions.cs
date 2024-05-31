using System;
using Asteroids.Scripts.DI.Builder;
using Asteroids.Scripts.DI.Container;
using Asteroids.Scripts.DI.Describers;

namespace Asteroids.Scripts.DI.Extensions
{
	public static class ContainerBuilderExtensions
	{
		public static IContainerBuilder Register(this IContainerBuilder builder, IContainerInstaller installer)
		{
			installer.InstallTo(builder);
			return builder;
		}

		public static IContainerBuilder Register<TDependency>(this IContainerBuilder builder,
															  Lifetime lifetime = Lifetime.Singleton)
		{
			return Register(builder, typeof(TDependency), typeof(TDependency), lifetime);
		}

		public static IContainerBuilder Register<TDependency, TImplementation>(this IContainerBuilder builder,
																			   Lifetime lifetime = Lifetime.Singleton)
		{
			return Register(builder, typeof(TDependency), typeof(TImplementation), lifetime);
		}

		public static IContainerBuilder Register(this IContainerBuilder builder,
												 Type dependency, Type implementation,
												 Lifetime lifetime = Lifetime.Singleton)
		{
			builder.Register(new TypeDependencyDescriber(lifetime, dependency, implementation));
			return builder;
		}

		public static IContainerBuilder Register<TDependency>(this IContainerBuilder builder, object instance)
		{
			return Register(builder, typeof(TDependency), instance);
		}

		public static IContainerBuilder Register(this IContainerBuilder builder,
												 Type dependency, object instance)
		{
			builder.Register(new InstanceDependencyDescriber(dependency, instance));
			return builder;
		}
	}
}