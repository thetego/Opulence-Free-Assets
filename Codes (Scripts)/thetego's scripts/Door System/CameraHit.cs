using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraHit : MonoBehaviour
{

	public Image cursor;

	private void Update()
	{
		RaycastHit hit;
		if (Physics.Raycast(transform.position,transform.forward,out hit, 5F))
		{
			cursor.color = Color.green;
			if (hit.transform.tag == "Door")
			{
				if(Input.GetKeyDown(KeyCode.E))
					hit.transform.GetComponent<DoorSystem>().IsTheDoorLocked();
			}
		}
		else
		{
			cursor.color = Color.white;
		}
	}
}
