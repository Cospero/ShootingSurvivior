using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using System;

public class PlayerExpiriense : MonoBehaviour
{
    private int _currentLevel;
    private int _currentExp;
    private int _expToNewLvl = 10;
    private float _vacuumSpeed = 6f;
    private List<GameObject> LevelUpItems = new List<GameObject>();

    [SerializeField] private float epxTakingRange;
    [SerializeField] private LayerMask expLayer;
    [SerializeField] private Slider _expSlider;
    [SerializeField] private TMP_Text _expText;
    [SerializeField] private TMP_Text _levelText;
    [SerializeField] GameObject LevelUpPanel;
    [SerializeField] GameObject UpdateGridLayout;

    [SerializeField] private ItemManager _weaponManager;

    private void Start()
    {
        UpdateLevelUi();
    }

    private void Update()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, epxTakingRange, expLayer);

        if(hitColliders.Length > 0 )
        {
            foreach (Collider2D col in hitColliders)
            {
                col.transform.position = Vector3.MoveTowards(col.transform.position, transform.position, _vacuumSpeed*Time.deltaTime);
                if (Vector2.Distance(col.transform.position, transform.position) < 0.5f)
                {
                    ConsumeExpChard(col.gameObject);
                }
            }
        }      
    }


    private void ConsumeExpChard(GameObject expChard)
    {
        _currentExp++;
        Destroy(expChard);

        UpdateLevelState();
    }

    private void UpdateLevelState()
    {
        _currentExp++;
        if (_currentExp>=_expToNewLvl)
        {
            LevelUp();
            _currentLevel++;
            _currentExp = 0;
            _expToNewLvl = _expToNewLvl + (int)(_expToNewLvl*0.2);
        }

        UpdateLevelUi();
    }

    private void UpdateLevelUi()
    {
        _expSlider.value= (float)(_currentExp/ (float)_expToNewLvl);
        _expText.text = ($"{_currentExp} / {_expToNewLvl}");
        _levelText.text= _currentLevel.ToString();
    }

    private void LevelUp()
    {
        LevelUpPanel.SetActive(true);
        
        foreach (Item item in _weaponManager.itemSlots)
        {
            if (item == null)
            {
                continue;
            }

            Debug.Log(!item.ReachMaxLevel());

            if (!item.ReachMaxLevel())
            {
                UpdatedItem updateItem = Instantiate(Resources.Load<UpdatedItem>("LevelUp/UpdatedSkill"), Vector3.zero, Quaternion.identity);
                updateItem.transform.SetParent(UpdateGridLayout.transform);
                updateItem.InitializeItem(item.itemSptite, item.GetNextModificationText(), item.GetWeaponCurrentLevel().ToString());
                LevelUpItems.Add(updateItem.gameObject);
                Button button = updateItem.GetComponentInChildren<Button>();
                button.onClick.AddListener(() => item.ActivateNextModification());
                button.onClick.AddListener(() => CloseLevelUpPanel());
            }
        }
        Time.timeScale = 0f;
    }

    private void CloseLevelUpPanel()
    {
        foreach(GameObject item in LevelUpItems)
        {
            Destroy(item);
        }
        LevelUpItems.Clear();
        LevelUpPanel.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
