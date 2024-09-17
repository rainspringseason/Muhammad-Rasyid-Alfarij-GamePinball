using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherController : MonoBehaviour
{
    public Color colorPress;
    public Color colorRelease;

    public KeyCode input;
    public float maxTimeHold;
    public float maxForce;

    private Renderer colorRenderer;
    private bool isHold;

    private void Start()
    {
        colorRenderer = GetComponent<Renderer>();

        isHold = false;
        colorRenderer.material.color = colorRelease;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            ReadInput(collision.collider);
        }
    }

    private void ReadInput(Collider collider)
    {
        if (Input.GetKey(input) && !isHold)
        {
            StartCoroutine(StartHold(collider));
        }
    }

    private IEnumerator StartHold(Collider collider)
    {
        isHold = true;
        colorRenderer.material.color = colorPress;

        float force = 0.0f;
        float timeHold = 0.0f;

        while (Input.GetKey(input))
        {
            force = Mathf.Lerp(0, maxForce, timeHold / maxTimeHold);

            yield return new WaitForEndOfFrame();
            timeHold += Time.deltaTime;
        }

        collider.GetComponent<Rigidbody>().AddForce(Vector3.forward * force);
        isHold = false;
        colorRenderer.material.color = colorRelease;
    }
}
