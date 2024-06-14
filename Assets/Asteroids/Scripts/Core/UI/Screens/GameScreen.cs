using Asteroids.Scripts.Core.UI.Base;
using Asteroids.Scripts.Core.UI.ScreenModels;

namespace Asteroids.Scripts.Core.UI.Screens
{
	public class GameScreen : CanvasScreen
	{
		private GameScreenModel _screenModel;

		// TODO: how to pass ScreenModel?
		public void Construct(GameScreenModel screenModel)
		{
			_screenModel = screenModel;
		}
	}
}