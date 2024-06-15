using Asteroids.Scripts.Core.UI.Base;
using Asteroids.Scripts.Core.UI.Models;

namespace Asteroids.Scripts.Core.UI.Screens
{
	public class GameScreen : CanvasScreen
	{
		private GameScreenModel _screenModel;

		public void Construct(GameScreenModel screenModel)
		{
			_screenModel = screenModel;
		}
	}
}