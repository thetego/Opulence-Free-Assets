using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
	public float speed = 15f;

	public CharacterController cc;
	public float gravity ;

	Vector3 vec;


	private void Update()
	{
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");

		Vector3 Move = transform.right * h + transform.forward * v;

		cc.Move(Move * speed * Time.deltaTime);

		vec.y += gravity * Time.deltaTime;

		cc.Move(vec * Time.deltaTime);


	}

}
