using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public GameObject[] Blocks;
    public GameObject player;
	[Range(0, 10)]
	public float speed;

    private void Update() {


		player.transform.Translate(0, -speed * Time.deltaTime, 0);

        foreach(GameObject block in Blocks)
        {
            if (Vector3.Distance(block.transform.position,player.transform.position)<=2)
            {
				speed = 1;
				print(block);
				Destroy(block);
            }
			else if (Vector3.Distance(block.transform.position, player.transform.position) > 2)
			{
				speed = 2.5f;
			}

        }
    }

}
