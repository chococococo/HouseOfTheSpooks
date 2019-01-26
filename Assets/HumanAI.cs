using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HumanState
{
	IDLE,
	WALKING,	
	SCARED,
	FREAKED
}
public class HumanAI : MonoBehaviour {
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
		charController.SetDestination(targetRoom.Center.position, ()=> Debug.Log("Arrived!"));
	}
	void Update()
	{
		
	}
}
