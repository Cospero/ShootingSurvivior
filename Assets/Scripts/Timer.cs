using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : Scen
{
    public float totalTime = 5; 
    public TMP_Text timerText;
    





    private void Start()
    {
        timerText.text = totalTime.ToString();
        
    }

    private void Update()
    {
        totalTime -= Time.deltaTime;
        timerText.text = Mathf.Round(totalTime).ToString();
        if (totalTime <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}