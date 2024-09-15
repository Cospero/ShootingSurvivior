using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{

    [SerializeField] AudioClip[] audioClips;
    private int sceneIndex;
    private AudioSource mainMenuAudio;
    public Slider volumeSlider;
    private const string VolumePrefKey = "GameVolume";
    

    void Start()
    {

        mainMenuAudio = GetComponent<AudioSource>();
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (sceneIndex >= 0 && sceneIndex < audioClips.Length)
        {
            PlayClip(sceneIndex);
        }

        float savedVolume = PlayerPrefs.GetFloat(VolumePrefKey, 1f);
        mainMenuAudio.volume = savedVolume;
        if (volumeSlider != null)
        {
            volumeSlider.value = savedVolume;
            volumeSlider.onValueChanged.AddListener(ChangeVolume);
        }


    }

    public void ChangeVolume(float volume)
    {
        mainMenuAudio.volume = volume;

        PlayerPrefs.SetFloat(VolumePrefKey, volume);
        PlayerPrefs.Save();
    }

    void PlayClip(int index)
    {
        mainMenuAudio.clip = audioClips[index];
        mainMenuAudio.Play();
    }
}
