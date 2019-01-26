using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public delegate void ArrivalEvent();
public class HumanCharacterController : MonoBehaviour 
{
	public Transform testTarget;
	public float MinDistance = 0.1f;
	private NavMeshAgent agent;
	void Awake () 
	{
		
		NavMeshPath path = new NavMeshPath();
		agent = GetComponent<NavMeshAgent>();	
		
		if(agent.CalculatePath(testTarget.position, path))
		{
			Debug.Log("Path found");
			agent.SetPath(path);
		}
		else
		{
			Debug.Log("Path not found");
		}
	}
	ArrivalEvent OnArrive;
	public void SetDestination(Vector3 TargetPosition, ArrivalEvent cb = null)
	{

	}
	void Update()
	{
		if(OnArrive!=null)
		{
			//if()
		}
	}
}
