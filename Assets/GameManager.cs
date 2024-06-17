using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public Ball ball;
    public Goal player1Goal, player2Goal;
    public static event Action onPointScored;
    public int scoreToWin;
    private int player1Score, player2Score;
    private void Start()
    {
        player1Goal.onGoal.AddListener(() => { player1Score++; StartCoroutine(PointScore()); });
        player2Goal.onGoal.AddListener(() => { player2Score++; StartCoroutine(PointScore()); });
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)&&(player1Score >= scoreToWin || player2Score >= scoreToWin))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private IEnumerator PointScore()
    {
        scoreText.text = player1Score.ToString() + " : " + player2Score.ToString();
        yield return new WaitForSeconds(1f);
        onPointScored.Invoke();
        if (player1Score >= scoreToWin || player2Score >= scoreToWin)
        {
            ball.gameObject.SetActive(false);
            yield return new WaitForSeconds(1f);
            if (player1Score > player2Score)
            {
                scoreText.text = "player 1 wins :]\n<size=50%>press R to restart";
            }
            else scoreText.text = "player 2 wins >:)\n<size=50%>press R to restart";
        }
    }
}
