using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[SelectionBase]
public class Door : MonoBehaviour {

	public List<RoomProperties> Rooms = new List<RoomProperties>();
	public RoomProperties GetOpositeRoom(RoomProperties fromRoom)
	{
		Debug.Log("From Room: " + fromRoom);
		foreach(RoomProperties room in Rooms)
		{
			if(fromRoom != room)
			{
				Debug.Log("To Room: " + room);
				return room;
			}
		}
		
		Debug.LogError("No room found on door!");
		return null;
	}
}
