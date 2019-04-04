using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

    public Text scoreText;
    public int scorePerSecond = 1;

    public static int score;

    private float secondsSinceGameStart;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (PlayerController.gameOver)
        {
            secondsSinceGameStart = 0;
            return;
        }

        secondsSinceGameStart += Time.deltaTime;

        score = CalculateScore();

        scoreText.text = "Score: " + score;
	}

    int CalculateScore()
    {
        return scorePerSecond * Mathf.FloorToInt(secondsSinceGameStart);
    }
}
