using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSystem : MonoBehaviour
{
	Quaternion beginnigRot;
	public bool isLocked, isOpen = false;
	public float Angle = 90;
	public float Smooth = 0.05f;
	

	private void Awake()
	{
		beginnigRot = transform.localRotation;
	}

	public void IsTheDoorLocked()
	{
		if (!isLocked)
		{
			isOpen = !isOpen;
		}
	}
	private void Update()
	{
		Quaternion currentRot = transform.rotation;
		Quaternion newRot = Quaternion.Euler(transform.eulerAngles.x, Angle, transform.eulerAngles.z);

		if (isOpen)
			transform.rotation = Quaternion.Lerp(currentRot, newRot,Smooth);
		else
			transform.rotation = Quaternion.Lerp(currentRot, beginnigRot, Smooth);

	}
}
