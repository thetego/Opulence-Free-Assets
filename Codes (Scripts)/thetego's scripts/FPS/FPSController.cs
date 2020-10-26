using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FPSController : MonoBehaviour
{
	[Header("Parameters")]
	//[Space]
	public float speed = 3f;
	public float stamina = 50f;
	public float crouchHeight;
	public float crouchSpeed;
	public float originalhHeight;
	public float gravity;
	[Header("Booleans")]
	[Space]
	bool canRun;
	bool isRunning;
	bool canCrouch;
	bool isCrouching;
	public bool isGrounded;

	[Header("Physics")]
	[Space]
	public LayerMask mask;
	[SerializeField] private Transform groundDetector;
	[SerializeField] private float groundDis;

	private CharacterController cc;
	private Vector3 gravityVector;

	private void Awake()
	{
		canRun = true;
		canCrouch = true;
		cc = GetComponent<CharacterController>();
		originalhHeight = cc.height;
	}

	private void Update()
	{
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");

		isGrounded = Physics.CheckSphere(groundDetector.position,groundDis, mask);

		Vector3 Move = transform.right * h + transform.forward * v;

		cc.Move(Move * speed * Time.deltaTime);


		if (!isGrounded)
		{
			gravityVector.y += gravity * Time.deltaTime;
			gravity = -2;
			cc.Move(gravityVector * Time.deltaTime);
		}

		if (Input.GetKey(KeyCode.LeftShift)&&canRun)
		{
			speed = 7f;
			Camera.main.fieldOfView = 63f;
			isRunning=true;
			isCrouching = false;
			canCrouch=false;
			stamina -=  10*Time.deltaTime;
			if(stamina <= 0){
				speed = 3f;
				canRun=false;
				isRunning = false;
			}
		}
		else
		{
			speed=3f;
			Camera.main.fieldOfView = 60f;
			if (stamina < 50)
			{
				stamina += 10*Time.deltaTime;
			}
		}
		if (stamina >= 50)
		{
			canRun=true;
		}
		////
		if (Input.GetKey(KeyCode.LeftControl)&&canCrouch)
		{
			Camera.main.transform.localPosition = Vector3.Lerp(Camera.main.transform.localPosition,new Vector3(0,-0.35f,0),crouchSpeed*Time.deltaTime);
			cc.height = crouchHeight;
			speed = 1f;
			cc.center = new Vector3(0,-0.5f,0);
			canRun= false;
			isCrouching=true;
		}
		else 
		{
			Camera.main.transform.localPosition = Vector3.Lerp(Camera.main.transform.localPosition,new Vector3(0,0.7f,0),crouchSpeed*Time.deltaTime);
			cc.height = originalhHeight;
			cc.center = Vector3.zero;
			speed=3f;
			canCrouch=true;
			isCrouching=false;
		}
	}



}
