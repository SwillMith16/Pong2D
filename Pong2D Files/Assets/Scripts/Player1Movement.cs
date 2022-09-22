using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Movement : MonoBehaviour
{
    private Rigidbody2D rb2d;

    public float moveSpeed = 3f;
	public float vMove = 0f;
	private Vector2 velocity;
	

	void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();
		if (!rb2d)
		{
			Debug.Log("rb not found");
		} else
		{
			Debug.Log("rb found");
		}

		velocity = new Vector2(rb2d.velocity.x, moveSpeed);

	}

	void FixedUpdate()
	{
		vMove = Input.GetAxisRaw("Vertical");

		rb2d.MovePosition(rb2d.position + velocity * vMove * Time.fixedDeltaTime);
	}

	
}
