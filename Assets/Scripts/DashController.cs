using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashController : MonoBehaviour {
    public float dashSpeed = 5f;
    public float dashTime = 0.14f;
    public float cooldown = 0.07f;
    float cool;

    public GameObject model;

    float dashMultiplier;
    GhostController ghost;
    GhostCombo combo;
    BoxCollider coll;

    Vector3 currentDir;
    float dashTmr;

    GameObject fxHolder;
    public bool doDash;
    Rigidbody rb;
    bool afterDash;
    bool doCool;
    FX fx;

    // Use this for initialization
    void Start() {
        dashMultiplier = 1f;
        cool = 0f;
        doDash = false;
        dashTmr = 0f;
        doCool = false;
        afterDash = false;
        ghost = GetComponent<GhostController>();
        rb = GetComponent<Rigidbody>();
        combo = GetComponent<GhostCombo>();
        fxHolder = transform.Find("Dash").gameObject;
        fx = fxHolder.GetComponent<FX>();
        coll = transform.GetChild(0).gameObject.GetComponent<BoxCollider>();
    }


    public bool IsDashing() {
        return doDash;
    }

    public void Dash(GhostController.Direction direction) {
        currentDir = direction.vec;
        dashMultiplier = direction.diag ? .8f : 1f;
        doDash = true;
        ghost.GetModel().SetActive(true);
        dashTmr = 0f;
        coll.enabled = true;
        fx.PlayParticles();
        fx.PlayRandomClip();
        model.SetActive(false);
        fxHolder.transform.GetChild(0).gameObject.SetActive(true); //Feo feo tbh
        combo.StartDash(); //Me encantaria hacerlo con eventos :(
    }

    public void Stop() {
        rb.velocity = Vector3.zero;
        model.SetActive(true);
        fxHolder.transform.GetChild(0).gameObject.SetActive(false); //Feo feo tbh
        Debug.Log("new vel " + rb.velocity);
        //rb.velocity = currentDir;
        doDash = false;
        coll.enabled = false;
        afterDash = false;

        combo.FinishDash(); //Me encantaria hacerlo con eventos :(
    }

    // Update is called once per frame
    private void Update() {
        if (doCool) {
            cool += Time.deltaTime;
            if (cool >= cooldown) {
                doCool = false;
                cool = 0f;
            }
        } else {
            if (doDash) {
                if (dashTmr < dashTime) {
                    dashTmr += Time.deltaTime;
                    //Debug.Log(rb.velocity);
                    if (!afterDash) {
                        rb.AddForce(currentDir * dashSpeed * dashMultiplier, ForceMode.Impulse);
                        afterDash = true;
                        doCool = true;
                    }
                } else {
                    Stop();
                }
            } else {
                if (Input.GetKeyDown(KeyCode.Z)) {
                    Dash(ghost.GetNextDir());
                }
            }


        }

    }
}
