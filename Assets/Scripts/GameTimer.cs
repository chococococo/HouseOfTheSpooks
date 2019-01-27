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
    public Text waveTxt;
    public float pointMultiplier = 0.4f;
    static GameTimer mgr;
    int wave;
    public GameObject canvas;




    // Use this for initialization
    void Start () {
        waveOn = false;
        tmr = 0f;
        waveTmr = 0f;
        currentLvl = -1;
        wave = 0;
        if (mgr == null)
        {
            mgr = this;
        }
        else
        {
            Debug.LogError(" Morethan one mgr");
        }
        canvas.SetActive(true);
        StartCoroutine("NextWave");

    }

    public static GameTimer GetInstance()
    {
        return mgr;
    }

    public void RestartAll()
    {
        Debug.Log("Restart");
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
        wave++;
        waveTxt.gameObject.SetActive(true);
        waveTxt.text = "Wave " + wave;
        img.fillAmount = 1f;
        float r = restTime;
        if (wave == 1)
        {
            r *= 2f;
        }
        yield return new WaitForSeconds(r);
        waveTxt.gameObject.SetActive(false);

        waveOn = true;
        waveTmr = 0f;
        tmr = 0f;
        currentLvl++;
        if (currentLvl >= timeToDie.Length)
        {
            currentLvl = timeToDie.Length - 1;
        }
        else
        {
            pointMultiplier -= 0.3f;
        }
    }

    public void ScaredHuman(int scaredCount)
    {
        tmr -= pointMultiplier * scaredCount;
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
