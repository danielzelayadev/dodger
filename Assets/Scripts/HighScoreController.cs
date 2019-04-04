using UnityEngine;
using UnityEngine.UI;

public class HighScoreController : MonoBehaviour {

    public Text highScoreText;

    private int currentHighScore;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerController.gameOver)
        {
            currentHighScore = currentHighScore < ScoreController.score ? ScoreController.score : currentHighScore;
            highScoreText.text = "High Score: " + currentHighScore;
        }
    }
}
