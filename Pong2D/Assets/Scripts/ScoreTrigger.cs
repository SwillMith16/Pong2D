using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    public GameObject rightWall;
    public GameObject leftWall;
    public GameObject player1ScoreCount;
    public GameObject player2ScoreCount;
    public Player1Movement player1;
    public Player2Movement player2;
    public BallMovement ball;

    private TextMeshProUGUI player1ScoreCount_TMP;
    private TextMeshProUGUI player2ScoreCount_TMP;
    private BoxCollider2D rightWallCollider;
    private BoxCollider2D leftWallCollider;
    private int player1Score;
    private int player2Score;

    // Start is called before the first frame update
    void Start()
    {
        player1Score = 0;
        player2Score = 0;

        rightWallCollider = rightWall.GetComponent<BoxCollider2D>();
        leftWallCollider = leftWall.GetComponent<BoxCollider2D>();

        //ball_collider = ball.GetComponent<BoxCollider2D>();
        player1ScoreCount_TMP = player1ScoreCount.GetComponent<TextMeshProUGUI>();
        player2ScoreCount_TMP = player2ScoreCount.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        player1ScoreCount_TMP.text = "" + player1Score;
        player2ScoreCount_TMP.text = "" + player2Score;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        var wallCollider = collider.gameObject.GetComponent<BoxCollider2D>();
        if (wallCollider == rightWallCollider)
        {
            // player 1 has scored
            player1Score++;
            player1.ResetPlayer1();
            player2.ResetPlayer2();
            ball.ResetBall();
        } else if (wallCollider == leftWallCollider)
        {
            // player 2 has scored
            player2Score++;
            player1.ResetPlayer1();
            player2.ResetPlayer2();
            ball.ResetBall();
        }
    }

    public void ResetPlayer1Score()
    {
        player1Score = 0;
    }

    public void ResetPlayer2Score()
    {
        player2Score = 0;
    }
}
