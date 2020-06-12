using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
	public GameObject[] Blocks;
	public GameObject player;
	[Range(0, 10)]
	public float speed;
	public bool clicked, trigger, retry;
	Portal portal;

	private void Awake()
	{
		portal = GetComponent<Portal>();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.R))
		{
			Application.LoadLevel(0);
		}
		player.transform.Translate(0, -speed * Time.deltaTime, 0);

		if (Input.GetMouseButton(0))
		{
			speed = 1;
			clicked = true;
			if (!trigger)
			StartCoroutine("Wait");
		}
		else
		{
			if (!retry)
			{
				speed = 2;
			}
			clicked = false;
			if (trigger)
			portal.CreatePortal(); trigger = false;
		}
	}

	IEnumerator Wait()
	{
		portal.line.transform.position = new Vector3(portal.line.transform.position.x, player.transform.position.y, portal.line.transform.position.z);
		trigger = true;
		yield return null;
	}

}
