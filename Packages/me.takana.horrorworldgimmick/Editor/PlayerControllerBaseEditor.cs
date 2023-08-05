#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using VRC.SDKBase;

namespace Taka7n.HorrorWorldGimmick {
    [CustomEditor(typeof(PlayerControllerBase))]
    public class PlayerControllerBaseEditor : Editor
    {
        private float _jumpHeight;
        private float _runSpeed;
        private float _walkSpeed;
        private float _strafeSpeed;
        private float _gravity;
        private float _voiceDistanceFar;

        public override void OnInspectorGUI()
        {
            EditorGUILayout.HelpBox("このコンポーネントはSceneに1つのみ設置してください。", MessageType.Warning);
            serializedObject.Update();
            var _jumpHeightProp = serializedObject.FindProperty("_jumpHeight");
            var _runSpeedProp = serializedObject.FindProperty("_runSpeed");
            var _walkSpeedProp = serializedObject.FindProperty("_walkSpeed");
            var _strafeSpeedProp = serializedObject.FindProperty("_strafeSpeed");
            var _gravityProp = serializedObject.FindProperty("_gravity");
            var _voiceDistanceFarProp = serializedObject.FindProperty("_voiceDistanceFar");
            _jumpHeight = (float) _jumpHeightProp.floatValue;
            _runSpeed = (float) _runSpeedProp.floatValue;
            _walkSpeed = (float) _walkSpeedProp.floatValue;
            _strafeSpeed = (float) _strafeSpeedProp.floatValue;
            _gravity = (float) _gravityProp.floatValue;
            _voiceDistanceFar = (float) _voiceDistanceFarProp.floatValue;
            _jumpHeight = (float) EditorGUILayout.FloatField("ジャンプ高さ", _jumpHeight);
            _runSpeed = (float) EditorGUILayout.FloatField("走る速度", _runSpeed);
            _walkSpeed = (float) EditorGUILayout.FloatField("歩く速度", _walkSpeed);
            _strafeSpeed = (float) EditorGUILayout.FloatField("伏せ速度", _strafeSpeed);
            _gravity = (float) EditorGUILayout.FloatField("重力", _gravity);
            _voiceDistanceFar = (float) EditorGUILayout.FloatField("声の減衰距離", _voiceDistanceFar);
            _jumpHeightProp.floatValue = _jumpHeight;
            _runSpeedProp.floatValue = _runSpeed;
            _walkSpeedProp.floatValue = _walkSpeed;
            _strafeSpeedProp.floatValue = _strafeSpeed;
            _gravityProp.floatValue = _gravity;
            _voiceDistanceFarProp.floatValue = _voiceDistanceFar;
            serializedObject.ApplyModifiedProperties();
        }
    }
}
#endif