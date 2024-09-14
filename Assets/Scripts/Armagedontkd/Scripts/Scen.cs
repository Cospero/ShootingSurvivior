using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Scen : MonoBehaviour
{

    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject PlayMenu;
    [SerializeField] private GameObject Shop;
    [SerializeField] private GameObject Settings;

    public void Changer(bool isShop)
    {
        if (isShop)
        {
            Shop.SetActive(!Shop.activeSelf);
        }
        else
        {
            PlayMenu.SetActive(!PlayMenu.activeSelf);
        }

        MainMenu.SetActive(!MainMenu.activeSelf);
    }

    public void Setting()
    {
        MainMenu.SetActive(!MainMenu.activeSelf);
        Settings.SetActive(!Settings.activeSelf);
    }


    public void ChangeScene(int numberScenes)
    {
        SceneManager.LoadScene(numberScenes);
    }


    public void Exit()
    {
        Application.Quit();
    }




}
