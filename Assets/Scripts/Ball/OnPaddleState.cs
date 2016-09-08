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
        // enter aim mode
        if (Input.GetMouseButtonDown(0)) {
            ball.gameManager.setAimMode(true);
        }

        // read aim input
        if (Input.GetMouseButton(0)) {
            aimBall();
        }

        // launch ball
        if (Input.GetMouseButtonUp(0)) {
            ball.gameManager.setAimMode(false);
            ToMoveState();
        }
    }

    private void aimBall() {
        // read horizontal mouse input
        float xMovement = -Input.GetAxis("Mouse X");

        // calculate new angle with mouse input
        float newAngle = ball.gameManager.aimArrow.transform.rotation.eulerAngles.z + xMovement * ball.gameManager.aimSensitivity * Time.deltaTime;

        // bound new angle to restricted angle setting
        float rotationBound = ball.gameManager.aimFieldAngle / 2;
        if (newAngle > rotationBound && newAngle < 360.0f - rotationBound) {
            if (newAngle - rotationBound < 360.0f - rotationBound - newAngle) {
                newAngle = rotationBound;
            } else {
                newAngle = 360.0f - rotationBound;
            }
        }

        // set the aim arrow's rotation
        Quaternion q = Quaternion.AngleAxis(newAngle, Vector3.forward);
        ball.gameManager.aimArrow.transform.rotation = q;

        // update the ball launch direction
        ball.SetDirection(q * Vector3.up);
    }
}
