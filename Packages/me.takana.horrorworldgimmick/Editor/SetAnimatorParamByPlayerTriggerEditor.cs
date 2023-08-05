#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace Taka7n.HorrorWorldGimmick {
    [CustomEditor(typeof(SetAnimatorParamByPlayerTrigger))]
    public class SetAnimatorParamByPlayerTriggerEditor : SetAnimatorParamEditor
    {
        private bool _isOnlyOnce;
        private float _delay;
        private Collider _selfCollider;
        private PlayerTriggerEvent _playerTriggerEvent;
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            var _isOnlyOnceProp = serializedObject.FindProperty("_isOnlyOnce");
            var _delayProp = serializedObject.FindProperty("_delay");
            var _playerTriggerEventProp = serializedObject.FindProperty("_playerTriggerEvent");
            _isOnlyOnce = (bool) _isOnlyOnceProp.boolValue;
            _delay = (float) _delayProp.floatValue;
            _selfCollider = ((Component) serializedObject.targetObject).GetComponent<Collider>();
            _playerTriggerEvent = (PlayerTriggerEvent) _playerTriggerEventProp.intValue;

            _isOnlyOnce = EditorGUILayout.Toggle("1度のみ実行する", _isOnlyOnce);
            _delay = EditorGUILayout.FloatField("値変更の遅延時間（秒）", _delay);
            _playerTriggerEvent = (PlayerTriggerEvent) EditorGUILayout.EnumPopup("使用するEvent", _playerTriggerEvent);

            if (_selfCollider == null) EditorGUILayout.HelpBox("このGameObjectにColliderを追加してください。", MessageType.Warning);
            if (_selfCollider != null)
            {
                if (!_selfCollider.isTrigger) EditorGUILayout.HelpBox("このGameObjectのColliderのisTriggerを設定してください。", MessageType.Warning);
                if (_selfCollider.gameObject.GetComponent<Rigidbody>() == null) EditorGUILayout.HelpBox("このGameObjectのGameObjectにRigidBodyを設定してください。", MessageType.Warning);
            }

            _isOnlyOnceProp.boolValue = _isOnlyOnce;
            _delayProp.floatValue = _delay;
            _playerTriggerEventProp.intValue = (int) _playerTriggerEvent;
            serializedObject.ApplyModifiedProperties();
            base.OnInspectorGUI();
        }
    }
}
#endif