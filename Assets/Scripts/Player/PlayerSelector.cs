using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerSelector : MonoBehaviour {
    private const float BOX_VS_POINT_THRESHOLD = 12.5f;
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
        if ((selectionBegin - selectionEnd).magnitude < BOX_VS_POINT_THRESHOLD) {
            if (!isMouseOverBlockingUiElements()) {
                Unit unit = screenPointToUnit(selectionEnd);
                List<Unit> newSelection = new List<Unit>();
                if (unit != null) {
                    newSelection.Add(unit); 
                }
                selection.value = newSelection;
                newSelectionEvent.raise();
            }
        } else {
            Vector3 projectedBegin = screenPointToGround(selectionBegin);
            Vector3 projectedEnd = screenPointToGround(selectionEnd);
            selection.value = board.getUnitsFromSelectionBox(new Bounds(projectedBegin, projectedEnd));
            newSelectionEvent.raise();
        }
        
    }

    public void issueMoveCommand() {
        Vector3 destination = screenPointToGround(Input.mousePosition);
        foreach (Unit unit in selection.value) {
            if (unit is Mover) {
                (unit as Mover).move(destination);
            }
        }
    }

    private Vector3 screenPointToGround(Vector3 screenPoint) {
        int layer = 1 << 3;
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(screenPoint);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layer)) {
            return hit.point;
        } else {
            throw new System.Exception();
        }
    }

    private Unit screenPointToUnit(Vector3 screenPoint) {
        
        int layer = 1 << 6;
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(screenPoint);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layer)) {
            return hit.transform.GetComponent<Unit>();
        }
        return null;
    }

    private bool isMouseOverBlockingUiElements() {
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        pointerEventData.position = Input.mousePosition;

        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData, raycastResults);
        foreach(RaycastResult raycastResult in raycastResults) {
            if (raycastResult.gameObject.layer == 5) {
                return true;
            }
        }
        return false;
    }
}
