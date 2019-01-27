using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanAnimator : MonoBehaviour {
	public List<HumanSprites> RandomizedLooks;
    public HumanSprites HumanSprite;
	public HumanDirectionRenderer Renderer;
    
	private Quaternion rotation;
	private HumanAI ai;
	public Animator animator;
	void Awake()
	{
		ai = GetComponentInParent<HumanAI>();
		int lookIndex = Random.Range(0,2);
		HumanSprite = RandomizedLooks[lookIndex];
	}
	// Use this for initialization
	void Start () {
		LastPos = transform.position;
		Renderer.SetSprites(HumanSprite.Down, HumanSprite.Right,HumanSprite.Up);
		rotation = transform.localRotation;
		RefreshEmotionSprite();
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = rotation;
		RefreshEmotionSprite();
	}
	private Vector3 LastPos;
	void LateUpdate()
	{
		bool Moved = transform.position != LastPos;
		animator.SetBool("Moving",Moved);
		
		LastPos = transform.position;
	}
	void RefreshEmotionSprite()
	{
		switch(ai.EmotionalState)
		{
			case HumanState.NORMAL:
				Renderer.SetSprites(HumanSprite.Down, HumanSprite.Right,HumanSprite.Up);
				animator.speed = 1;
				animator.SetBool("Worried",false);
			break;
			case HumanState.SCARED:
				Renderer.SetSprites(HumanSprite.ScaredDown, HumanSprite.ScaredRight,HumanSprite.ScaredUp);
				animator.speed = 2;
				animator.SetBool("Worried",false);
			break;
			case HumanState.WORRIED:
				Renderer.SetSprites(HumanSprite.WorriedDown, HumanSprite.WorriedRight,HumanSprite.WorriedUp);
				animator.speed = 1;
				//animator.speed = 0.75f;
				//animator.SetBool("Worried",true);
			break;
		}
	}
}
