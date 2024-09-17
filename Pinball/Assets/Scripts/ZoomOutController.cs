using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomOutController : MonoBehaviour
{
    public CameraController cameraController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            cameraController.GoBackToDefault();
        }
    }
}
