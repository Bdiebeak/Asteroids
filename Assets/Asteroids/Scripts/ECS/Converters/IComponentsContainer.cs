using System.Collections.Generic;

namespace Asteroids.Scripts.ECS.Converters
{
	public interface IComponentsContainer
	{
		IReadOnlyList<IConverter> Converters { get; }
	}
}