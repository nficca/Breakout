using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    // Public
    public GameObject ball;
    public GameObject paddle;
    public Transform ballSpawnPoint;

    public float ballSpawnDelay = 1.0f;

    // Private
    private int score;

    // Use this for initialization
    void Start () {
        score = 0;
	}
	
	// Update is called once per frame
	void Update () {
	    
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

    private IEnumerator RespawnBallCo() {
        ball.SetActive(false);

        yield return new WaitForSeconds(ballSpawnDelay);

        ball.transform.position = ballSpawnPoint.position;
        ball.SetActive(true);
    }
}
