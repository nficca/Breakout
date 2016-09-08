using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

    // Public
    public float sensitivity;
    public bool canMove = true;

    // Private
    private float xBound;
    private BoxCollider2D boxCollider;
    private int currentScreenWidth;
    
	// Use this for initialization
	void Start () {
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        currentScreenWidth = Screen.width;
        UpdateBounds();
    }
	
	// Update is called once per frame
	void Update () {
        if (canMove) Move();

        // check for window width change
        if (currentScreenWidth != Screen.width) {
            UpdateBounds();
            currentScreenWidth = Screen.width;
        }
	}

    // Moves the paddle along the horizontal according to mouse
    private void Move() {
        float xMovement = Input.GetAxis("Mouse X");

        // move
        transform.position += Vector3.right * xMovement * sensitivity * Time.deltaTime;

        // clamp to bounds
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -xBound, xBound), transform.position.y, transform.position.z);
    }

    // Updates the x boundary so that the paddle can't move off camera
    private void UpdateBounds() {
        Vector3 right = Camera.main.ScreenToWorldPoint(new Vector3(AspectUtility.screenWidth, 0, 0));
        Vector3 left = Camera.main.ScreenToWorldPoint(Vector3.zero);

        xBound = (right.x - left.x - boxCollider.size.x) / 2.0f;
    }

}
