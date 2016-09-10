using UnityEngine;
using System.Collections;

public class CursorControl : MonoBehaviour {

    private CursorLockMode lockState = CursorLockMode.Locked;

    public CursorLockMode LockState {
        get {
            return lockState;
        }

        set {
            lockState = value;
            Cursor.lockState = lockState;
        }
    }



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
