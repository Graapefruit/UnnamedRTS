using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pair<T, V> {
    public T first;
    public V second;
    public Pair(T t, V v) {
        first = t;
        second = v;
    }
}
