using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {
    private const float CAMERA_TRANSLATION_SPEED = 3.0f;
    public Vector2Reference arrowKeyInput;
    public Vector2Reference mousePointerLocation;

    void Update() {
        handleTranslation();
        recordMouseLocation();
    }

    private void handleTranslation() {
        transform.position += new Vector3(arrowKeyInput.value.x * CAMERA_TRANSLATION_SPEED * Time.deltaTime, 0.0f, arrowKeyInput.value.y * CAMERA_TRANSLATION_SPEED * Time.deltaTime);
    }

    private void recordMouseLocation() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity)) {
            mousePointerLocation.value = new Vector2(hit.point.x, hit.point.z);
        }
    }
}
