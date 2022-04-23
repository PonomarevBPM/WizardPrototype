using UnityEngine;


namespace Wizard2D
{ 
    public class FollowCamera : MonoBehaviour
    {
        public Transform target;
        public Vector3 offset;
        [Range(1, 10)]
        public float smoothFactor;

        private void FixedUpdate()
        {
            Follow();
        }
        void Follow()
        {
            Vector3 targetPosition = target.position + offset;
            Vector3 boundPosition = new Vector3(
            targetPosition.x, 
            Mathf.Clamp(targetPosition.y,-1000,5f),
            targetPosition.z);

            Vector3 smoothPosition = Vector3.Lerp(transform.position, boundPosition, smoothFactor * Time.fixedDeltaTime);
            transform.position = smoothPosition;
        }
    }
}
