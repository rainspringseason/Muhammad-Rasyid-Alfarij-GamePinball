using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomInController : MonoBehaviour
{
    public CameraController cameraController;
    public float length;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            cameraController.FollowTarget(other.transform, length);
        }
    }
}
