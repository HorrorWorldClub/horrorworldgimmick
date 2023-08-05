
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace Taka7n.HorrorWorldGimmick {
    public class PlayerControllerBase : UdonSharpBehaviour
    {
        [SerializeField] private float _jumpHeight = 3f;
        [SerializeField] private float _runSpeed = 4f;
        [SerializeField] private float _walkSpeed = 2f;
        [SerializeField] private float _strafeSpeed = 2f;
        [SerializeField] private float _gravity = 1f;
        [SerializeField] private float _voiceDistanceFar = 25f;

        private VRCPlayerApi _player;
        private VRCPlayerApi[] _players;

        public void SetSpeed1x()
        {
            _player.Immobilize(false);
            SetSpeed(1f);
        }

        public void SetSpeed2x()
        {
            _player.Immobilize(false);
            SetSpeed(2f);
        }

        public void SetSpeed0_5x()
        {
            _player.Immobilize(false);
            SetSpeed(0.5f);
        }

        public void SetSpeed0_3x()
        {
            _player.Immobilize(false);
            SetSpeed(0.3f);
        }

        public void Immobilize()
        {
            _player.Immobilize(true);
        }

        public void Mobilize()
        {
            _player.Immobilize(false);
        }

        private void SetSpeed(float magnification)
        {
            _player.SetJumpImpulse(_jumpHeight*magnification);
            _player.SetRunSpeed(_runSpeed*magnification);
            _player.SetWalkSpeed(_walkSpeed*magnification);
            _player.SetStrafeSpeed(_strafeSpeed*magnification);
        }

        public void MuteOtherPlayers()
        {
            _players = new VRCPlayerApi[VRCPlayerApi.GetPlayerCount()];
            VRCPlayerApi.GetPlayers(_players);
            foreach(VRCPlayerApi _p in _players) {
                if (_p != null && !_p.isLocal) _p.SetVoiceDistanceFar(0f);
            }
        }

        public void UnMuteOtherPlayers()
        {
            _players = new VRCPlayerApi[VRCPlayerApi.GetPlayerCount()];
            VRCPlayerApi.GetPlayers(_players);
            foreach(VRCPlayerApi _p in _players) {
                if (_p != null && !_p.isLocal) _p.SetVoiceDistanceFar(_voiceDistanceFar);
            }
        }

        void Start()
        {
            _player = Networking.LocalPlayer;
            _player.SetGravityStrength(_gravity);
            SetSpeed(1f);
            _player.Immobilize(false);
        }
    }
}