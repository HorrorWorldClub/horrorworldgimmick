
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace Taka7n.HorrorWorldGimmick {
    public class SyncAnimatorParam : UdonSharpBehaviour
    {
        [SerializeField] private Animator _sourceAnimator;
        [SerializeField] private string _sourceParameterName;
        [SerializeField] private Animator _destAnimator;
        [SerializeField] private string _destParameterName;
        private int _sourceParameterId;
        private int _destParameterId;
        private AnimatorControllerParameter _sourceParameter;
        private AnimatorControllerParameter _destParameter;
        private AnimatorControllerParameterType _parameterType;
        private float _prevFloat;
        private int _prevInt;
        private bool _prevBool;
        private float _sourceFloat;
        private int _sourceInt;
        private bool _sourceBool;
        private float _destFloat;
        private int _destInt;
        private bool _destBool;

        void Update()
        {
            if (_parameterType == AnimatorControllerParameterType.Float)
            {
                _sourceFloat = _sourceAnimator.GetFloat(_sourceParameterId);
                _destFloat = _destAnimator.GetFloat(_destParameterId);
                if (_prevFloat != _sourceFloat)
                {
                    _destAnimator.SetFloat(_destParameterId, _sourceFloat);
                    _prevFloat = _sourceFloat;
                }
                else if (_prevFloat != _destFloat)
                {
                    _sourceAnimator.SetFloat(_sourceParameterId, _destFloat);
                    _prevFloat = _destFloat;
                }
            }
            else if (_parameterType == AnimatorControllerParameterType.Int)
            {
                _sourceInt = _sourceAnimator.GetInteger(_sourceParameterId);
                _destInt = _destAnimator.GetInteger(_destParameterId);
                if (_prevInt != _sourceInt)
                {
                    _destAnimator.SetInteger(_destParameterId, _sourceInt);
                    _prevInt = _sourceInt;
                }
                else if (_prevInt != _destInt)
                {
                    _sourceAnimator.SetInteger(_sourceParameterId, _destInt);
                    _prevInt = _destInt;
                }
            }
            else if (_parameterType == AnimatorControllerParameterType.Bool)
            {
                _sourceBool = _sourceAnimator.GetBool(_sourceParameterId);
                _destBool = _destAnimator.GetBool(_destParameterId);
                if (_prevBool != _sourceBool)
                {
                    _destAnimator.SetBool(_destParameterId, _sourceBool);
                    _prevBool = _sourceBool;
                }
                else if (_prevBool != _destBool)
                {
                    _sourceAnimator.SetBool(_sourceParameterId, _destBool);
                    _prevBool = _destBool;
                }
            }
        }
        
        void Start()
        {
            _sourceParameterId = Animator.StringToHash(_sourceParameterName);
            _destParameterId = Animator.StringToHash(_destParameterName);
            foreach (AnimatorControllerParameter _p in _sourceAnimator.parameters)
            {
                if (_p.name == _sourceParameterName) _sourceParameter = _p;
            }
            foreach (AnimatorControllerParameter _p in _destAnimator.parameters)
            {
                if (_p.name == _destParameterName) _destParameter = _p;
            }
            if (_sourceParameter.type == _destParameter.type)
            {
                _parameterType = _sourceParameter.type;
                if (_parameterType == AnimatorControllerParameterType.Float)
                {
                    _prevFloat = _sourceAnimator.GetFloat(_sourceParameterId);
                }
                if (_parameterType == AnimatorControllerParameterType.Int)
                {
                    _prevInt = _sourceAnimator.GetInteger(_sourceParameterId);
                }
                if (_parameterType == AnimatorControllerParameterType.Bool)
                {
                    _prevBool = _sourceAnimator.GetBool(_sourceParameterId);
                }
            }
        }
    }
}