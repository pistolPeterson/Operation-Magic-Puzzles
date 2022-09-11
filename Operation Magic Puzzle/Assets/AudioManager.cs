using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicManager;
    public AudioClip mainMenu;
    public AudioClip gameplay;
    bool playGameplayMusic;
    // Start is called before the first frame update



    public static AudioManager Instance { get; private set; }
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        musicManager.clip = mainMenu;
        musicManager.Play();
        playGameplayMusic = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1 && !playGameplayMusic)
        {
            musicManager.clip = gameplay;
            musicManager.Play();
            playGameplayMusic = true;
        }

        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            Destroy(this.gameObject);
        }
    }
}
