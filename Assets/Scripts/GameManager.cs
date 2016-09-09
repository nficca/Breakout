using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    // Public
    public GameObject ball;
    public GameObject paddle;
    public GameObject aimArrow;
    public Transform ballSpawnPoint;
    public ScoreTracker scoreTracker;

    public float ballSpawnDelay = 1.0f;
    public float aimFieldAngle = 160.0f;
    public float aimSensitivity = 90.0f;

    // Private
    private Paddle paddleController;

    void Awake() {
        paddleController = paddle.GetComponent<Paddle>();
        scoreTracker = GetComponent<ScoreTracker>();
    }

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    // Turns the aim arrow on/off and disables/enables the paddle
    public void setAimMode(bool active) {
        aimArrow.SetActive(active);
        paddleController.canMove = !active;

        // resets aim arrrow rotation
        aimArrow.transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
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
