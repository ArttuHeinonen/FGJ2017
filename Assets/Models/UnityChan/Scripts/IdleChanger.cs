using UnityEngine;
using System.Collections;

//
// ↑↓キーでループアニメーションを切り替えるスクリプト（ランダム切り替え付き）Ver.3
// 2014/04/03 N.Kobayashi
//

// Require these components when using this script
[RequireComponent(typeof(Animator))]



public class IdleChanger : MonoBehaviour
{
	
	private Animator anim;						
	private AnimatorStateInfo currentState;		
	private AnimatorStateInfo previousState;	
	public bool _random = false;				
	public float _threshold = 0.5f;				
	public float _interval = 2f;				
	//private float _seed = 0.0f;				
	

	void Start ()
	{
		anim = GetComponent<Animator> ();
		currentState = anim.GetCurrentAnimatorStateInfo (0);
		previousState = currentState;
	}

	void  Update ()
	{
		if (Input.GetKeyDown ("up") || Input.GetButton ("Jump")) {
			//anim.SetBool ("Jump", true);
		}
	}

}
