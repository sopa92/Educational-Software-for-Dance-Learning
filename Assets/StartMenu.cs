using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour {

	public Button startText;
	public Button exitText;
	
	// Use this for initialization
	void Start () 
	{
		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();
		
	}
	public void StartLevel () //this function will be used on our Play button
		
	{
		Application.LoadLevel ("rumba-lesson"); //this will load our first level from our build settings. "1" is the second scene in our game
		
	}
	public void ExitGame () //This function will be used on our "Yes" button in our Quit menu
		
	{
		Application.Quit(); //this will quit our game. Note this will only work after building the game
		
	}
	// Update is called once per frame
	void Update () 
	{
		
	}
}
