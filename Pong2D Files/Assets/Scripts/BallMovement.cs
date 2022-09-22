using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{

	private Rigidbody2D m_Rigidbody2D;
	public float m_BallSpeed = 1f;

	// Start is called before the first frame update
	void Start()
	{
		m_BallSpeed = m_BallSpeed * 50;
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
		m_Rigidbody2D.AddForce(new Vector2(m_BallSpeed, m_BallSpeed));
	}

	// Update is called once per frame
	void Update()
	{
		
	}
}
