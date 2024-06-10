using System;
using Asteroids.Scripts.ECS.Components;

namespace Asteroids.Scripts.Core.Gameplay.View.Components
{
	[Serializable]
	public class ViewComponent : IComponent
	{
		public IView value;
	}
}