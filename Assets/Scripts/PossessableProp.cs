using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossessableProp : MonoBehaviour {
    public RoomProperties currentRoom;
    public float time = 1f;
    public GameObject brokenPropPrefab;
    public Color possessedColor;

    MeshRenderer render;
    Color initialColor;

    BrokenProp broken;
    float tmr;
    GhostController ghost;
    BoxCollider coll;

    private void Start() {
        InitialStatus();
    }

    private void OnEnable() {
        InitialStatus();
    }

    void InitialStatus() {
        ghost = null;
        tmr = 0f;
        if (coll == null) {
            coll = GetComponent<BoxCollider>();
        }
        coll.enabled = true;
        if (render == null) {
            render = GetComponent<MeshRenderer>();
            initialColor = render.material.color;
        }
        SetNormalColor();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            Debug.Log("player entered");
            ghost = other.transform.parent.GetComponent<GhostController>();
            coll.enabled = false;
            ghost.StartPossess(this);
            SetSpookyColor();
            //PlayAnimation
        }
    }

    void SetSpookyColor() {
        render.material.color = possessedColor;
    }

    void SetNormalColor() {
        render.material.color = initialColor;
    }


    public void DestroyPropAndSpawn() {
        if (broken == null) {
            broken = Instantiate(brokenPropPrefab, this.transform.position, this.transform.rotation).GetComponent<BrokenProp>();
            broken.SetOriginal(this);
        }
        broken.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

}
