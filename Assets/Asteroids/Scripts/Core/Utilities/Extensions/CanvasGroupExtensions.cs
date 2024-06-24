using UnityEngine;

namespace Asteroids.Scripts.Core.Utilities.Extensions
{
	public static class CanvasGroupExtensions
	{
		public static void Show(this CanvasGroup canvasGroup,
								bool interactable = true, bool blocksRaycasts = true)
		{
			canvasGroup.alpha = 1f;
			canvasGroup.interactable = interactable;
			canvasGroup.blocksRaycasts = blocksRaycasts;
		}

		public static void Hide(this CanvasGroup canvasGroup,
								bool interactable = false, bool blocksRaycasts = false)
		{
			canvasGroup.alpha = 0f;
			canvasGroup.interactable = interactable;
			canvasGroup.blocksRaycasts = blocksRaycasts;
		}
	}
}