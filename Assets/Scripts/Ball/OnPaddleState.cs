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
        // get mouse x and y
        float xPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        float yPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;

        // get mouse x,y delta from launch point
        float xAim = ball.gameManager.aimArrow.transform.position.x - xPosition;
        float yAim = yPosition - ball.gameManager.aimArrow.transform.position.y;

        // get the aiming direction and angle
        Vector3 direction = new Vector3(-xAim, yAim, 0);
        float angle = Mathf.Sign(xAim) * Mathf.Min(Vector3.Angle(Vector3.up, direction), ball.gameManager.aimFieldAngle / 2);

        // rotate the aim arrow
        ball.gameManager.aimArrow.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // update ball launch direction
        ball.SetDirection(direction);
    }
}
