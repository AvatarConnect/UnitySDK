using UnityEngine;

namespace AvatarConnect
{
    public class AvatarEyeManager
    {
        // Max rotation from the center of the eye
        public float MaxEyeAngle = 30.0f;

        // How fast the eye rotates
        public float MaxLookSpeed = 0.1f;

        // If the character will gaze at the camera randomly
        public bool CameraAware = true;

        // If the character will look randomly around
        public bool RandomGaze = true;

        // Add a tiny bit of jitter to simulate a more natural looking eye movement
        public bool MicroJidder = true;

        // If the character will blink randomly
        public bool Blinks = true;

        // The eye lid closing speed
        public float BinkSpeed = 0.5f;

        // The eye lid pause time
        public float BlinkPause = 0.5f;

        // Rotate the head randomly
        public bool RotateHead = true;
    }
}