using UnityEngine;
using System.Collections;

public class MainMenuButtonCommands : MonoBehaviour
{

	public void Play ()
	{

		Debug.Log ("Log Start Game");
	}

	public void Settings ()
	{

		Debug.Log ("Log Settings Game");
	}

	public void Exit ()
	{
		Debug.Log ("Log Quit Game");
		Application.Quit ();
	}
}
