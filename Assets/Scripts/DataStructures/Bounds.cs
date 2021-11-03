using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Bounds {
    public float left;
    public float right;
    public float top;
    public float bottom;
    public Bounds(float left, float right, float top, float bottom) {
        if (left > right) {
            Debug.Log("Bounds created with left greater than right!");
        } if (bottom > top) {
            Debug.Log("Bounds created with bottom greater than top");
        }
        this.left = left;
        this.right = right;
        this.top = top;
        this.bottom = bottom;
    }

    public Bounds(Vector3 point1, Vector3 point2) {
        left = Mathf.Min(point1.x, point2.x);
        right = Mathf.Max(point1.x, point2.x);
        top = Mathf.Min(point1.z, point2.z);
        bottom = Mathf.Max(point1.z, point2.z);
    }

    public bool pointEncapsulated(Vector3 point) {
        return point.x >= left && point.x <= right && point.z >= top && point.z <= bottom;
    }
}
