using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISelectionBox : MonoBehaviour {
    public Image image;
    public RectTransform rectTransform;
    private Vector3 selectionStart;
    private bool ongoingSelection;

    void Awake() {
        ongoingSelection = false;
        image.enabled = false;
    }

    void Update() {
        if (ongoingSelection) {
            updateSelectionBox();
        }
    }

    public void beginSelection() {
        ongoingSelection = true;
        image.enabled = true;
        selectionStart = Input.mousePosition;
        updateSelectionBox();
    }

    public void endSelection() {
        ongoingSelection = false;
        image.enabled = false;
    }

    private void updateSelectionBox() {
        Rect rect = Rect.zero;

        if (selectionStart.x < Input.mousePosition.x) {
            rect.x = selectionStart.x;
            rect.width = Input.mousePosition.x - selectionStart.x;
        } else {
            rect.x = Input.mousePosition.x;
            rect.width = selectionStart.x - Input.mousePosition.x;
        }

        if (selectionStart.y > Input.mousePosition.y) {
            rect.y = selectionStart.y;
            rect.height = selectionStart.y - Input.mousePosition.y;
        } else {
            rect.y = Input.mousePosition.y;
            rect.height = Input.mousePosition.y - selectionStart.y;
        }

        rectTransform.position = new Vector3(rect.x, rect.y, 0.0f);
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, rect.width);
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, rect.height);
    }
}
