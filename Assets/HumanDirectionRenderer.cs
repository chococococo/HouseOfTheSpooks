using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

enum FacingDirection
{
	DOWN,
	LEFT,
	RIGHT,
	UP
}
public class HumanDirectionRenderer : MonoBehaviour {
	public SpriteRenderer Renderer;
	public Sprite Down;
    public Sprite Right;
    public Sprite Up;
	public Transform HumanRoot;
	public void SetSprites(Sprite down, Sprite right, Sprite up)
	{
		Down = down;
		Right = right;
		Up = up;
	}
	FacingDirection dir;
	// Update is called once per frame
	void LateUpdate () 
	{
		float angle = HumanRoot.rotation.eulerAngles.y;
		while(angle<0)
		{
			angle += 360;
		}
		angle %= 360;
		float smallestDistance = Mathf.Abs(Mathf.DeltaAngle(angle, 315f));
		dir = FacingDirection.DOWN;
		if(Mathf.Abs(Mathf.DeltaAngle(angle, 235f))< smallestDistance)
		{
			dir = FacingDirection.RIGHT;
			smallestDistance = Mathf.Abs(Mathf.DeltaAngle(angle, 235f));
		}
		if(Mathf.Abs(Mathf.DeltaAngle(angle, 135f))< smallestDistance)
		{
			dir = FacingDirection.UP;
			smallestDistance = Mathf.Abs(Mathf.DeltaAngle(angle, 135f));
		}
		if(Mathf.Abs(Mathf.DeltaAngle(angle, 235f))< smallestDistance)
		{
			dir = FacingDirection.RIGHT;
			smallestDistance = Mathf.Abs(Mathf.DeltaAngle(angle, 235f));
		}
		if(Mathf.Abs(Mathf.DeltaAngle(angle,45f))< smallestDistance)
		{
			dir = FacingDirection.LEFT;
			smallestDistance = Mathf.Abs(Mathf.DeltaAngle(angle, 45f));
		}

		switch (dir)
		{
			case FacingDirection.DOWN:
				Renderer.sprite = Down;
				Renderer.flipX = false;
			break;
			case FacingDirection.RIGHT:
				Renderer.sprite = Right;
				Renderer.flipX = false;
			break;
			case FacingDirection.LEFT:
				Renderer.sprite = Right;
				Renderer.flipX = true;
			break;
			case FacingDirection.UP:
				Renderer.sprite = Up;
				Renderer.flipX = false;
			break;
		}
		//315 D
		//135 U
		//235 R		
		//45  L
		
		
		//Debug.DrawRay(transform.position, transform.position + Delta.normalized * 10f);
		
		//LastPos = transform.position;
		//CoordSystem.Axis.TestObject.localPosition = newPos;
	}
}
