using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[SelectionBase]
public class RoomProperties : MonoBehaviour 
{	
	public Transform Center;

	[HideInInspector]
	public List<Door> Doors = new List<Door>();
	private List<HumanAI> Humans = new List<HumanAI>();
	void Awake()
	{
		Center = transform.Find("Center");
	}
	
	void Update () {
		//ScareAll();
	}		
	public void ScareHumans(Vector3 scarePosition)
	{
		foreach(HumanAI human in Humans)
		{
			Debug.Log("Scare " + human.name);
			Door exitDoor = GetExitDoor(human.transform,scarePosition);
			RoomProperties targetRoom = exitDoor.GetOpositeRoom(this);
			human.ScareToRoom(targetRoom);
		}
	}	
	private Door GetExitDoor(Transform human, Vector3 scarePosition)
	{
		if(Doors.Count == 0)
		{
			Debug.LogError("No Dooors!	");
			return null;
		}
		// If there's only one door return it.
		if(Doors.Count == 1)
		{
			return Doors[0];
		}
		// Get direction to run away in.
		Vector2 directionToRun =  GetXYDirection(human.position, scarePosition);
		int closestDoorIndex = 0;
		float lowestAngle = 0;
		for(int i=0;i<Doors.Count;i++)
		{
			//Get direction a door is in. 
			Vector2 directionToDoor = GetXYDirection(Doors[i].transform.position, human.position);
			// Get the angle between that door and the run away direction
			float angle = Vector2.Angle(directionToRun.normalized, directionToDoor.normalized);
			
			// Keep the lowest angle door
			if(lowestAngle>angle || i==0)
			{
				closestDoorIndex = i;
				lowestAngle = angle;
			}
		}
		return Doors[closestDoorIndex];
	}	
	private Vector2 GetXYDirection(Vector3 a, Vector3 b)
	{
		return new Vector2(a.x - b.x, a.z - b.z);
	}
	void OnTriggerEnter(Collider other)
	{
		HumanAI human = other.GetComponent<HumanAI>();
		if(human != null)
		{			
			Debug.Log(other.name +" arrived at "+ name +"!");
			Humans.Add(human);
		}
		else
		{
			RoomSampler roomSampler = other.GetComponent<RoomSampler>();
			if(roomSampler != null)
			{		
				Door door = roomSampler.GetComponentInParent<Door>();	
				door.Rooms.Add(this);
				if(!Doors.Contains(door))
				{
					Doors.Add(door);
				}
			}
            else {
                PossessableProp prop = other.GetComponent<PossessableProp>();
                if (prop != null) {
                    prop.GetComponentInParent<PossessableProp>().currentRoom = this;
                }
            }
		}
	
	}
	void OnTriggerExit(Collider other)
	{
		HumanAI human = other.GetComponent<HumanAI>();
		if(human != null)
		{			
			Debug.Log(other.name +" exited from "+ name +"!");
			Humans.Remove(human);
		}
	}

	#if UNITY_EDITOR
	[UnityEditor.MenuItem("Tests/Scare All")]
    static void ScareAll()
    {
        Debug.Log("Something scary happened...!");
		RoomProperties[] Rooms = FindObjectsOfType<RoomProperties>();
		for(int i=0; i<Rooms.Length;i++)
		{
			Debug.Log("Scare " + Rooms[i].name);
			Rooms[i].ScareHumans(Rooms[i].Center.position);
		}
    }
	#endif
}
