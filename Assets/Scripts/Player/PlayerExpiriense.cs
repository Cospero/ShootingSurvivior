using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class PlayerExpiriense : MonoBehaviour
{
    private int _currentLevel;
    private int _currentExp;
    private int _expToNewLvl=10;
    private float _vacuumSpeed=6f;

    [SerializeField] private float epxTakingRange;
    [SerializeField] private LayerMask expLayer;
    [SerializeField] private Slider _expSlider;
    [SerializeField] private TMP_Text _expText;
    [SerializeField] private TMP_Text _levelText;

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
            _currentLevel++;
            _currentExp = 0;
            _expToNewLvl = _expToNewLvl + (int)(_expToNewLvl*0.2);
        }

        UpdateLevelUi();
    }

    private void UpdateLevelUi()
    {
        Debug.Log("slider text " + _currentExp / _expToNewLvl);
        _expSlider.value= (float)(_currentExp/ (float)_expToNewLvl);
        _expText.text = ($"{_currentExp} / {_expToNewLvl}");
        _levelText.text= _currentLevel.ToString();
    }

}
