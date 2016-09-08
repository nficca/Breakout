using UnityEngine;
using System.Collections;

public class CursorControl : MonoBehaviour {

    public CursorLockMode lockState = CursorLockMode.Locked;

    // Use this for initialization
    void Start() {
        Cursor.lockState = lockState;
    }

    // Update is called once per frame
    void Update() {
        if (Input.anyKeyDown) {
            Cursor.lockState = lockState;
        }
    }
}
