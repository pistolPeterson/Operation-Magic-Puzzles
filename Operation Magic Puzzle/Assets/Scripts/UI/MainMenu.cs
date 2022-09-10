using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    public GameObject playButton;
    public GameObject creditsButton;
    public GameObject AudioButton;

    public GameObject creditsPanel;

    private bool isPanelOn = false;
    private PlayerController playerController;
    private CameraFollow cameraFollow;

    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        playerController.FreezePlayer();
        cameraFollow = FindObjectOfType<CameraFollow>();

        creditsPanel.SetActive(isPanelOn);
    }

    // Update is called once per frame
    void Update()
    {

    }


    //will remove all main menu UI Elements 
    //unlock player movement 
    //make camera follow player

    public void Play()
    {
        DisableObjects();
        playerController.UnFreezePlayer();
        cameraFollow.setCanFollow(true);
        FindObjectOfType<GameplayUI>().SetCurrentLevelText();

    }

    public void ToggleCreditsPanel()
    {
        isPanelOn = !isPanelOn;
        creditsPanel.SetActive(isPanelOn);

    }
    public void DisableObjects()
    {
        playButton.SetActive(false);
        creditsButton.SetActive(false);
        AudioButton.SetActive(false);
    }
}
