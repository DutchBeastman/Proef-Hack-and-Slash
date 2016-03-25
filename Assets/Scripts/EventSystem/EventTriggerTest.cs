//Created By: Jeremy Bond
//Date: 25/03/2016

using UnityEngine;
using System.Collections;

public class EventTriggerTest : MonoBehaviour
{

	protected void Update ()
	{
		if (Input.GetKeyDown (KeyCode.W))
		{
			EventManager.TriggerEvent ("Walk");
		}
		if (Input.GetKeyDown (KeyCode.S))
		{
			EventManager.TriggerEvent ("MoonWalk");
		}
		if (Input.GetKeyDown (KeyCode.A))
		{
			EventManager.TriggerEvent ("RotateLeft");
		}
		if (Input.GetKeyDown (KeyCode.D))
		{
			EventManager.TriggerEvent ("RotateRight");
		}
	}
}
