using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossessableProp : MonoBehaviour {
    [HideInInspector]
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
    Material myMat;
    SpriteRenderer spr;

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
        if (myMat == null) {
            Renderer r = GetComponent<Renderer>();
            if (r == null) {
                spr = transform.GetChild(0).GetComponent<SpriteRenderer>();
                myMat = spr.material;

            } else {

                myMat = GetComponent<Renderer>().material;
            }
            initialColor = myMat.color;
        }
        SetNormalColor();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            Debug.Log("player entered");
            ghost = other.transform.parent.GetComponent<GhostController>();
            coll.enabled = false;
            ghost.StartPossess(this);
           // SetSpookyColor();
            //PlayAnimation
        }
    }

    public void ReturnToNormal() {
        coll.enabled = true;
        ghost.FinishPossess();
        SetNormalColor();
        ghost = null;
    }

    void SetSpookyColor() {
        // myMat.EnableKeyword("_EMISSION");
        if (spr != null) {
            spr.color = possessedColor;
        } else {
            myMat.SetColor("_EmissionColor", possessedColor);
            myMat.color = possessedColor;

        }
    }

    void SetNormalColor() {
        if (spr != null) {
            spr.color = initialColor;
        } else {
            myMat.SetColor("_EmissionColor", Color.black);
            myMat.color = initialColor;
        }
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
