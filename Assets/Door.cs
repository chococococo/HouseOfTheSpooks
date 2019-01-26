using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[SelectionBase]
public class Door : MonoBehaviour {

	public List<RoomProperties> Rooms = new List<RoomProperties>();
	public RoomProperties GetOpositeRoom(RoomProperties fromRoom)
	{
		foreach(RoomProperties room in Rooms)
		{
			if(fromRoom!= room)
			{
				return room;
			}
		}
		
		Debug.LogError("No room found on door!");
		return null;
	}
}
