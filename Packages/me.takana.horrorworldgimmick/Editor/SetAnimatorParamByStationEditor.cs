#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using VRC.SDKBase;

namespace Taka7n.HorrorWorldGimmick {
    [CustomEditor(typeof(SetAnimatorParamByStation))]
    public class SetAnimatorParamByStationEditor : SetAnimatorParamEditor
    {
        private bool _isOnlyOnce;
        private float _delay;
        private StationEvent _stationEvent;
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            if (((Component) serializedObject.targetObject).GetComponent<VRCStation>() == null)
            {
                EditorGUILayout.HelpBox("このGameObjectにVRC Stationを追加してください。", MessageType.Warning);
            }
            var _isOnlyOnceProp = serializedObject.FindProperty("_isOnlyOnce");
            var _delayProp = serializedObject.FindProperty("_delay");
            var _stationEventProp = serializedObject.FindProperty("_stationEvent");
            _isOnlyOnce = (bool) _isOnlyOnceProp.boolValue;
            _delay = (float) _delayProp.floatValue;
            _stationEvent = (StationEvent) _stationEventProp.intValue;

            _isOnlyOnce = EditorGUILayout.Toggle("1度のみ実行する", _isOnlyOnce);
            _delay = EditorGUILayout.FloatField("値変更の遅延時間（秒）", _delay);
            _stationEvent = (StationEvent) EditorGUILayout.EnumPopup("使用するEvent", _stationEvent);

            _isOnlyOnceProp.boolValue = _isOnlyOnce;
            _delayProp.floatValue = _delay;
            _stationEventProp.intValue = (int) _stationEvent;
            serializedObject.ApplyModifiedProperties();
            base.OnInspectorGUI();
        }
    }
}
#endif