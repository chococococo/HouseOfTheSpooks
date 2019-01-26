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
        Debug.Log("DoDash");
        currentDir = direction;
        doDash = true;
        dashTmr = 0f;
        coll.enabled = true;
    }

    // Update is called once per frame
    private void Update() {
        // Debug.Log(doDash + " inpout " + Input.GetKeyDown(KeyCode.Space));
        if (Input.GetKeyDown(KeyCode.Z)) {
            Debug.Log("askljaspd");
        }
        if (doDash) {
            if (dashTmr < dashTime) {
                dashTmr += Time.deltaTime;
                if (!ghost.IsPossessing()) {
                    rb.MovePosition(transform.position + currentDir * Time.deltaTime * dashMultiplier);
                }
            }
            else {
                coll.enabled = false;
                doDash = false;
            }
        }
        else {


            if (Input.GetKeyDown(KeyCode.Z)) {
                Dash(ghost.GetNextDir());
            }
        }


    }
}
