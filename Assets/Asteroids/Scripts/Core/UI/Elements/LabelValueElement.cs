using TMPro;
using UnityEngine;

namespace Asteroids.Scripts.Core.UI.Elements
{
	public class LabelValueElement : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI labelText;
		[SerializeField]
		private TextMeshProUGUI valueText;

		public void SetLabel(string text)
		{
			labelText.SetText(text);
		}

		public void SetValue(string text)
		{
			valueText.SetText(text);
		}
	}
}