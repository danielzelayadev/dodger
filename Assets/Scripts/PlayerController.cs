using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 250f;
    public GameObject gameOverText, playAgainText;
    public static bool gameOver;

    private Rigidbody2D body;

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (gameOver)
        {
            if (Input.anyKey) ResetGame();
            else return;
        }

        if (Input.GetKey(KeyCode.A)) body.velocity = Vector2.left * speed * Time.deltaTime;
        if (Input.GetKeyUp(KeyCode.A)) body.velocity = new Vector2(0, 0);
        if (Input.GetKey(KeyCode.D)) body.velocity = Vector2.right * speed * Time.deltaTime;
        if (Input.GetKeyUp(KeyCode.D)) body.velocity = new Vector2(0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy") GameOver();
    }

    private void ResetGame()
    {
        gameOver = false;
        gameOverText.SetActive(false);
        playAgainText.SetActive(false);
    }

    void GameOver()
    {
        gameOver = true;
        gameOverText.SetActive(true);
        playAgainText.SetActive(true);
    }
}
