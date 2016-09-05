using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

    // Public
    public float xBound;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    // Moves the paddle along the horizontal according to mouse
    private void Move() {

        float xPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        // clamp to bounds
        transform.position = new Vector3(Mathf.Clamp(xPosition, -xBound, xBound), transform.position.y, transform.position.z);
    }


}
