using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{

	private Rigidbody2D myRigidbody2D;

	private bool movesLeft = false;
	private bool movesRight = false;
	private bool wentLeft = false;		// Tracks last directionbutton clicked

	[SerializeField] private float acceleration = 30.0f;
	[SerializeField] private float topSpeed = 6.0f;

	void Start()
    {
		myRigidbody2D = GetComponent<Rigidbody2D>();
    }

   
    void Update()
    {
		float horizontal = Input.GetAxisRaw("Horizontal");

		if (horizontal > 0)
		{
			MoveRight();
		}
		else
		{
			if (horizontal < 0)
			{
				MoveLeft();
			}
			else
			{
				StopMoveLeft();
				StopMoveRight();
			}
		}

		float currentSpeed = myRigidbody2D.velocity.x;
		float newSpeed = 0.0f;

		if (movesRight && movesLeft)
		{
			if (wentLeft)
			{
				newSpeed = currentSpeed - acceleration * Time.deltaTime;
			}
			else
			{
				newSpeed = currentSpeed + acceleration * Time.deltaTime;
			}
		}
		else
		{
			if (movesRight)
			{
				newSpeed = currentSpeed + acceleration * Time.deltaTime;
			}

			if (movesLeft)
			{
				newSpeed = currentSpeed - acceleration * Time.deltaTime;
			}
		}


		if (Math.Abs(newSpeed) > topSpeed)
		{



			if (newSpeed > 0)
			{
				newSpeed = topSpeed;
			}
			else
			{
				newSpeed = -topSpeed;
			}
		}




		Vector2 newVelocity = new Vector2(newSpeed, 0.0f);

		myRigidbody2D.velocity = newVelocity;
    }

	public void MoveLeft()
	{
		movesLeft = true;

		if (!wentLeft)
		{
			myRigidbody2D.velocity = new Vector2(0.0f, 0.0f);
			wentLeft = true;
		}

	}

	public void MoveRight()
	{
		movesRight = true;

		if (wentLeft)
		{
			myRigidbody2D.velocity = new Vector2(0.0f, 0.0f);
			wentLeft = false;
		}
	}

	public void StopMoveLeft()
	{
		movesLeft = false;
	}

	public void StopMoveRight()
	{
		movesRight = false;
	}
}
