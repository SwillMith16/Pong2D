using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : MonoBehaviour
{
	private Rigidbody2D rb2d;

	public GameObject topWall;	
	public GameObject bottomWall;
    private BoxCollider2D topWallCollider;
    private BoxCollider2D bottomWallCollider;

	public float moveSpeed = 3f;
	private float vMove = 0f;

    private Vector2 startPos;
    private Vector2 pos;
	private Vector2 changePos;
	private Vector2 newPos;
	private bool allowMoveUp;
	private bool allowMoveDown;


	private void Start()
	{
        startPos = transform.position;

        rb2d = GetComponent<Rigidbody2D>();
		topWallCollider = topWall.GetComponent<BoxCollider2D>();
		bottomWallCollider = bottomWall.GetComponent<BoxCollider2D>();

		moveSpeed = moveSpeed / 100;

		allowMoveUp = true;
		allowMoveDown = true;
	}

	private void Update()
	{
		vMove = Input.GetAxisRaw("Player2");
		pos = rb2d.position;

	}

	private void FixedUpdate()
	{
		if (allowMoveUp && vMove > 0f)
		{
			Move();
            allowMoveDown = true;
        }
		else if (allowMoveDown && vMove < 0f)
		{
			Move();
            allowMoveUp = true;
        }
	}

	private void OnTriggerEnter2D(Collider2D collider)
	{
		var wallCollider = collider.gameObject.GetComponent<BoxCollider2D>();
		if (wallCollider == topWallCollider)
		{
			allowMoveUp = false;
		}
		else if (wallCollider == bottomWallCollider)
		{
			allowMoveDown = false;
		}
	}

	private void Move()
	{
		changePos = new Vector2(0, moveSpeed * vMove);
		newPos = pos + changePos;
		rb2d.MovePosition(newPos);
	}

    public void ResetPlayer2()
    {
        transform.position = startPos;
        allowMoveDown = false;
        allowMoveUp = false;
        StartCoroutine(DelayReset());
    }

    public IEnumerator DelayReset()
    {
        yield return new WaitForSeconds(1);
        allowMoveDown = true;
        allowMoveUp = true;
    }
}
