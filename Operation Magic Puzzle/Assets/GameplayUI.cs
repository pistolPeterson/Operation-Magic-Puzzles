using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GameplayUI : MonoBehaviour
{
    [SerializeField] private GameObject currentLevelObj;
    [SerializeField] private TextMeshProUGUI currentLevelText;
    // Start is called before the first frame update
    void Start()
    {
        currentLevelObj.SetActive(false);
        DontDestroyOnLoad(this.gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Reset scene!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void SetCurrentLevelText()
    {
        currentLevelObj.SetActive(true);
        var scene = FindObjectOfType<SceneTransition>();
        if (scene != null)
            currentLevelText.text = "Level " + scene.currentLevel + " ";
    }
}
