using UnityEditor;
using UnityEngine;

namespace Asteroids.Scripts.ECS.Unity.Debug.Editor
{
	[CustomEditor(typeof(EntityDrawer))]
	public class EntityDrawerEditor : UnityEditor.Editor
	{
		private SerializedProperty _componentsProperty;
		private EntityDrawer _entityDrawer;

		public void OnEnable()
		{
			_entityDrawer = (EntityDrawer)target;
			_componentsProperty = serializedObject.FindProperty(nameof(EntityDrawer.components));
		}

		public override void OnInspectorGUI()
		{
			_entityDrawer.RefillComponents();
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