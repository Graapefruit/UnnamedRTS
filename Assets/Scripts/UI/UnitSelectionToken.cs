using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitSelectionToken : MonoBehaviour
{
    public UnitListReference selectedUnits;
    public Image image;
    private Unit unit;
    public Unit RepresentedUnit {
        get {
            return unit;
        }
        set {
            unit = value;
            image.sprite = unit.baseStatBlock.icon;
        }
    }
    public GameEvent onSelectionEvent;

    public void selectUnitFromToken() {
        List<Unit> newList = new List<Unit>();
        newList.Add(unit); 
        selectedUnits.value = newList;
        onSelectionEvent.raise();
    }
}
