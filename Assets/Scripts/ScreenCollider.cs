using UnityEngine;
using System.Collections;

public class ScreenCollider : MonoBehaviour {

    public EdgeCollider2D edgeCollider;

    // Private
    private Vector3 floorPadding = new Vector3(0, -0.5f, 0);

	// Use this for initialization
	void Start () {
        Vector3 bottomLeft = Camera.main.ScreenToWorldPoint(Vector3.zero) + floorPadding;
        Vector3 topLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0));
        Vector3 topRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        Vector3 bottomRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)) + floorPadding;
        edgeCollider.points = new Vector2[5] { bottomLeft, topLeft, topRight, bottomRight, bottomLeft };
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
