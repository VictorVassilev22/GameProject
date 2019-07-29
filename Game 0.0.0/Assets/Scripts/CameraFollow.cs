
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed;
    public Vector3 offset;
    void FixedUpdate()
    {
        Vector3 desiredPosition;
        if (player.position.x>6.3f)
        {
            if (player.position.y > 5.2f)
            {
                desiredPosition = new Vector3(6.3f, 5.2f, player.position.z) + offset;
            }
            else if (player.position.y < -3.7f)
            {
                desiredPosition = new Vector3(6.3f, -3.7f, player.position.z) + offset;
            }
            else
                desiredPosition = new Vector3(6.3f, player.position.y, player.position.z) + offset;
        }
        else if (player.position.x < -6f)
        {
            if (player.position.y > 5.2f)
            {
                desiredPosition = new Vector3(-6f, 5.2f, player.position.z) + offset;
            }
            else if (player.position.y < -3.7f)
            {
                desiredPosition = new Vector3(-6f, -3.7f, player.position.z) + offset;
            }
            else
                desiredPosition = new Vector3(-6f, player.position.y, player.position.z) + offset;
        }
        else if (player.position.y > 5.2f)
        {
            if (player.position.x > 6.3f)
            {
                desiredPosition = new Vector3(6.3f, 5.2f, player.position.z) + offset;
            }
            else if (player.position.x < -6f)
            {
                desiredPosition = new Vector3(-6f, 5.2f, player.position.z) + offset;
            }
            else
                desiredPosition = new Vector3(player.position.x, 5.2f, player.position.z) + offset;
        }
        else if (player.position.y < -3.7f)
        {
            if (player.position.x > 6.3f)
            {
                desiredPosition = new Vector3(6.3f, -3.7f, player.position.z) + offset;
            }
            else if (player.position.x < -6f)
            {
                desiredPosition = new Vector3(-6f, -3.7f, player.position.z) + offset;
            }
            else
                desiredPosition = new Vector3(player.position.x, -3.7f, player.position.z) + offset;
        }
        else
        {
             desiredPosition = player.position + offset;
        }

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
       
    }

}
