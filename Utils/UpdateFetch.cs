using UnityEngine;

namespace AvatarConnect
{
    public class AvatarConnectUpdateFetch : MonoBehaviour
    {
        public ACAvatar Avatar;

        public void FixedUpdate()
        {
            Avatar.Tick();
        }
    }
}