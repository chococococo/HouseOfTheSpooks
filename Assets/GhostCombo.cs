﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostCombo : MonoBehaviour {
    float timeToCloseCombo = 1f;
    float tmr;
    GhostController ghost;
    public List<PossessableProp> props;
    int dashCount;

    // Use this for initialization
    void Start() {
        dashCount = 0;
        ghost = GetComponent<GhostController>();
        props = new List<PossessableProp>();
    }

    public void Add(PossessableProp prop) {
        props.Add(prop);
        tmr = 0f;
    }

    // Update is called once per frame
    void Update() {
        if (ghost.IsPossessing()) {
            tmr += Time.deltaTime;
            if (tmr >= timeToCloseCombo) {
                ghost.FinishPossess();
                SuccessCombo();
            }
        }
    }

    public void StartDash() {
        dashCount++;
    }

    public void FinishDash() {
        Debug.Log(props.Count + " lsat" + dashCount);
        dashCount = 0;
        //if (props.Count == lastCombo) { //Dasheaste pero no poseiste ninguno nuevo
        //    FailCombo();
        //}
    }

    void FailCombo() {
        foreach (PossessableProp p in props) {
            p.ReturnToNormal();
        }
        props = new List<PossessableProp>();

    }

    void SuccessCombo() {
        Vector3 avg = Vector3.zero;
        foreach (PossessableProp p in props) {
            avg += p.transform.position;
            p.DestroyPropAndSpawn();
        }
        avg = avg / props.Count;
        tmr = 0f;
        //props[0].currentRoom.ScarePosition(avg) //FACU ACA
        props = new List<PossessableProp>();
    }


}