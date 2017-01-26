using UnityEngine;
using System.Collections;

public class FaceUpdate : MonoBehaviour
{
	public AnimationClip[] animations;

	Animator anim;

	public float delayWeight;
    float current = 0;

    void Start ()
	{
		anim = GetComponent<Animator> ();
	}

	



}
