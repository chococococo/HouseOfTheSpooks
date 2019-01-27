using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordSystem : MonoBehaviour {
	public Transform TestObject;
	public static CoordSystem Axis
	{ get; private set;}
	void Awake () {
		Axis = this;
	}
	public Vector3 WorldToCoordSystemPoint(Vector3 vector)
	{
		return transform.TransformPoint(vector);
	} 
	public Vector3 WorldToCoordSystemVector(Vector3 vector)
	{
		return transform.TransformPoint(vector);
	}
}
