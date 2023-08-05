
using UnityEngine;
using VRC.Udon.Common.Enums;
using VRC.SDKBase;
using VRC.Udon;

namespace Taka7n.HorrorWorldGimmick {
    public enum PickUpEvent
    {
        OnDrop,
        OnPickup,
        OnPickupUseDown,
        OnPickupUseUp,
    }
    public class SetAnimatorParamByPickUp : SetAnimatorParam
    {
        [SerializeField] private bool _isOnlyOnce;
        [SerializeField] private float _delay;
        [SerializeField] private PickUpEvent _pickUpEvent;
        private bool _isAlreadyRun = false;

        public override void OnDrop()
        {
            if (_pickUpEvent == PickUpEvent.OnDrop && (!_isOnlyOnce || !_isAlreadyRun))
            {
                _isAlreadyRun = true;
                SendCustomEventDelayedSeconds(nameof(ChangeParam), _delay, EventTiming.Update);
            }
        }

        public override void OnPickup()
        {
            if (_pickUpEvent == PickUpEvent.OnPickup && (!_isOnlyOnce || !_isAlreadyRun))
            {
                _isAlreadyRun = true;
                SendCustomEventDelayedSeconds(nameof(ChangeParam), _delay, EventTiming.Update);
            }
        }

        public override void OnPickupUseDown()
        {
            if (_pickUpEvent == PickUpEvent.OnPickupUseDown && (!_isOnlyOnce || !_isAlreadyRun))
            {
                _isAlreadyRun = true;
                SendCustomEventDelayedSeconds(nameof(ChangeParam), _delay, EventTiming.Update);
            }
        }

        public override void OnPickupUseUp()
        {
            if (_pickUpEvent == PickUpEvent.OnPickupUseUp && (!_isOnlyOnce || !_isAlreadyRun))
            {
                _isAlreadyRun = true;
                SendCustomEventDelayedSeconds(nameof(ChangeParam), _delay, EventTiming.Update);
            }
        }

        public void ResetOnlyOnce()
        {
            _isAlreadyRun = false;
        }
    }
}