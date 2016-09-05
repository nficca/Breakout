using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour {

    // Public
    public float velocity = 1;

    // Private
    private Rigidbody2D rb;
    private Vector3 dir;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        dir = new Vector3(Random.Range(-1.0f, 1.0f), 1.0f, 0).normalized;
	}
	
	// Update is called once per frame
	void Update () {
        rb.velocity = dir * velocity;
    }

    void OnCollisionEnter2D(Collision2D other) {
        Vector2 normal = other.contacts[0].normal;
        bool lostBall = false;

        if (other.gameObject.GetComponent<Paddle>() != null) {
            if (normal == Vector2.down) {
                lostBall = true;
            }
        } else if (other.gameObject.GetComponent<ScreenCollider>() != null) {
            if (normal == Vector2.up) {
                lostBall = true;
            }
        }

        if (lostBall) {
            SceneManager.LoadScene("Level1");
        }

        dir = Vector3.Reflect(dir, normal).normalized;
    }
}
