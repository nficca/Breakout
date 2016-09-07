using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour {

    public float velocity = 10.0f;

    [HideInInspector] public IBallState currentState;
    [HideInInspector] public OnPaddleState onPaddleState;
    [HideInInspector] public MoveState moveState;
    [HideInInspector] public Rigidbody2D rigidBody;
    [HideInInspector] public GameManager gameManager;
    [HideInInspector] public Vector3 direction;

    void Awake() {
        rigidBody = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();

        onPaddleState = new OnPaddleState(this);
        moveState = new MoveState(this);
    }

    // Use this for initialization
    void Start () {
        currentState = onPaddleState;
	}
	
	// Update is called once per frame
	void Update () {
        currentState.Update();
    }

    void OnCollisionEnter2D(Collision2D collision) {
        currentState.OnCollisionEnter2D(collision);
    }

    // Gives ball a direction vector
    public void SetDirection(Vector3 d) {
        direction = d.normalized;
    }
}
