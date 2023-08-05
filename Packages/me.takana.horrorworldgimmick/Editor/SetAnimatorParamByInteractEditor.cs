#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using VRC.Udon;
using UdonSharp;

namespace Taka7n.HorrorWorldGimmick {
    [CustomEditor(typeof(SetAnimatorParamByInteract))]
    public class SetAnimatorParamByInteractEditor : SetAnimatorParamEditor
    {
        private bool _isOnlyOnce;
        private float _delay;
        private string _interactionText;
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            var _isOnlyOnceProp = serializedObject.FindProperty("_isOnlyOnce");
            var _delayProp = serializedObject.FindProperty("_delay");
            var _interactionTextProp = serializedObject.FindProperty("_interactionText");
            _isOnlyOnce = (bool) _isOnlyOnceProp.boolValue;
            _delay = (float) _delayProp.floatValue;
            _interactionText = (string) _interactionTextProp.stringValue;

            _isOnlyOnce = EditorGUILayout.Toggle("1度のみ実行する", _isOnlyOnce);
            _delay = EditorGUILayout.FloatField("値変更の遅延時間（秒）", _delay);
            _interactionText = EditorGUILayout.TextField("Interact時の表示文", _interactionText);

            _isOnlyOnceProp.boolValue = _isOnlyOnce;
            _delayProp.floatValue = _delay;
            _interactionTextProp.stringValue = _interactionText;

            ((Component) serializedObject.targetObject).GetComponent<UdonBehaviour>().InteractionText = _interactionText;
            serializedObject.ApplyModifiedProperties();
            base.OnInspectorGUI();
        }
    }
}
#endif