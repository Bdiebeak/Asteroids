using System.Collections.Generic;

namespace Asteroids.Scripts.Core.Game.Converters.Base
{
	public interface IConvertersContainer
	{
		IReadOnlyList<IConverter> Converters { get; }
	}
}