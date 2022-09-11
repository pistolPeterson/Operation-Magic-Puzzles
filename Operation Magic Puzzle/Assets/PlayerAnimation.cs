using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    //Animation states 
    public string BACK_LEFT = "BackLeft";
    public string BACK_RIGHT = "BackRight";
    public string FRONT_LEFT = "FrontLeft";
    public string FRONT_RIGHT = "FrontRight";

    public string PUSHING_BL = "PushBL";
    public string PUSHING_BR = "PushBR";
    public string PUSHING_FL = "PushFL";
    public string PUSHING_FR = "PushFR";

    [SerializeField] Animator animator;
    private string currentState;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;

        animator.Play(newState);
        Debug.Log(newState);
    }
}
