#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using VRC.SDKBase;

namespace Taka7n.HorrorWorldGimmick {
    [CustomEditor(typeof(PlayerFollower))]
    public class PlayerFollowerEditor : Editor
    {
        private VRCPlayerApi.TrackingDataType _trackingDataType;
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            var _trackingDataTypeProp = serializedObject.FindProperty("_trackingDataType");
            _trackingDataType = (VRCPlayerApi.TrackingDataType) _trackingDataTypeProp.intValue;
            _trackingDataType = (VRCPlayerApi.TrackingDataType) EditorGUILayout.EnumPopup("追従する位置", _trackingDataType);

            _trackingDataTypeProp.intValue = (int) _trackingDataType;
            serializedObject.ApplyModifiedProperties();
        }
    }
}
#endif