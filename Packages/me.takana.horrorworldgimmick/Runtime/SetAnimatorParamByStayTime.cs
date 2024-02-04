using UnityEngine;
using VRC.Udon.Common.Enums;
using VRC.SDKBase;

namespace Taka7n.HorrorWorldGimmick {
    public class SetAnimatorParamByStayTime : SetAnimatorParam
    {
        [SerializeField] private float _triggerTime;
        private double _startTime;
        private bool _isAlreadyRun = false;

        void Update()
        {
            if (!_isAlreadyRun && Networking.CalculateServerDeltaTime(Networking.GetServerTimeInSeconds(), _startTime) > _triggerTime)
            {
                _isAlreadyRun = true;
                ChangeParam();
            }
        }
        void Start()
        {
            _startTime = Networking.GetServerTimeInSeconds();
        }
    }
}