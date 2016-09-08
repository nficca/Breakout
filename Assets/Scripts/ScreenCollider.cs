using UnityEngine;
using System.Collections;

public class ScreenCollider : MonoBehaviour {

    public EdgeCollider2D edgeCollider;

    // Private
    private Vector3 floorPadding = new Vector3(0, -0.5f, 0);

    // Use this for initialization
    void Start () {
        UpdateEdgePoints();
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    // Update the edge collider points so the ball can't leave camera bounds
    public void UpdateEdgePoints() {
        Vector3 bottomLeft = Camera.main.ScreenToWorldPoint(new Vector3(AspectUtility.xOffset, AspectUtility.yOffset, 0)) + floorPadding;
        Vector3 topLeft = Camera.main.ScreenToWorldPoint(new Vector3(AspectUtility.xOffset, AspectUtility.yOffset + AspectUtility.screenHeight, 0));
        Vector3 topRight = Camera.main.ScreenToWorldPoint(new Vector3(AspectUtility.xOffset + AspectUtility.screenWidth, AspectUtility.yOffset + AspectUtility.screenHeight, 0));
        Vector3 bottomRight = Camera.main.ScreenToWorldPoint(new Vector3(AspectUtility.xOffset + AspectUtility.screenWidth, AspectUtility.yOffset, 0)) + floorPadding;
        edgeCollider.points = new Vector2[5] { bottomLeft, topLeft, topRight, bottomRight, bottomLeft };
    }
}
