using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Controll : MonoBehaviour
{
    [SerializeField] GameObject sld_music_Volume;
    [SerializeField] AudioSource m_AudioSource;
    private Slider sld_music_Vol_GO;
    private float sld_music_Vol_Float;

    private void Start()
    {
        sld_music_Vol_GO = sld_music_Volume.GetComponent<Slider>();
    }
    private void Update()
    {
        sld_music_Vol_Float = sld_music_Vol_GO.value;
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
        Debug.Log("Slider Value: " + sld_music_Vol_Float);
        m_AudioSource.volume = sld_music_Vol_Float;
    }
}
