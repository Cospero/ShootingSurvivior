using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpdatedItem : MonoBehaviour
{
    [SerializeField] private Image WeaponImage;
    [SerializeField] private TMP_Text WeaponName;
    [SerializeField] private TMP_Text WeaponLevel;

    public void InitializeItem(Sprite weaponSptire, string weaponName, string weaponLevel)
    {
        WeaponImage.sprite = weaponSptire;
        WeaponName.text = weaponName;
        WeaponLevel.text = weaponLevel;
    }

}
