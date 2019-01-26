using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenProp : MonoBehaviour {

    public float timeToRespawn = 2f;
    float tmr;

    PossessableProp originalProp;

	void Start () {
        InitialStatus();
	}

    private void OnEnable() {
        InitialStatus();
    }

    void InitialStatus() {
        tmr = 0f;
    }

    public void SetOriginal(PossessableProp prop) {
        originalProp = prop;
    }
	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
		if (gameObject.activeSelf) {
            tmr += Time.deltaTime;
            if (tmr >= timeToRespawn) {
                this.gameObject.SetActive(false);
                originalProp.gameObject.SetActive(true);
            }
        }
	}
}
