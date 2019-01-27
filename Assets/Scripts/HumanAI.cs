using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HumanState
{
	NORMAL,	
	SCARED,
	WORRIED,
}
public class HumanAI : MonoBehaviour {
	public HumanState EmotionalState;

	public float ScareDuration = 2f;

	//public float ScaredCountDown

	private HumanCharacterController charController; 	
	// Use this for initialization
	void Awake () 
	{
		charController = GetComponent<HumanCharacterController>();
	}
	void Start()
	{
	}
	public void ScareToRoom(RoomProperties targetRoom)
	{
		charController.SetDestination(targetRoom.Center.position, ()=> Debug.Log("Arrived to room without catching!"));
		EmotionalState = HumanState.SCARED;
	}
	public void OnEnterRoom(RoomProperties enteredRoom)
	{
		if(EmotionalState == HumanState.SCARED)
		{
			EmotionalState = HumanState.WORRIED;
		}
	}
	void Update()
	{
		switch(EmotionalState)
		{
			case HumanState.SCARED:
			break;
		}
	}
}
