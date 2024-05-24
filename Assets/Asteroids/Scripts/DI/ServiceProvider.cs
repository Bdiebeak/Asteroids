using System;
using System.Collections.Generic;

namespace Asteroids.Scripts.DI
{
	public class ServiceProvider : IServiceProvider
	{
		private Dictionary<Type, object> _services = new();

		public void Bind<TService>(TService implementation)
		{
			_services[typeof(TService)] = implementation;
		}

		public TService Resolve<TService>()
		{
			return (TService)_services[typeof(TService)];
		}
	}
}