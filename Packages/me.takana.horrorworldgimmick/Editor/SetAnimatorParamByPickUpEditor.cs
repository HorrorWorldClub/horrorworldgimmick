#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using VRC.SDKBase;

namespace Taka7n.HorrorWorldGimmick {
    [CustomEditor(typeof(SetAnimatorParamByPickUp))]
    public class SetAnimatorParamByPickUpEditor : SetAnimatorParamEditor
    {
        private bool _isOnlyOnce;
        private float _delay;
        private PickUpEvent _pickUpEvent;
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            if (((Component) serializedObject.targetObject).GetComponent<VRC_Pickup>() == null)
            {
                EditorGUILayout.HelpBox("このGameObjectにVRC Pickupを追加してください。", MessageType.Warning);
            }
            var _isOnlyOnceProp = serializedObject.FindProperty("_isOnlyOnce");
            var _delayProp = serializedObject.FindProperty("_delay");
            var _pickUpEventProp = serializedObject.FindProperty("_pickUpEvent");
            _isOnlyOnce = (bool) _isOnlyOnceProp.boolValue;
            _delay = (float) _delayProp.floatValue;
            _pickUpEvent = (PickUpEvent) _pickUpEventProp.intValue;

            _isOnlyOnce = EditorGUILayout.Toggle("1度のみ実行する", _isOnlyOnce);
            _delay = EditorGUILayout.FloatField("値変更の遅延時間（秒）", _delay);
            _pickUpEvent = (PickUpEvent) EditorGUILayout.EnumPopup("使用するEvent", _pickUpEvent);

            _isOnlyOnceProp.boolValue = _isOnlyOnce;
            _delayProp.floatValue = _delay;
            _pickUpEventProp.intValue = (int) _pickUpEvent;
            serializedObject.ApplyModifiedProperties();
            base.OnInspectorGUI();
        }
    }
}
#endif