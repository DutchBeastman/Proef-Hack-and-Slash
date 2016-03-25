//Created By: Jeremy Bond
//Date: 25/03/2016

using UnityEngine;
using UnityEngine.Events;

public class TriggerTest : MonoBehaviour
{
	private UnityAction someListener;
	private const string TEST = "test";

	void Awake ()
	{
		someListener = new UnityAction (SomeFunction);
	}

	void OnEnable ()
	{
		EventManager.StartListening (TEST, someListener);
	}

	void OnDisable ()
	{
		EventManager.StopListening (TEST, someListener);
	}

	private void SomeFunction ()
	{
		print ("SomeFunction");
	}
}
