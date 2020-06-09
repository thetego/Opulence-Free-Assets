using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallController : MonoBehaviour
{
	[Range(3,15)]
    [SerializeField] private float speed;
	public LayerMask ground;
	public bool canJump;
	Rigidbody rb;

	

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}
	private void Update()
	{
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");


		if (Physics.CheckSphere(transform.position, .1f, ground)) {
			canJump = true;
		}
		else { canJump = false; }

		if (Input.GetKey(KeyCode.Space) && canJump) 
		{
			rb.velocity = new Vector3(h, 2, v);
		}

		rb.AddForce(new Vector3 (h, 0, v)*speed);

	}
}
