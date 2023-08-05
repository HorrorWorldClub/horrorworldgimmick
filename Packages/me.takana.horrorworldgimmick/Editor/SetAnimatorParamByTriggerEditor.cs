#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace Taka7n.HorrorWorldGimmick {
    [CustomEditor(typeof(SetAnimatorParamByTrigger))]
    public class SetAnimatorParamByTriggerEditor : SetAnimatorParamEditor
    {
        private Collider _targetCollider;
        private bool _isOnlyOnce;
        private float _delay;
        private Collider _selfCollider;
        private TriggerEvent _triggerEvent;
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            var _targetColliderProp = serializedObject.FindProperty("_targetCollider");
            var _isOnlyOnceProp = serializedObject.FindProperty("_isOnlyOnce");
            var _delayProp = serializedObject.FindProperty("_delay");
            var _triggerEventProp = serializedObject.FindProperty("_triggerEvent");
            _targetCollider = (Collider) _targetColliderProp.objectReferenceValue;
            _isOnlyOnce = (bool) _isOnlyOnceProp.boolValue;
            _delay = (float) _delayProp.floatValue;
            _selfCollider = ((Component) serializedObject.targetObject).GetComponent<Collider>();
            _triggerEvent = (TriggerEvent) _triggerEventProp.intValue;

            _isOnlyOnce = EditorGUILayout.Toggle("1度のみ実行する", _isOnlyOnce);
            _delay = EditorGUILayout.FloatField("値変更の遅延時間（秒）", _delay);
            _triggerEvent = (TriggerEvent) EditorGUILayout.EnumPopup("使用するEvent", _triggerEvent);

            if (_selfCollider == null) EditorGUILayout.HelpBox("このGameObjectにColliderを追加してください。", MessageType.Warning);
            if (_targetCollider == null) EditorGUILayout.HelpBox("衝突判定を行うColliderを指定してください。", MessageType.Warning);
            if (_selfCollider != null && _targetCollider != null)
            {
                if (!_targetCollider.isTrigger && !_selfCollider.isTrigger) EditorGUILayout.HelpBox("このGameObjectもしくは衝突判定を行うColliderのisTriggerを設定してください。", MessageType.Warning);
                if (_targetCollider.gameObject.GetComponent<Rigidbody>() == null && _selfCollider.gameObject.GetComponent<Rigidbody>() == null) EditorGUILayout.HelpBox("このGameObjectもしくは衝突判定を行うColliderのGameObjectにRigidBodyを設定してください。", MessageType.Warning);
            }
            _targetCollider = (Collider) EditorGUILayout.ObjectField("衝突判定を行うCollider", _targetCollider, typeof(Collider), true);

            _targetColliderProp.objectReferenceValue = _targetCollider;
            _isOnlyOnceProp.boolValue = _isOnlyOnce;
            _delayProp.floatValue = _delay;
            _triggerEventProp.intValue = (int) _triggerEvent;
            serializedObject.ApplyModifiedProperties();
            base.OnInspectorGUI();
        }
    }
}
#endif