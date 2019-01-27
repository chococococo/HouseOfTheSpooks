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

	public int Life = 3;
	public HumanState EmotionalState;

	public float ScareDuration = 2f;
	private bool RunningAway;

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
	public void GoToRoom(RoomProperties targetRoom)
	{
		if(!RunningAway)
		{
			Debug.Log("Go to room: " + targetRoom.name);
			charController.SetDestination(targetRoom.Center.position, ()=> Debug.Log("Arrived to room without catching!"));
		}
		
	}
	public void ScareToRoom(RoomProperties targetRoom)
	{
		if(!RunningAway)
		{
			Life --;
			Debug.Log("Life: " + Life);
			if(Life<0)
			{
				RunningAway = true;
				charController.SetDestination(Entrance.instance.SpawnPoint.position, ()=> Debug.Log("Ran Away!"));
			}
			bool foundPath = charController.SetDestination(targetRoom.Center.position, ()=> Debug.Log("Arrived to room without catching!"));			
			EmotionalState = HumanState.SCARED;
			if(!foundPath)
			{
				GameObject.Destroy(gameObject);
			}
		}
		
	}
	public void OnEnterRoom(RoomProperties enteredRoom)
	{
		if(!RunningAway)
		{
			if(EmotionalState == HumanState.SCARED)
			{
				EmotionalState = HumanState.WORRIED;
			}
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
