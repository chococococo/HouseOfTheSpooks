using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public delegate void ArrivalEvent();
public class HumanCharacterController : MonoBehaviour 
{	
	public float minDistance = 0.05f;
	private NavMeshAgent agent;
	private ArrivalEvent OnArrive;
	public void SetDestination(Vector3 targetPosition, ArrivalEvent cb = null)
	{
		OnArrive = cb;
		NavMeshPath path = new NavMeshPath();
		if(agent.CalculatePath(targetPosition, path))
		{
			Debug.Log("Path found");
			agent.SetPath(path);
		}
		else
		{
			HandleReachDestination();
			Debug.Log("Path not found");
		}
	}
	void Awake () 
	{
		agent = GetComponent<NavMeshAgent>();			
	}
	void HandleReachDestination()
	{
		OnArrive();
		OnArrive = null;
		agent.ResetPath();
	}
	void Update()
	{
		if(OnArrive!=null)
		{
			if(ReachedDestinationCheck())
			{
				HandleReachDestination();
			}
			else
			{
				//Debug.Log("Distance: " + agent.remainingDistance);				
			}
		}
	}

	private bool ReachedDestinationCheck()
	{
		float dist=agent.remainingDistance; 
		if (dist!=Mathf.Infinity && agent.pathStatus==NavMeshPathStatus.PathComplete && agent.remainingDistance<=minDistance) 
		{
			return true;
		}
		/* 
		if (!agent.pathPending)
		{
			if (agent.remainingDistance <= agent.stoppingDistance)
			{
				if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
				{
					return true;
				}
			}
		}
		*/
		return false;
	}
}
