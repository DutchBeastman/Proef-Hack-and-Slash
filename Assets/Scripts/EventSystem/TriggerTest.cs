//Created By: Jeremy Bond
//Date: 25/03/2016

using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System;

public class TriggerTest : MonoBehaviour
{
	private UnityAction someListener;
	private const string EVENTW = "Walk";
	private const string EVENTS = "MoonWalk";
	private const string EVENTA = "RotateLeft";
	private const string EVENTD = "RotateRight";

	void Awake ()
	{
		someListener = new UnityAction (SomeFunction);
	}

	private void SomeFunction ()
	{

	}

	void OnEnable ()
	{
		EventManager.StartListening (EVENTW, MoveForward);
		EventManager.StartListening (EVENTS, MoveBackwards);
		EventManager.StartListening (EVENTA, RotateLeft);
		EventManager.StartListening (EVENTD, RotateRight);
	}

	void OnDisable ()
	{
		EventManager.StopListening (EVENTW, MoveForward);
		EventManager.StopListening (EVENTS, MoveBackwards);
		EventManager.StopListening (EVENTA, RotateLeft);
		EventManager.StopListening (EVENTD, RotateRight);
	}

	private void MoveForward ()
	{
		Vector3 targetPosition = transform.position;
		targetPosition.y += 1;
		transform.position = Vector3.Lerp (transform.position, targetPosition, 0.5f);
	}
	private void MoveBackwards ()
	{
		Vector3 targetPosition = transform.position;
		targetPosition.y -= 1;
		transform.position = Vector3.Lerp (transform.position, targetPosition, 0.5f);
	}
	private void RotateRight ()
	{
		transform.Rotate (new Vector3 (0, 0, -10));
	}
	private void RotateLeft ()
	{
		transform.Rotate (new Vector3 (0, 0, 10));
	}
}
