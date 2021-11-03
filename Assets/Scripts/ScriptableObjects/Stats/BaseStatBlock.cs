using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BaseStatBlock : ScriptableObject {
    public string unitName;
    public float maxHp;
    public float speed;
    public int armour;
    public float parry;
    public float deflection;
    public Sprite icon;
    public MeleeWeaponStats meleeWeapon;
    public RangedWeaponStats rangedWeapon;
}
