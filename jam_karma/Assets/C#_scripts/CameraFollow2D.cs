using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    public Transform target; 
    public float smoothTime = 0.3f; 
    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        if (target != null)
        {
            
            Vector3 currentPosition = transform.position;

            
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, currentPosition.z);

            
            transform.position = Vector3.SmoothDamp(currentPosition, targetPosition, ref velocity, smoothTime);
        }
    }
}
