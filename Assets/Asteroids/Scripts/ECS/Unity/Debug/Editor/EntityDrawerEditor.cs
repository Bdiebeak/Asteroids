using UnityEditor;
using UnityEngine;

namespace Asteroids.Scripts.ECS.Unity.Debug.Editor
{
	[CustomEditor(typeof(EntityDrawer))]
	public class EntityDrawerEditor : UnityEditor.Editor
	{
		private SerializedProperty _componentsProperty;

		public void OnEnable()
		{
			_componentsProperty = serializedObject.FindProperty(nameof(EntityDrawer.components));
		}

		public override void OnInspectorGUI()
		{
			for (int i = 0; i < _componentsProperty.arraySize; i++)
			{
				SerializedProperty componentWrapperProperty = _componentsProperty.GetArrayElementAtIndex(i);
				SerializedProperty componentProperty = componentWrapperProperty.FindPropertyRelative(nameof(ComponentWrapper.componentReference));
				EditorGUILayout.PropertyField(componentProperty, new GUIContent($"{componentProperty.boxedValue.GetType().Name}"), true);
			}

			serializedObject.ApplyModifiedProperties();
		}
	}
}