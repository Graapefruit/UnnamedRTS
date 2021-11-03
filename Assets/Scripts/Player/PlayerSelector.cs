using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelector : MonoBehaviour {
    public Board board;
    public UnitListReference selection;
    public GameEvent newSelectionEvent;
    new public Camera camera;
    private Vector3 selectionBegin;
    private Vector3 selectionEnd;

    public void beginSelection() {
        selectionBegin = Input.mousePosition;
    }

    public void endSelection() {
        selectionEnd = Input.mousePosition;
        Vector3 projectedBegin = screenPointToRealPoint(selectionBegin);
        selection.value = board.getUnitsFromSelectionBox(new Bounds(screenPointToRealPoint(selectionBegin), screenPointToRealPoint(selectionEnd)));
        newSelectionEvent.raise();
    }

    public void issueMoveCommand() {
        Vector3 destination = screenPointToRealPoint(Input.mousePosition);
        foreach (Unit unit in selection.value) {
            if (unit is Mover) {
                (unit as Mover).move(destination);
            }
        }
    }

    private Vector3 screenPointToRealPoint(Vector3 screenPoint) {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(screenPoint);
        
        if (Physics.Raycast(ray, out hit)) {
            return hit.point;
        } else {
            throw new System.Exception();
        }
    }
}
