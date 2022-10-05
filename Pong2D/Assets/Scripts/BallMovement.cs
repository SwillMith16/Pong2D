using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{

	private Rigidbody2D m_Rigidbody2D;

	public float m_BallSpeed = 10f;
	private Vector2 startPos;

	// Start is called before the first frame update
	void Start()
	{
		startPos = transform.position;

		m_BallSpeed = m_BallSpeed * 25;
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
		m_Rigidbody2D.AddForce(new Vector2(2* m_BallSpeed, m_BallSpeed));
	}

	// Update is called once per frame
	void Update()
	{
		
	}

    public void ResetBall()
    {
        m_Rigidbody2D.velocity = new Vector2(0, 0);
        transform.position = startPos;
        StartCoroutine(DelayReset());
    }

    public IEnumerator DelayReset()
    {
        yield return new WaitForSeconds(1);
        m_Rigidbody2D.AddForce(new Vector2(2* m_BallSpeed, m_BallSpeed));
    }
}
