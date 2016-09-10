using UnityEngine;
using System.Collections;

public class MoveState : IBallState {

    private readonly Ball ball;

    // Constructor
    public MoveState (Ball b) {
        ball = b;
    }

    // Update the state
    public void Update() {
        Move();
    }

    // Handle collision
    public void OnCollisionEnter2D(Collision2D collision) {
        // get normal
        Vector2 normal = collision.contacts[0].normal;
        Vector2 contactPoint = collision.contacts[0].point;

        // assign collision object
        Paddle          paddle          =   collision.gameObject.GetComponent<Paddle>();
        Brick           brick           =   collision.gameObject.GetComponent<Brick>();
        ScreenCollider  screenCollider  =   collision.gameObject.GetComponent<ScreenCollider>();

        // handle collision with object
        if (paddle != null) {
            CollideWithPaddle(paddle, normal, contactPoint);
            // top face of paddle collision does not use standard bounce
            if (normal != Vector2.up) Bounce(normal);
        } else if (brick != null) {
            CollideWithBrick(brick, normal);
            Bounce(normal);
        } else if (screenCollider != null) {
            CollideWithScreenCollider(screenCollider, normal);
            Bounce(normal);
        }

        
    }

    // Move to on paddle state
    public void ToOnPaddleState() {
        ball.currentState = ball.onPaddleState;
        ball.gameManager.RespawnBall();
    }

    // Move to move state
    public void ToMoveState() {
        Debug.LogError("ERROR: Cannot transition to the same state!");
    }

    // Move the ball
    private void Move() {
        ball.rigidBody.velocity = ball.direction * ball.velocity;
    }

    // Handle paddle collision
    private void CollideWithPaddle(Paddle paddle, Vector2 normal, Vector2 point) {
        // only increase rally multiplier if bricks were hit
        if (ball.gameManager.scoreTracker.getBrickMultiplier > 1) {
            ball.gameManager.scoreTracker.IncreaseRallyMultiplier();
        }

        ball.gameManager.scoreTracker.ResetBrickMultiplier();

        // give the player a little control...
        if (normal == Vector2.up) {
            float variance = point.x - paddle.gameObject.transform.position.x;
            ball.direction = new Vector3(variance, -ball.direction.y, 0);
            ball.direction.Normalize();
        }
    }

    // Handle brick collision
    private void CollideWithBrick(Brick brick, Vector2 normal) {
        ball.gameManager.scoreTracker.AddPoints(brick.value);
        ball.gameManager.scoreTracker.IncreaseBrickMultiplier();
        Object.Destroy(brick.gameObject);  
    }

    // Handle screen collider collsion
    private void CollideWithScreenCollider(ScreenCollider screenCollider, Vector2 normal) {
        if (normal == Vector2.up) {
            ToOnPaddleState();
            ball.gameManager.scoreTracker.ResetAllMultipliers();
        }
    }

    // Reflects the ball's direction along the normal
    private void Bounce(Vector2 normal) {
        ball.direction = Vector3.Reflect(ball.direction, normal);
        ball.direction.Normalize();
    }
}
