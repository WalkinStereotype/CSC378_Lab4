using UnityEngine;

public class CameraScript : MonoBehaviour
{

    // This code is from "https://gamedevbeginner.com/how-to-follow-the-player-with-a-camera-in-unity-with-or-without-cinemachine/"
    public Transform target;
public Vector3 offset = new Vector3(0, 2, -10);
public float smoothTime = 0.25f;

Vector3 currentVelocity;

private void LateUpdate()
{
    transform.position = Vector3.SmoothDamp(
        transform.position, 
        target.position + offset, 
        ref currentVelocity, 
        smoothTime
        );
}
}
