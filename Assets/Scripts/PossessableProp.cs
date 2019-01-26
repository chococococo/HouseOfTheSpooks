using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossessableProp : MonoBehaviour {

    public float time = 1f;
    public GameObject brokenProp;
    float tmr;
    GhostController ghost;

    private void Start() {
        tmr = 0f;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            Debug.Log("player entered");
            ghost = other.transform.parent.GetComponent<GhostController>();
            //PlayAnimation
            ghost.StartPossess();
        }
    }

    private void Update() {
        if (ghost != null) {
            tmr += Time.deltaTime;
            if (tmr >= time) {
                ghost.FinishPossess();
                Instantiate(brokenProp, this.transform.position, this.transform.rotation);
                Destroy(this.gameObject);
            }
        }
    }

}
