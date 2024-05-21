using System.Collections.Generic;

namespace Asteroids.Scripts.ECS.Contexts.Container
{
	public class ContextsContainer : IContextsContainer
	{
		private Dictionary<string, IContext> _contexts = new();

		public void Add(string key, IContext context)
		{
			_contexts[key] = context;
		}

		public IContext Get(string key)
		{
			return _contexts[key];
		}
	}
}