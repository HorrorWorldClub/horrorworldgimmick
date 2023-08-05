
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using VRC.Udon.Common.Enums;

namespace Taka7n.HorrorWorldGimmick {
    public class PlayerController : UdonSharpBehaviour
    {
        [SerializeField] private PlayerControllerBase _playerControllerBase;
        [SerializeField] private Transform _teleportPoint;

        public void SetSpeed1x()
        {
            _playerControllerBase.SendCustomEvent("SetSpeed1x");
        }

        public void SetSpeed2x()
        {
            _playerControllerBase.SendCustomEvent("SetSpeed2x");
        }

        public void SetSpeed0_5x()
        {
            _playerControllerBase.SendCustomEvent("SetSpeed0_5x");
        }

        public void SetSpeed0_3x()
        {
            _playerControllerBase.SendCustomEvent("SetSpeed0_3x");
        }

        public void Immobilize()
        {
            _playerControllerBase.SendCustomEvent("Immobilize");
        }

        public void Mobilize()
        {
            _playerControllerBase.SendCustomEvent("Mobilize");
        }

        public void MuteOtherPlayers()
        {
            _playerControllerBase.SendCustomEvent("MuteOtherPlayers");
        }

        public void UnMuteOtherPlayers()
        {
            _playerControllerBase.SendCustomEvent("UnMuteOtherPlayers");
        }

        private void TeleportRun()
        {
            if (_teleportPoint != null)
            {
                Networking.LocalPlayer.TeleportTo(_teleportPoint.position, _teleportPoint.rotation);
            }
        }

        public void Teleport()
        {
            SendCustomEventDelayedFrames(nameof(TeleportRun), 1, EventTiming.Update);
        }
    }
}