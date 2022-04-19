// AvatarConnect Character
using UnityEngine;

namespace AvatarConnect
{
    // Base class for module avatar
    public class ACAvatar
    {
        // Avatar object
        public GameObject AvatarObject;

        // Animation
        public Animator Animator;
        public AvatarEyeManager EyeManager;

        // Avatar activation
        public virtual void Activate()
        {
            EyeManager = new AvatarEyeManager();
        }

        // Fixed update
        public virtual void Tick() { }
    }
}