using Asteroids.Scripts.Core.Infrastructure.Utilities;
using UnityEngine;

namespace Asteroids.Scripts.Core.UI.Base
{
	[RequireComponent(typeof(CanvasGroup))]
	public abstract class CanvasScreen : MonoBehaviour, IScreen
	{
		[SerializeField]
		private CanvasGroup _canvasGroup;

		public void Show()
		{
			_canvasGroup.Show();
			OnShown();
		}
		protected virtual void OnShown() { }

		public void Close()
		{
			_canvasGroup.Hide();
			OnClosed();
		}
		protected virtual void OnClosed() { }

		private void Reset()
		{
			// TODO: rework.
			string typeName = GetType().Name;
			if (string.Equals(gameObject.name, typeName) == false)
			{
				Debug.LogError($"You have to rename it to properly work with asset provider.\nRequired name {typeName}.",
							   gameObject);
				DestroyImmediate(this);
			}

			_canvasGroup = GetComponent<CanvasGroup>();
		}
	}
}