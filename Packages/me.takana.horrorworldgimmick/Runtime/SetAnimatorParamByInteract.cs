
using UnityEngine;
using VRC.Udon.Common.Enums;
using VRC.SDKBase;
using VRC.Udon;

namespace Taka7n.HorrorWorldGimmick {
    public class SetAnimatorParamByInteract : SetAnimatorParam
    {
        [SerializeField] private bool _isOnlyOnce;
        [SerializeField] private float _delay;
        [SerializeField] private string _interactionText;
        private bool _isAlreadyRun = false;

        public void EnableInteraction()
        {
            DisableInteractive = false;
        }

        public void DisableInteraction()
        {
            DisableInteractive = true;
        }

        public override void Interact()
        {
            if (!_isOnlyOnce || !_isAlreadyRun)
            {
                _isAlreadyRun = true;
                SendCustomEventDelayedSeconds(nameof(ChangeParam), _delay, EventTiming.Update);
            }
        }

        void Start()
        {
            InteractionText = _interactionText;
        }

        public void ResetOnlyOnce()
        {
            _isAlreadyRun = false;
        }
    }
}