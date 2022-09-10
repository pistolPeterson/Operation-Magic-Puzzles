using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{

    private Animator animator;
    private int levelToLoad;
    public int currentLevel;
    void Start()
    {
        animator = GetComponent<Animator>();
        currentLevel = SceneManager.GetActiveScene().buildIndex + 1;
    }

    void Update()
    {


    }
    private void OnEnable()
    {
        GoalArea.PlayerReachedGoal += FadeToNextLevel;
    }

    private void OnDisable()
    {
        GoalArea.PlayerReachedGoal -= FadeToNextLevel;
    }


    //Fade out go to next scene 
    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }
    public void FadeToNextLevel()
    {
        StartCoroutine(NextLevel());

    }
    private IEnumerator NextLevel()
    {
        Debug.Log("passed lvl, going to next lvl");
        animator.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void OnFadeComplete()
    {
        //SceneManager.LoadScene(levelToLoad);
        var x = FindObjectOfType<GameplayUI>();
        if (x != null)
            x.SetCurrentLevelText();
    }
}
