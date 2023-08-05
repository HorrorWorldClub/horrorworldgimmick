#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace Taka7n.HorrorWorldGimmick {
    [CustomEditor(typeof(SetAnimatorParam))]
    public class SetAnimatorParamEditor : Editor
    {
        protected Animator _targetAnimator;
        protected string _targetParameterName;
        protected float _floatValue;
        protected int _intValue;
        protected bool _boolValue;
        protected string[] _animatorControllerParams;
        protected int _selectedParamId = 0;
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            var _targetAnimatorProp = serializedObject.FindProperty("_targetAnimator");
            var _targetParameterNameProp = serializedObject.FindProperty("_targetParameterName");
            var _floatValueProp = serializedObject.FindProperty("_floatValue");
            var _intValueProp = serializedObject.FindProperty("_intValue");
            var _boolValueProp = serializedObject.FindProperty("_boolValue");
            _targetAnimator = (Animator) _targetAnimatorProp.objectReferenceValue;
            _targetParameterName = (string) _targetParameterNameProp.stringValue;
            _floatValue = (float) _floatValueProp.floatValue;
            _intValue = (int) _intValueProp.intValue;
            _boolValue = (bool) _boolValueProp.boolValue;

            if (_targetAnimator != null)
            {
                _targetAnimator.enabled = !_targetAnimator.enabled;
                _targetAnimator.enabled = !_targetAnimator.enabled;
            }

            if (_targetAnimator == null) EditorGUILayout.HelpBox("パラメータを変更するAnimatorを指定してください。", MessageType.Warning);
            _targetAnimator = (Animator) EditorGUILayout.ObjectField("パラメータを変更するAnimator", _targetAnimator, typeof(Animator), true);
            if (_targetAnimator != null)
            {
                if (_targetAnimator.parameters.Length < 1)
                {
                    EditorGUILayout.HelpBox("Animatorにパラメータが存在しません。", MessageType.Warning);
                }
                else
                {
                    _animatorControllerParams = new string[_targetAnimator.parameters.Length];
                    for (int i = 0; i < _targetAnimator.parameters.Length; i++)
                    {
                        _animatorControllerParams[i] = _targetAnimator.parameters[i].name;
                        if (_targetAnimator.parameters[i].name == _targetParameterName) _selectedParamId = i;
                    }
                    if (_animatorControllerParams.Length - 1 < _selectedParamId) _selectedParamId = 0;
                    _selectedParamId = EditorGUILayout.Popup("変更するパラメータ名", _selectedParamId, _animatorControllerParams);
                    _targetParameterName = _animatorControllerParams[_selectedParamId];
                    switch(_targetAnimator.parameters[_selectedParamId].type)
                    {
                        case AnimatorControllerParameterType.Float:
                            _floatValue = EditorGUILayout.FloatField("セットする値", _floatValue);
                            break;
                        case AnimatorControllerParameterType.Int:
                            _intValue = EditorGUILayout.IntField("セットする値", _intValue);
                            break;
                        case AnimatorControllerParameterType.Bool:
                            _boolValue = EditorGUILayout.Toggle("セットする値", _boolValue);
                            break;
                    }
                }
            }
            _targetAnimatorProp.objectReferenceValue = _targetAnimator;
            _targetParameterNameProp.stringValue = _targetParameterName;
            _floatValueProp.floatValue = _floatValue;
            _intValueProp.intValue = _intValue;
            _boolValueProp.boolValue = _boolValue;
            serializedObject.ApplyModifiedProperties();
        }
    }
}
#endif