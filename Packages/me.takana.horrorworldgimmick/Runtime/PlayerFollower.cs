using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace Taka7n.HorrorWorldGimmick {
    public class PlayerFollower : UdonSharpBehaviour
    {
        [SerializeField] private VRCPlayerApi.TrackingDataType _trackingDataType;
        private Transform _transform;
        private VRCPlayerApi _player;
        private VRCPlayerApi.TrackingData _trackingData;

        void Update()
        {
            _trackingData = _player.GetTrackingData(_trackingDataType);
            _transform.position = _trackingData.position;
            _transform.rotation = _trackingData.rotation;
        }

        void Start()
        {
            _transform = this.gameObject.transform;
            _player = Networking.LocalPlayer;
        }
    }
}