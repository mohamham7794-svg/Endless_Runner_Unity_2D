using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField]Vector3 cameraVelocity;
    [SerializeField] float smoothTime=0.5f;
    [SerializeField] bool lookAtPlayer;



    void Update()
    {
        Vector3 targetPostion = new Vector3(player.position.x, player.position.y 
        ,transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPostion, 
        ref cameraVelocity, smoothTime);
        if (lookAtPlayer== true)
        {
            transform.LookAt(player);
        }
    }
}
