using UnityEngine;
using VRC.Udon.Common.Enums;
using VRC.SDKBase;

namespace Taka7n.HorrorWorldGimmick {
    public enum PlayerTriggerEvent
    {
        OnPlayerTriggerEnter,
        OnPlayerTriggerExit,
        OnPlayerTriggerStay,
    }
    public class SetAnimatorParamByPlayerTrigger : SetAnimatorParam
    {
        [SerializeField] private Collider _targetCollider;
        [SerializeField] private bool _isOnlyOnce;
        [SerializeField] private float _delay;
        [SerializeField] private PlayerTriggerEvent _playerTriggerEvent;
        private bool _isAlreadyRun = false;

        public override void OnPlayerTriggerEnter(VRCPlayerApi player)
        {
            if (_playerTriggerEvent == PlayerTriggerEvent.OnPlayerTriggerEnter && player.isLocal && (!_isOnlyOnce || !_isAlreadyRun))
            {
                SendCustomEventDelayedSeconds(nameof(ChangeParam), _delay, EventTiming.Update);
                _isAlreadyRun = true;
            }
        }

        public override void OnPlayerTriggerExit(VRCPlayerApi player)
        {
            if (_playerTriggerEvent == PlayerTriggerEvent.OnPlayerTriggerExit && player.isLocal && (!_isOnlyOnce || !_isAlreadyRun))
            {
                SendCustomEventDelayedSeconds(nameof(ChangeParam), _delay, EventTiming.Update);
                _isAlreadyRun = true;
            }
        }

        public override void OnPlayerTriggerStay(VRCPlayerApi player)
        {
            if (_playerTriggerEvent == PlayerTriggerEvent.OnPlayerTriggerStay && player.isLocal && (!_isOnlyOnce || !_isAlreadyRun))
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