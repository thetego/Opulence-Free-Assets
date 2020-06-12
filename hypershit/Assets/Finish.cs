using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
	TimeController tc;

	private void Awake()
	{
		tc = Camera.main.GetComponent<TimeController>();
	}
	private void OnTriggerEnter (Collider collision)
	{
		if (collision.transform.tag == "End")
		{
			tc.retry = true;
			tc.speed = 0;
		}
	}
}
