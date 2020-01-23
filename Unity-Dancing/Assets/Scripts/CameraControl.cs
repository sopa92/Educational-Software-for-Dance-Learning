using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
	public Camera Main;

	void Update ()
	{
		if( Input.GetButtonDown("Fire2") ) 
		{
			if(Main.enabled){
				Main.enabled = false;

			}else{
				Main.enabled = true;
			}
		}
		if (player.zoomed) {

			if(!Main.enabled){
				Main.enabled = true;
			}
			player.zoomed=false;
		}
	}
}
