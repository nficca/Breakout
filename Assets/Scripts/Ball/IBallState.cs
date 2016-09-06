using UnityEngine;
using System.Collections;

public interface IBallState {

    // Update the state
    void Update();

    // Handle collision
    void OnCollisionEnter2D(Collision2D collision);

    // Move to on paddle state
    void ToOnPaddleState();

    // Move to move state
    void ToMoveState();
        
}
