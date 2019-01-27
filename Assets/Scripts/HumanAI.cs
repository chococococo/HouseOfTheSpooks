using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HumanState
{
	IDLE,
	WALKING,	
	SCARED,
	CALMING_DOWN,
	FREAKED,
    LEAVING
}
public class HumanAI : MonoBehaviour {
	public HumanState EmotionalState;
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
	}
	void Update()
	{
		
	}
}
