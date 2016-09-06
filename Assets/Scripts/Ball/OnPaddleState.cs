using UnityEngine;
using System.Collections;

public class OnPaddleState : IBallState {

    private readonly Ball ball;

    // Constructor
    public OnPaddleState (Ball b) {
        ball = b;
    }

    // Update the state
    public void Update() {
        FollowPaddle();
        CheckForLaunch();
    }

    // Handle collision
    public void OnCollisionEnter2D(Collision2D collision) {

    }

    // Move to on paddle state
    public void ToOnPaddleState() {
        Debug.LogError("ERROR: Cannot transition to the same state!");
    }

    // Move to move state
    public void ToMoveState() {
        ball.currentState = ball.moveState;
    }

    // Moves the ball to the paddle's designated point
    private void FollowPaddle() {
        ball.transform.position = ball.gameManager.ballSpawnPoint.position;
    }

    // Poll for left mouse click to launch the ball
    private void CheckForLaunch() {
        if (Input.GetMouseButtonDown(0)) {
            SetDirection();
            ToMoveState();
        }
    }

    // Gives ball a direction vector
    private void SetDirection() {
        ball.direction = new Vector3(Random.Range(-1.0f, 1.0f), 1.0f, 0).normalized;
    }
}
