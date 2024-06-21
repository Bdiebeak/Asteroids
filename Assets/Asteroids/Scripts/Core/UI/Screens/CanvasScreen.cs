﻿using Asteroids.Scripts.Core.Infrastructure.Extensions;
using Asteroids.Scripts.Core.Infrastructure.Services.Screens;
using UnityEngine;

namespace Asteroids.Scripts.Core.UI.Screens
{
	[RequireComponent(typeof(CanvasGroup))]
	public abstract class CanvasScreen : MonoBehaviour, IScreen
	{
		[SerializeField]
		protected CanvasGroup canvasGroup;

		public void Show()
		{
			canvasGroup.Show();
			OnShown();
		}
		protected virtual void OnShown() { }

		public void Close()
		{
			canvasGroup.Hide();
			OnClosed();
		}
		protected virtual void OnClosed() { }

		private void Reset()
		{
			canvasGroup = GetComponent<CanvasGroup>();
		}
	}
}