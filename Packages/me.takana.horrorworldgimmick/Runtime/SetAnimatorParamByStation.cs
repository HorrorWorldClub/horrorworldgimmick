
using UnityEngine;
using VRC.Udon.Common.Enums;
using VRC.SDKBase;
using VRC.Udon;

namespace Taka7n.HorrorWorldGimmick {
    public enum StationEvent
    {
        OnStationEntered,
        OnStationExited,
    }
    public class SetAnimatorParamByStation : SetAnimatorParam
    {
        [SerializeField] private bool _isOnlyOnce;
        [SerializeField] private float _delay;
        [SerializeField] private StationEvent _stationEvent;
        private bool _isAlreadyRun = false;

        public override void OnStationEntered(VRCPlayerApi player)
        {
            if (player.isLocal && _stationEvent == StationEvent.OnStationEntered && (!_isOnlyOnce || !_isAlreadyRun))
            {
                _isAlreadyRun = true;
                SendCustomEventDelayedSeconds(nameof(ChangeParam), _delay, EventTiming.Update);
            }
        }

        public override void OnStationExited(VRCPlayerApi player)
        {
            if (player.isLocal && _stationEvent == StationEvent.OnStationExited && (!_isOnlyOnce || !_isAlreadyRun))
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