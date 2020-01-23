using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayReplay : MonoBehaviour {
	
	public Button ShowMovesButton, PlayButton, ReplayButton, CloseButton, ButtonBasic, ButtonTurn, ButtonPromenade, ButtonNewYork, startB,tip01,tip02;
	public Canvas moves, start, odhgies, omilia, play, replay, sound, nosound, end;
	public static bool starting=false;
	public static bool turning=false;
	public static bool promenading=false;
	public static bool newyorking=false;
	public static bool zoomed = false;
	public static int playing=0;
	public Camera MainCam;
	public Light fws;
	public AudioSource hxos;
	public bool hidden = true;
	public Image ButtonBasicImage, ButtonTurnImage, ButtonPromenadeImage, ButtonNewYorkImage;
	static bool emfanise, talking;
	bool tipNo1, tipNo2;
	Text PlayButtonText, keimenaki, ShowMovesButtonText, tip1, tip2, next, previous;
	float v;

	void Start () {
		fws= fws.GetComponent<Light>();
		ShowMovesButton.GetComponent<Button> ();
		PlayButton.GetComponent<Button> ();
		ReplayButton.GetComponent<Button> ();
		PlayButtonText = PlayButton.transform.Find("Text").GetComponent<Text>();
		ShowMovesButtonText = ShowMovesButton.transform.Find ("Text").GetComponent<Text> ();
		keimenaki = omilia.transform.Find ("omilia").GetComponent<Text> ();
		tip1 = tip01.transform.Find ("tip1").GetComponent<Text> ();
		tip2 = tip02.transform.Find ("tip2").GetComponent<Text> ();
		next = tip02.transform.Find ("Symbol-forward").GetComponent<Text> ();
		previous = tip01.transform.Find ("Symbol-back").GetComponent<Text> ();
		ButtonBasic.enabled = false;
		ButtonTurn.enabled = false;
		ButtonPromenade.enabled = false;
		ButtonNewYork.enabled = false;
		start.enabled = false;
		omilia.enabled = false;
		odhgies.enabled = false;
		replay.enabled = false;
		play.enabled = false; 
		end.enabled = false;
		StartCoroutine("talk");
		StartCoroutine("emfanish");
		tip2.text = "";
		previous.text = "";
		v = moves.transform.position.y;
	}
	public void StartAnimation () //this function will be used on our Start button
	{	
		start.enabled=false;
		if (playing == 0) {
			playing=1;
			odhgies.enabled = true;
		}
	}
	public void PlayAnimation () //this function will be used on our Play button
	{		
			StartCoroutine ("motion");
			play.enabled = true;
		if (playing == 1) {
			keimenaki.text = "This is the Basic Step";
			starting = true;
			playing++;

		} else if (playing == 2) {
			keimenaki.text = "This is the Simple Turn";
			turning = true;
			playing++;
		} else if (playing == 3) {
			keimenaki.text = "This is the Promenade NewYork";
			promenading = true;
			playing++;
		} else if (playing == 4) {
			keimenaki.text = "This is the New York";
			newyorking = true;
			playing++;
			play.enabled = false;

		} 
	}

	// Coroutines for Delay

	IEnumerator talk(){
		yield return new WaitForSeconds(0.5f); 
		talking = true;
	}

	IEnumerator emfanish(){	
		yield return new WaitForSeconds(2.5f);
		emfanise = true;
	}


	IEnumerator motion(){	 
		PlayButton.enabled=false;
		ReplayButton.enabled = false;
		if (keimenaki.text == "Welcome! Are you ready to learn Rumba? ") {
			yield return new WaitForSeconds(8f);
		} else if (keimenaki.text == "This is the Basic Step") {
			yield return new WaitForSeconds(9.03175f);
		} else if(keimenaki.text == "This is the Simple Turn"){
			yield return new WaitForSeconds(20.71015f);
		} else if(keimenaki.text == "This is the Promenade NewYork"){
			yield return new WaitForSeconds(30.32363f);
		} else if(keimenaki.text == "This is the New York"){
			yield return new WaitForSeconds(28.64198f);
			StartCoroutine("countdown");
		}
		PlayButton.enabled=true;
		ReplayButton.enabled=true;
	} 
	IEnumerator fade(){	

		for(float f = 1f; f >= 0.2f; f -= 0.001f){
			fws.intensity = f;
		}	
		yield return new WaitForSeconds(0.4f);
		for(float f = 0.2f; f <= 1f; f += 0.001f){
			fws.intensity = f;
		}

	}
	IEnumerator countdown() {
		yield return new WaitForSeconds(7f); 
		replay.enabled = false;
		end.enabled = true;
	}

	//---------------------------------------------

	public void ReplayAnimation ()		
	{	
		StartCoroutine("motion");
		StartCoroutine("fade");
		end.enabled = false;
		if (keimenaki.text == "This is the Basic Step") {
			playing =1;
			//Debug.Log (PlayButtonText.text);
		} else if(keimenaki.text == "This is the Simple Turn"){
			playing =2;
		} else if(keimenaki.text == "This is the Promenade NewYork"){
			playing =3;
		} else if(keimenaki.text == "This is the New York"||keimenaki.text == "Thank you very much for attending this Rumba lesson!"){
			playing =4;

		}	

		PlayAnimation ();
	}
	public void RestartLesson ()		
	{	
		StartCoroutine("fade");
		end.enabled = false;
		replay.enabled = false;
		start.enabled = true;
		playing = 0;
		keimenaki.text = "Welcome! Are you ready to learn Rumba? ";
		Application.LoadLevel ("intro-scene");
	}
	public void ExitLesson ()		
	{	
		Application.Quit();

	}
	//these functions are used on the Rumba Moves frame
	public void ShowMoves () 
	{
		float h = moves.transform.position.x;

		if (hidden) {
			float g = v - 0.23f*v;
			hidden = false;
			ShowMovesButtonText.text = "Hide";
			for(float d = v; d >= g; d -= 0.03f){
				moves.transform.position = new Vector3(h, d, 0);
			}
		} else {
			float v2 = moves.transform.position.y;
			float i = v2 + 0.23f*v;
			hidden = true;
			ShowMovesButtonText.text = "Rumba Moves";
			for(float e = h; e <= i; e += 0.03f){
				moves.transform.position = new Vector3(h, e, 0);
			}
		}
	}
	public void basic()
	{	
		starting = true;
		StartCoroutine("fade");
		end.enabled = false;
		keimenaki.text = "This is the Basic Step";
	}
	public void turn()
	{
		turning = true;
		StartCoroutine("fade");
		end.enabled = false;
		keimenaki.text = "This is the Simple Turn";
	}
	public void promenade()
	{
		promenading = true;
		StartCoroutine("fade");
		end.enabled = false;
		keimenaki.text = "This is the Promenade NewYork";
	}
	public void newyork()
	{
		newyorking = true;
		StartCoroutine("fade");
		end.enabled = false;
		keimenaki.text = "This is the New York";
		play.enabled = false;
	}

	//these functions are used on the Tips pop-up
	public void closeTips(){
		odhgies.enabled = false;
		//start.enabled = false;
		play.enabled = true;
	}
	public void nextTip()
	{	
		if (tip2.text == "") {
			tip1.text = "";
			tip2.text = "Each move that you see, gets unlocked and you can view it again by choosing it on the Rumba Moves panel, on the top left corner of your screen.";
			next.text = "";
			previous.text = "<<";
		}
	}
	public void prevtip(){
		if (tip1.text == "") {
			tip1.text = "Click your right mouse button in order to zoom in and out, while watching a move.";
			tip2.text = "";
			previous.text = "";
			next.text = ">>";
		}

	}

	//these functions are used on the sound icons
	public void startsound(){
		if (hxos.isPlaying==false) {
			hxos.Play();
		}
	}
	public void pausesound(){
		if (hxos.isPlaying) {
			hxos.Pause();
		}
	}

	// Update is called once per frame
	void Update() {

		if (talking) {
			omilia.enabled = true;
		}
		if (playing!=0) {
			//start.enabled=false;
			emfanise=false;
			if(playing>1){
			PlayButtonText.text="next";
			}
			if(playing>5){
			play.enabled=false;
			}
		}
		if (emfanise) {
			start.enabled = true;

		}
		if (end.enabled) {
			keimenaki.text = "Thank you very much for attending this Rumba lesson!";
		}
		if (player.level == 1) {
			play.enabled = true;
			replay.enabled = true;
			ReplayButton.enabled = true;
			ButtonBasicImage.enabled = false;
			ButtonBasic.enabled = true;
		}
		if (player.level == 2) {
			ButtonTurnImage.enabled = false;
			ButtonBasic.enabled = true;
			ButtonTurn.enabled = true;
		}
		if (player.level == 3) {
			ButtonPromenadeImage.enabled=false;
			ButtonBasic.enabled = true;
			ButtonTurn.enabled = true;
			ButtonPromenade.enabled = true;
		}
		if (player.level == 4) {
			ButtonNewYorkImage.enabled=false;
			ButtonBasic.enabled = true;
			ButtonTurn.enabled = true;
			ButtonPromenade.enabled = true;
			ButtonNewYork.enabled = true;
		}
		StartCoroutine("motion");
	}
}
