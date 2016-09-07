using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

    // Public
    public float sensitivity;
    public float xBound;
    public bool canMove = true;
    
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (canMove) Move();
	}

    // Moves the paddle along the horizontal according to mouse
    private void Move() {
        float xMovement = Input.GetAxis("Mouse X");

        // move
        transform.position += Vector3.right * xMovement * sensitivity * Time.deltaTime;

        // clamp to bounds
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -xBound, xBound), transform.position.y, transform.position.z);
    }


}
