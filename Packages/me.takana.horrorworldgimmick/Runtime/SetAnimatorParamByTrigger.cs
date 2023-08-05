using UnityEngine;
using VRC.Udon.Common.Enums;

namespace Taka7n.HorrorWorldGimmick {
    public enum TriggerEvent
    {
        OnTriggerEnter,
        OnTriggerExit,
        OnTriggerStay,
    }
    public class SetAnimatorParamByTrigger : SetAnimatorParam
    {
        [SerializeField] private Collider _targetCollider;
        [SerializeField] private bool _isOnlyOnce;
        [SerializeField] private float _delay;
        [SerializeField] private TriggerEvent _triggerEvent;
        private bool _isAlreadyRun = false;

        void OnTriggerEnter(Collider other)
        {
            if (_triggerEvent == TriggerEvent.OnTriggerEnter && other == _targetCollider && (!_isOnlyOnce || !_isAlreadyRun))
            {
                SendCustomEventDelayedSeconds(nameof(ChangeParam), _delay, EventTiming.Update);
                _isAlreadyRun = true;
            }
        }

        void OnTriggerExit(Collider other)
        {
            if (_triggerEvent == TriggerEvent.OnTriggerExit && other == _targetCollider && (!_isOnlyOnce || !_isAlreadyRun))
            {
                SendCustomEventDelayedSeconds(nameof(ChangeParam), _delay, EventTiming.Update);
                _isAlreadyRun = true;
            }
        }

        void OnTriggerStay(Collider other)
        {
            if (_triggerEvent == TriggerEvent.OnTriggerStay && other == _targetCollider && (!_isOnlyOnce || !_isAlreadyRun))
            {
                SendCustomEventDelayedSeconds(nameof(ChangeParam), _delay, EventTiming.Update);
                _isAlreadyRun = true;
            }
        }

        public void ResetOnlyOnce()
        {
            _isAlreadyRun = false;
        }
    }
}