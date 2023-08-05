using UdonSharp;
using UnityEngine;

namespace Taka7n.HorrorWorldGimmick {
    [AddComponentMenu("")]
    public class SetAnimatorParam : UdonSharpBehaviour
    {
        [SerializeField] protected Animator _targetAnimator;
        [SerializeField] protected string _targetParameterName;
        [SerializeField] protected float _floatValue;
        [SerializeField] protected int _intValue;
        [SerializeField] protected bool _boolValue;
        protected AnimatorControllerParameter _targetParameter;

        public void ChangeParam()
        {
            _targetParameter = null;
            foreach (AnimatorControllerParameter _acp in _targetAnimator.parameters)
            {
                if (_acp.name == _targetParameterName) _targetParameter = _acp;
            }
            if (_targetParameter == null)
            {
                Debug.Log("変更するパラメータを特定できませんでした。" + _targetParameterName);
            }
            else
            {
                switch(_targetParameter.type)
                {
                    case AnimatorControllerParameterType.Float:
                        _targetAnimator.SetFloat(_targetParameterName, _floatValue);
                        break;
                    case AnimatorControllerParameterType.Int:
                        _targetAnimator.SetInteger(_targetParameterName, _intValue);
                        break;
                    case AnimatorControllerParameterType.Bool:
                        _targetAnimator.SetBool(_targetParameterName, _boolValue);
                        break;
                    case AnimatorControllerParameterType.Trigger:
                        _targetAnimator.SetTrigger(_targetParameterName);
                        break;
                }
            }
        }
    }
}