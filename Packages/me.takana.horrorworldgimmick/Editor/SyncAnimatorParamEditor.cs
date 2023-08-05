#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace Taka7n.HorrorWorldGimmick {
    [CustomEditor(typeof(SyncAnimatorParam))]
    public class SyncAnimatorParamEditor : Editor
    {
        private Animator _sourceAnimator;
        private string _sourceParameterName;
        private Animator _destAnimator;
        private string _destParameterName;
        private int _selectedSourceParamId;
        private int _selectedDestParamId;


        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            var _sourceAnimatorProp = serializedObject.FindProperty("_sourceAnimator");
            var _destAnimatorProp = serializedObject.FindProperty("_destAnimator");
            var _sourceParameterNameProp = serializedObject.FindProperty("_sourceParameterName");
            var _destParameterNameProp = serializedObject.FindProperty("_destParameterName");

            _sourceAnimator = (Animator) _sourceAnimatorProp.objectReferenceValue;
            _destAnimator = (Animator) _destAnimatorProp.objectReferenceValue;
            _sourceParameterName = (string) _sourceParameterNameProp.stringValue;
            _destParameterName = (string) _destParameterNameProp.stringValue;

            if (_sourceAnimator != null)
            {
                _sourceAnimator.enabled = !_sourceAnimator.enabled;
                _sourceAnimator.enabled = !_sourceAnimator.enabled;
            }
            if (_destAnimator != null)
            {
                _destAnimator.enabled = !_destAnimator.enabled;
                _destAnimator.enabled = !_destAnimator.enabled;
            }

            if (_sourceAnimator == null) EditorGUILayout.HelpBox("同期元のAnimatorを指定してください。", MessageType.Warning);
            _sourceAnimator = (Animator) EditorGUILayout.ObjectField("同期元のAnimator", _sourceAnimator, typeof(Animator), true);

            if (_sourceAnimator != null)
            {
                if (_sourceAnimator.parameters.Length < 1)
                {
                    EditorGUILayout.HelpBox("Animatorにパラメータが存在しません。", MessageType.Warning);
                }
                else
                {
                    var _sourceAnimatorControllerParams = new string[_sourceAnimator.parameters.Length];
                    for (int i = 0; i < _sourceAnimator.parameters.Length; i++)
                    {
                        _sourceAnimatorControllerParams[i] = _sourceAnimator.parameters[i].name;
                        if (_sourceAnimator.parameters[i].name == _sourceParameterName) _selectedSourceParamId = i;
                    }
                    if (_sourceAnimatorControllerParams.Length - 1 < _selectedSourceParamId) _selectedSourceParamId = 0;
                    _selectedSourceParamId = EditorGUILayout.Popup("同期元パラメータ名", _selectedSourceParamId, _sourceAnimatorControllerParams);
                    _sourceParameterName = _sourceAnimatorControllerParams[_selectedSourceParamId];
                }
            }
            if (_destAnimator == null) EditorGUILayout.HelpBox("同期先のAnimatorを指定してください。", MessageType.Warning);
            _destAnimator = (Animator) EditorGUILayout.ObjectField("同期先のAnimator", _destAnimator, typeof(Animator), true);
            if (_destAnimator != null)
            {
                if (_destAnimator.parameters.Length < 1)
                {
                    EditorGUILayout.HelpBox("Animatorにパラメータが存在しません。", MessageType.Warning);
                }
                else
                {
                    var _destAnimatorControllerParams = new string[_destAnimator.parameters.Length];
                    for (int i = 0; i < _destAnimator.parameters.Length; i++)
                    {
                        _destAnimatorControllerParams[i] = _destAnimator.parameters[i].name;
                        if (_destAnimator.parameters[i].name == _destParameterName) _selectedDestParamId = i;
                    }
                    if (_destAnimatorControllerParams.Length - 1 < _selectedDestParamId) _selectedDestParamId = 0;
                    _selectedDestParamId = EditorGUILayout.Popup("同期元パラメータ名", _selectedDestParamId, _destAnimatorControllerParams);
                    _destParameterName = _destAnimatorControllerParams[_selectedDestParamId];
                }
            }
            _sourceAnimatorProp.objectReferenceValue = _sourceAnimator;
            _destAnimatorProp.objectReferenceValue = _destAnimator;
            _sourceParameterNameProp.stringValue = _sourceParameterName;
            _destParameterNameProp.stringValue = _destParameterName;
            serializedObject.ApplyModifiedProperties();
        }
    }
}
#endif