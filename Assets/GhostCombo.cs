using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostCombo : MonoBehaviour {
    float timeToCloseCombo = 1f;
    float tmr;
    GhostController ghost;
    List<PossessableProp> props;

    // Use this for initialization
    void Start() {
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
                FinishPossess();
            }

        }

    }

    void FinishPossess() {
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
