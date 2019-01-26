using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour {
    public float speed = 2f;


    DashController dash;
    GhostController ghost;
    Rigidbody rb;
    // Use this for initialization
    void Start() {
        dash = GetComponent<DashController>();
        ghost = GetComponent<GhostController>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        Vector3 dir = Vector3.zero;
        if (!dash.IsDashing()) {
            dir = ghost.GetNextDir();
            if (dir != Vector3.zero) {
                rb.MovePosition(transform.position + dir * Time.deltaTime * speed);
            }
        }
    }
}
