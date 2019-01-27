using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AnyKeyToStart : MonoBehaviour {
	public string SceneTarget;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.anyKeyDown)
		{
			SceneManager.LoadScene(SceneTarget);
		}
	}
}
