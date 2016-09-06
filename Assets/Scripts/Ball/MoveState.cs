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

        // assign collision object
        Paddle          paddle          =   collision.gameObject.GetComponent<Paddle>();
        Brick           brick           =   collision.gameObject.GetComponent<Brick>();
        ScreenCollider  screenCollider  =   collision.gameObject.GetComponent<ScreenCollider>();

        // handle collision with object
        if (paddle != null) {
            CollideWithPaddle(paddle, normal);
        } else if (brick != null) {
            CollideWithBrick(brick, normal);
        } else if (screenCollider != null) {
            CollideWithScreenCollider(screenCollider, normal);
        }

        // bounce ball
        Bounce(normal);
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
    private void CollideWithPaddle(Paddle paddle, Vector2 normal) {
        if (normal == Vector2.down) ToOnPaddleState();
    }

    // Handle brick collision
    private void CollideWithBrick(Brick brick, Vector2 normal) {
        ball.gameManager.AddPoints(brick.value);
        Object.Destroy(brick.gameObject);  
    }

    // Handle screen collider collsion
    private void CollideWithScreenCollider(ScreenCollider screenCollider, Vector2 normal) {
        if (normal == Vector2.up) ToOnPaddleState();
    }

    // Reflects the ball's direction along the normal
    private void Bounce(Vector2 normal) {
        ball.direction = Vector3.Reflect(ball.direction, normal);
        ball.direction.Normalize();
    }
}
