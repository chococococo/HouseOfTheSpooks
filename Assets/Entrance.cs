using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entrance : MonoBehaviour {
	public Transform SpawnPoint;
	public GameObject HumanPrefab;

	public RoomProperties[] Rooms;
	public float TimeBetweenSpawns = 5f;

	public static Entrance instance
	{get; private set;}
	
	private float countDown;
	void Awake()
	{
		instance = this;
	}
	void Start () {
		Rooms = FindObjectsOfType<RoomProperties>();		
		countDown = TimeBetweenSpawns;
		
	}
	void SpawnHuman()
	{
		GameObject instance = GameObject.Instantiate<GameObject>(HumanPrefab, SpawnPoint.position, Quaternion.identity);
		RoomProperties randomRoom = Rooms[Random.Range(0,Rooms.Length)];
		instance.GetComponent<HumanAI>().GoToRoom(randomRoom);
	}
	public bool Spawning = true;
	// Update is called once per frame
	void Update () {
		if(Spawning)
		{
			countDown -= Time.deltaTime;
			if(countDown<=0)
			{
				SpawnHuman();
				countDown = TimeBetweenSpawns;
			}
		}		
	}
}
