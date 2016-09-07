using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    // Public
    public GameObject ball;
    public GameObject paddle;
    public GameObject aimArrow;
    public Transform ballSpawnPoint;

    public float ballSpawnDelay = 1.0f;
    public float aimFieldAngle = 160.0f;

    // Private
    private int score;

    // Use this for initialization
    void Start () {
        score = 0;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    // Turns the aim arrow on/off and disables/enables the paddle
    public void setAimMode(bool active) {
        aimArrow.SetActive(active);
        paddle.GetComponent<Paddle>().canMove = !active;
    }

    // Adds points to score
    public void AddPoints(int points) {
        score += points;
    }

    // Restarts the game
    public void ResetLevel() {
        SceneManager.LoadScene("Level1");
    }

    // Respawns ball
    public void RespawnBall() {
        StartCoroutine("RespawnBallCo");
    }

    // Coroutine for respawning ball
    private IEnumerator RespawnBallCo() {
        ball.SetActive(false);

        yield return new WaitForSeconds(ballSpawnDelay);

        ball.transform.position = ballSpawnPoint.position;
        ball.SetActive(true);
    }
}
