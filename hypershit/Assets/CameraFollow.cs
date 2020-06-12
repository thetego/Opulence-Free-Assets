using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public GameObject player;
	Vector3 x;

    void Update()
    {
		transform.position = new Vector3(transform.position.x, player.transform.position.y-1.5f, transform.position.z);
    }
}
