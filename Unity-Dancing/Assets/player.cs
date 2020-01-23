using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class player : MonoBehaviour {
	public static Animator animator;
	//public static Animation animation;
	public static bool zoomed;
	public static int level;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		//animation = GetComponent<Animation>(); 
		animator.SetBool("startingMot",false);
		animator.SetBool("turn",false);
		animator.SetBool("promenade",false);
		animator.SetBool("newyork",false);
		level = 0;
	}	
	// Update is called once per frame
	void Update () { 
		if (PlayReplay.starting) {
			animator.SetBool ("startingMot", true);
			//Debug.Log (animator.GetCurrentAnimatorStateInfo (0).length);
			if (animator.IsInTransition(0) && animator.GetCurrentAnimatorStateInfo (0).length >10) {
				PlayReplay.starting = false;
				animator.SetBool ("startingMot", false);
				zoomed = true;
				if(level<1){
				level=1;
				}
			}
		}
		if (PlayReplay.turning) {
			animator.SetBool ("turn", true);
			//Debug.Log (animator.GetCurrentAnimatorStateInfo (0).length);
			if (animator.IsInTransition (0) && animator.GetCurrentAnimatorStateInfo (0).length > 10) {
				PlayReplay.turning = false;
				animator.SetBool ("turn", false);
				zoomed = true;
				if(level<2){
				level=2;
				}
			}
		}
		if (PlayReplay.promenading) {
			//Debug.Log ("promen");
			animator.SetBool ("promenade", true);
			//Debug.Log (animator.GetCurrentAnimatorStateInfo (0).length);
			if (animator.IsInTransition (0) && animator.GetCurrentAnimatorStateInfo (0).length > 10) {
				PlayReplay.promenading = false;
				animator.SetBool ("promenade", false);
				zoomed = true;
				if(level<3){
					level=3;
				}
			}			
		}
		if (PlayReplay.newyorking) {
			//Debug.Log ("newyork");
			animator.SetBool ("newyork", true);
			//Debug.Log (animator.GetCurrentAnimatorStateInfo (0).length);
			if (animator.IsInTransition (0) && animator.GetCurrentAnimatorStateInfo (0).length > 10) {
				PlayReplay.newyorking = false;
				animator.SetBool ("newyork", false);
				zoomed = true;
				if(level<4){
					level=4;
				}
			}
		}
	}	
}