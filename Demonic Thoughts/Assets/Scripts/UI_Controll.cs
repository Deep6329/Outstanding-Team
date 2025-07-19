using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Controll : MonoBehaviour
{
    [Header("Music Volume")]
    [SerializeField] Slider sld_music_Volume;
    [SerializeField] AudioSource m_AudioSourceMusic;
    //private Slider sld_music_Vol_GO;
    private float sld_music_Vol_Float;

    [Header("Sound Volume")]
    [SerializeField] Slider sld_sound_Volume;
    [SerializeField] AudioSource m_AudioSourceSound;
    //private Slider sld_sound_Vol_GO;
    private float sld_sound_Vol_Float;

    [Header("Toggle Full Screen")]
    [SerializeField] Toggle m_toggleFullscreen;

    private void Update()
    {
        sld_music_Vol_Float = sld_music_Volume.value;
        sld_sound_Vol_Float = sld_sound_Volume.value;        
    }
    public void LoadStartingScene()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SetBackgroundVolume()
    {
        m_AudioSourceMusic.volume = sld_music_Vol_Float;
    }

    public void SetSoundVolume()
    {
        m_AudioSourceSound.volume = sld_sound_Vol_Float;
    }

    public void ToggleFullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
        //if (m_toggleFullscreen.isOn)
        //{

        //}
        //else
        //{

        //}
    }
}
