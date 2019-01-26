using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour {
    DashController dash;
    GhostMovement move;
    GhostCombo combo;
    bool isPossessing;


    void Start() {
        dash = GetComponent<DashController>();
        move = GetComponent<GhostMovement>();
        combo = GetComponent<GhostCombo>();
    }

    public Vector3 GetNextDir() {
        Vector3 res = Vector3.zero;
        if (Input.GetKey(KeyCode.UpArrow)) {
            res += transform.forward;
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            res -= transform.forward;
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            res += transform.right;
        }
        if (Input.GetKey(KeyCode.LeftArrow)) {
            res -= transform.right;
        }
        return res;
    }

    public bool IsPossessing() {
        return isPossessing;
    }

    public void StartPossess(PossessableProp prop) {
        dash.Stop();
        combo.Add(prop);
        isPossessing = true;
        ApplyPossess();
    }

    public void FinishPossess() {
        isPossessing = false;
        ApplyPossess();
    }
    void ApplyPossess() {
        move.enabled = !isPossessing;
        GetModel().SetActive(!isPossessing);
    }

    public GameObject GetModel() {
        return transform.GetChild(0).gameObject;
    }
}
