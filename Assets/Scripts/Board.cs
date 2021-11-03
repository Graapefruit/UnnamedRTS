using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public List<Unit> units;
    private const float LEFT_BOUND = 3.0f;
    private const float RIGHT_BOUND = -3.0f;
    private const float UPPER_BOUND = 3.0f;
    private const float LOWER_BOUND = -3.0f;

    void Start() {
        
    }

    void Update() {
        
    }

    public List<Unit> getUnitsFromSelectionBox(Bounds bounds) {
        List<Unit> rList = new List<Unit>();
        foreach (Unit unit in units) {
            if (bounds.pointEncapsulated(unit.transform.position)) {
                rList.Add(unit);
            }
        }
        return rList;
    }
}
