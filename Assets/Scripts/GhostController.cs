using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour {
    DashController dash;
    GhostMovement move;
    GhostCombo combo;
    bool isPossessing;
    FX fx;

    public class Direction {
        public Vector3 vec;
        public bool diag;
        public Direction(Vector3 v, bool d) {
            vec = v;
            diag = d;
        }
    }

    void Start() {
        dash = GetComponent<DashController>();
        move = GetComponent<GhostMovement>();
        combo = GetComponent<GhostCombo>();
        fx = GetComponent<FX>();
    }

    public Direction GetNextDir() {
        Vector3 res = Vector3.zero;
        bool vert = false;
        bool hor = false;
        if (Input.GetKey(KeyCode.UpArrow)) {
            res += transform.forward;
            vert = true;
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            res -= transform.forward;
            vert = true;
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            res += transform.right;
            hor = true;
        }
        if (Input.GetKey(KeyCode.LeftArrow)) {
            res -= transform.right;
            hor = true;

        }
        return new Direction(res, vert & hor);
    }

    public bool IsPossessing() {
        return isPossessing;
    }

    public void StartPossess(PossessableProp prop) {
        dash.Stop();
        fx.PlayRandomClip();
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
