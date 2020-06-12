using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionController : MonoBehaviour
{
	TimeController tc;

	private void Awake()
	{
		tc = Camera.main.GetComponent<TimeController>();
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Block")
		{
			tc.retry = true;
			tc.speed = 0;
		}
	}
}
