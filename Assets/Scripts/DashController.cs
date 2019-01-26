using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashController : MonoBehaviour {
    public float dashMultiplier = 5f;
    public float dashTime = 0.5f;
    GhostController ghost;
    SphereCollider coll;

    Vector3 currentDir;
    float dashTmr;

    public bool doDash;
    Rigidbody rb;

    // Use this for initialization
    void Start() {
        doDash = false;
        dashTmr = 0f;
        ghost = GetComponent<GhostController>();
        rb = GetComponent<Rigidbody>();
        coll = transform.GetChild(0).gameObject.GetComponent<SphereCollider>();
    }


    public bool IsDashing() {
        return doDash;
    }

    public void Dash(Vector3 direction) {
        Debug.Log("Do Dash " + direction);
        currentDir = direction;
        doDash = true;
        ghost.GetModel().SetActive(true);
        dashTmr = 0f;
        coll.enabled = true;
    }

    public void Stop() {
        doDash = false;
        coll.enabled = false;
    }

    // Update is called once per frame
    private void Update() {
        if (doDash) {
            if (dashTmr < dashTime) {
                dashTmr += Time.deltaTime;
                rb.MovePosition(transform.position + currentDir * Time.deltaTime * dashMultiplier);
            }
            else {
                Stop();
            }
        }
        else {
            if (Input.GetKeyDown(KeyCode.Z)) {
                Dash(ghost.GetNextDir());
            }
        }


    }
}
