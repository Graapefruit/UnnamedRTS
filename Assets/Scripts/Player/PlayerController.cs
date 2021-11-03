using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public Vector2Reference arrowKeyInput;
    public PlayerSelector playerSelector;
    public GameEvent selectionBeginEvent;
    public GameEvent selectionEndEvent;
    public GameEvent unitMoveCommandEvent;

    void Update() {
        handleKeyboardInputs();
        handleMouseInputs();
    }

    private void handleKeyboardInputs() {
        if (Input.GetKey(KeyCode.LeftArrow)) {
            arrowKeyInput.value.x = -1.0f;
        } else if (Input.GetKey(KeyCode.RightArrow)) {
            arrowKeyInput.value.x = 1.0f;
        } else {
            arrowKeyInput.value.x = 0.0f;
        }
        
        if (Input.GetKey(KeyCode.UpArrow)) {
            arrowKeyInput.value.y = 1.0f;
        } else if (Input.GetKey(KeyCode.DownArrow)) {
            arrowKeyInput.value.y = -1.0f;
        } else {
            arrowKeyInput.value.y = 0.0f;
        }
    }

    private void handleMouseInputs() {
        if (Input.GetMouseButtonDown(0)) {
            selectionBeginEvent.raise();
        }

        if (Input.GetMouseButtonUp(0)) {
            selectionEndEvent.raise();
        }

        if (Input.GetMouseButtonDown(1)) {
            unitMoveCommandEvent.raise();
        }
    }
}
