using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedUnitStatPanel : MonoBehaviour {
    public UnitListReference unitsSelected;
    public Text noUnitSelectedText;
    public GameObject individualUnitSelection;
    public GameObject meleeWeaponSelection;
    public GameObject rangedWeaponSelection;
    public GameObject multipleUnitSelection;
    public Text unitNameText;
    public Text unitHpText;
    public Text unitArmourText;
    public Text unitSpeedText;
    public Text unitParryText;
    public Text unitDeflectionText;
    public Text meleeDamageText;
    public Text meleeIntervaltext;
    public Text rangeDamageText;
    public Text rangeIntervalText;
    public Text rangeRangeText;
    public Image unitImage;

    public void onNewUniSelection() {
        if (unitsSelected.value.Count < 1) {
            toggleNoUnitSelection(true);
            toggleIndividualUnitSelection(false);
            toggleMultipleUnitSelection(false);
        } else if (unitsSelected.value.Count == 1) {
            toggleNoUnitSelection(false);
            toggleIndividualUnitSelection(true);
            toggleMultipleUnitSelection(false);
        } else {
            toggleNoUnitSelection(false);
            toggleIndividualUnitSelection(false);
            toggleMultipleUnitSelection(true);
        }
    }

    private void toggleNoUnitSelection(bool enabled) {
        noUnitSelectedText.enabled = enabled;
    }

    private void toggleIndividualUnitSelection(bool enabled) {
        individualUnitSelection.SetActive(enabled);
        if(enabled) {
            BaseStatBlock baseStatBlock = unitsSelected.value[0].baseStatBlock;
            CurrentStatBlock currentStatBlock = unitsSelected.value[0].currentStatBlock;
            unitHpText.text = currentStatBlock.hp.ToString() + "/" + baseStatBlock.maxHp.ToString();
            unitArmourText.text = baseStatBlock.armour.ToString();
            unitSpeedText.text = baseStatBlock.speed.ToString();
            unitParryText.text = baseStatBlock.parry.ToString();
            unitDeflectionText.text = baseStatBlock.deflection.ToString();
            meleeWeaponSelection.SetActive(baseStatBlock.meleeWeapon != null);
            rangedWeaponSelection.SetActive(baseStatBlock.rangedWeapon != null);
            if (baseStatBlock.meleeWeapon != null) {
                meleeDamageText.text = baseStatBlock.meleeWeapon.weaponStrength.ToString();
                meleeIntervaltext.text = baseStatBlock.meleeWeapon.weaponInterval.ToString();
            }
            if (baseStatBlock.rangedWeapon != null) {
                rangeDamageText.text = baseStatBlock.rangedWeapon.weaponStrength.ToString();
                rangeIntervalText.text = baseStatBlock.rangedWeapon.weaponInterval.ToString();
                rangeRangeText.text = baseStatBlock.rangedWeapon.weaponRange.ToString();
            }
            unitImage.sprite = baseStatBlock.icon;
        }
    }

    private void toggleMultipleUnitSelection(bool enabled) {
        multipleUnitSelection.SetActive(enabled);
    }
}
