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

    public void InitializeItem(Sprite itemSprite, string itemLevel, string modDescription)
    {
        WeaponImage.sprite = itemSprite;
        WeaponName.text = itemLevel;
        WeaponLevel.text = modDescription;
    }
}
