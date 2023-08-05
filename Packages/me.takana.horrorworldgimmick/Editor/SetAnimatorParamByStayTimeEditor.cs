#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace Taka7n.HorrorWorldGimmick {
    [CustomEditor(typeof(SetAnimatorParamByStayTime))]
    public class SetAnimatorParamByStayTimeEditor : SetAnimatorParamEditor
    {
        private float _triggerTime;
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            var _triggerTimeProp = serializedObject.FindProperty("_triggerTime");
            _triggerTime = (float) _triggerTimeProp.floatValue;

            _triggerTime = EditorGUILayout.FloatField("Join後何秒後に変更するか", _triggerTime);

            _triggerTimeProp.floatValue = _triggerTime;
            serializedObject.ApplyModifiedProperties();
            base.OnInspectorGUI();
        }
    }
}
#endif