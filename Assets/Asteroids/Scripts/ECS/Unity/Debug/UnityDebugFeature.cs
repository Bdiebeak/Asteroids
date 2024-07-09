using Asteroids.Scripts.ECS.Contexts;
using Asteroids.Scripts.ECS.Features;
using Asteroids.Scripts.ECS.Systems.Container;
using Asteroids.Scripts.ECS.Unity.Debug.Systems;

namespace Asteroids.Scripts.ECS.Unity.Debug
{
	public class UnityDebugFeature : Feature
	{
		private readonly IContext _context;

		public UnityDebugFeature(IContext context)
		{
			_context = context;
		}

		public override void AddTo(SystemsContainer systems)
		{
			systems.Add(new DebugContextSystem(_context));
		}
	}
}