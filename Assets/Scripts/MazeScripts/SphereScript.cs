using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _camera;

    private Rigidbody body;
    private float forceFactor = 400f;

    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float kh = Input.GetAxis("Horizontal");
        float kv = Input.GetAxis("Vertical");

        Vector3 right = _camera.transform.right;
        Vector3 forward = _camera.transform.forward;
        forward.y = 0;
        forward = forward.normalized;


        Vector3 forceDirection = //new Vector3(kh, 0, kv); - World space
            kh * right + kv * forward;

        forceDirection=forceDirection.normalized;

        body.AddForce(forceFactor * Time.deltaTime * forceDirection);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("SphereScript: " + other.name);
    }
}
