using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewItem : MonoBehaviour
{
    [SerializeField] private Image WeaponImage;
    [SerializeField] private TMP_Text WeaponName;
    [SerializeField] private TMP_Text WeaponDescription;

    public void InitializeItem(Sprite itemSprite, string itemname, string itemDescription)
    {
        WeaponImage.sprite = itemSprite;
        WeaponName.text = itemname;
        WeaponDescription.text = itemDescription;
    }
}
