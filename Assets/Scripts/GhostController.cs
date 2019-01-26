using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour {
    public Vector3 teleportPoint;
    public Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 nextPos = Vector3.zero;
        if (Input.GetKey(KeyCode.UpArrow)) {
            nextPos += transform.forward;
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            nextPos -= transform.forward;
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            nextPos += transform.right;
        }
        if (Input.GetKey(KeyCode.LeftArrow)) {
            nextPos -= transform.right;
        }
        rb.MovePosition(transform.position + nextPos * Time.deltaTime);
    }
}
