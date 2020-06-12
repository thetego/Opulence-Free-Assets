using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
	TimeController tc;
	public GameObject line, portal1, portal2;

    void Awake()
    {
		tc = GetComponent<TimeController>();
		portal1.SetActive(false);
		portal2.SetActive(false);
		//line.transform.position = new Vector3(line.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
		if (tc.clicked)
		{
			line.transform.Translate(0, -7 * Time.deltaTime, 0);
		}
		portal1.transform.RotateAround(Vector3.up,5*Time.deltaTime);
		portal2.transform.RotateAround(Vector3.up,5*Time.deltaTime);
    }

	public void CreatePortal()
	{
		portal1.transform.position = new Vector3(portal1.transform.position.x, line.transform.position.y, portal1.transform.position.z);
		portal2.transform.position = tc.player.transform.position;
		portal1.SetActive(true);
		portal2.SetActive(true);
		StartCoroutine("Teleport");
	}

	IEnumerator Teleport()
	{
		yield return new WaitForSeconds(0.1f);
		tc.player.transform.position = portal1.transform.position;
	}
}
