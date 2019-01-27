using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {
    float tmr;
    float waveTmr;
    public float [] timeToDie;
    public float [] waveTime;
    public Image img;
    float currentHealth;
    public bool waveOn;
    public float restTime = 5f;
    public int currentLvl;
    public GameObject lostBanner;

    static GameTimer mgr;



    // Use this for initialization
    void Start () {
        waveOn = true;
        tmr = 0f;
        waveTmr = 0f;
        currentLvl = 0;
        if (mgr == null)
        {
            mgr = this;
        }
        else
        {
            Debug.LogError(" Morethan one mgr");
        }

    }

    public static GameTimer GetInstance()
    {
        return mgr;
    }

    public void RestartAll()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
	
	// Update is called once per frame
	void Update () {
		if (waveOn)
        {
            waveTmr += Time.deltaTime;
            tmr += Time.deltaTime;
            img.fillAmount = 1 - tmr / timeToDie[currentLvl];
           // Debug.Log(tmr / timeToDie[currentLvl]);
            if (tmr >= timeToDie[currentLvl])
            {
                LoseGame();
            }
            if (waveTmr >= waveTime[currentLvl])
            {
                StartCoroutine("NextWave");
            }

        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            ScaredHuman(1);
        }
	}

    IEnumerator NextWave()
    {
        Debug.Log("next wae");
        waveOn = false;
        yield return new WaitForSeconds(restTime);
        waveOn = true;
        waveTmr = 0f;
        tmr = 0f;
        currentLvl++;
        if (currentLvl >= timeToDie.Length)
        {
            currentLvl = timeToDie.Length - 1;
        }
    }

    public void ScaredHuman(int scaredCount)
    {
        tmr -= 0.1f * scaredCount;
        if (tmr <= 0f)
        {
            tmr = 0f;
        }
    }

    void LoseGame()
    {
        waveOn = false;
        lostBanner.SetActive(true);
        Debug.Log("LOST");
    }
}
