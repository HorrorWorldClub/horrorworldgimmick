#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using VRC.SDKBase;

namespace Taka7n.HorrorWorldGimmick {
    [CustomEditor(typeof(PlayerController))]
    public class PlayerControllerEditor : Editor
    {
        private PlayerControllerBase _playerControllerBase;
        private Transform _teleportPoint;

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            var _playerControllerBaseProp = serializedObject.FindProperty("_playerControllerBase");
            var _teleportPointProp = serializedObject.FindProperty("_teleportPoint");
            _playerControllerBase = (PlayerControllerBase) _playerControllerBaseProp.objectReferenceValue;
            _teleportPoint = (Transform) _teleportPointProp.objectReferenceValue;
            _playerControllerBase = (PlayerControllerBase) EditorGUILayout.ObjectField("Player Controller Base", _playerControllerBase, typeof(PlayerControllerBase), true);
            EditorGUILayout.HelpBox("テレポートを使用しない場合、テレポート先の指定は不要です。", MessageType.Info);
            _teleportPoint = (Transform) EditorGUILayout.ObjectField("テレポート先", _teleportPoint, typeof(Transform), true);
            _playerControllerBaseProp.objectReferenceValue = _playerControllerBase;
            _teleportPointProp.objectReferenceValue = _teleportPoint;
            serializedObject.ApplyModifiedProperties();
        }
    }
}
#endif