using Asteroids.Scripts.Core.UI.Base;
using Asteroids.Scripts.Core.UI.Models;
using Asteroids.Scripts.DI.Resolver;

namespace Asteroids.Scripts.Core.UI.Screens
{
	public class GameScreen : CanvasScreen
	{
		private GameScreenModel _screenModel;

		[Inject]
		public void Construct(GameScreenModel screenModel)
		{
			_screenModel = screenModel;
		}
	}
}