using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 150f;
    float x_input;
    float y_input;

    private bool freezePlayer;
    private PlayerAnimation playerAnim;
    public bool isNearRock = false;

    // Start is called before the first frame update
    void Start()
    {
        isNearRock = false;
        playerAnim = FindObjectOfType<PlayerAnimation>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        x_input = Input.GetAxisRaw("Horizontal");
        y_input = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        if (!freezePlayer)
            MovePlayer();
    }

    public void FreezePlayer()
    {
        freezePlayer = true;
    }

    public void UnFreezePlayer()
    {
        freezePlayer = false;
    }
    void MovePlayer()
    {
        // rb.velocity = new Vector2(x_input * speed * Time.deltaTime, y_input * speed * Time.deltaTime);
        //forces 4 directional movement 
        if (x_input != 0 && y_input == 0)
        {
            //do nothing
            //rb.velocity = new Vector2(x_input * speed * Time.deltaTime, 0);
        }
        else if (y_input != 0 && x_input == 0)
        {
            //do nothing
            //rb.velocity = new Vector2(x_input * speed * Time.deltaTime, 0);
        }
        else if (y_input == 0 && x_input == 0)
        {
            //do nothing
            //rb.velocity = new Vector2(x_input * speed * Time.deltaTime, 0);
            rb.velocity = new Vector2(0, 0);
        }
        else
        {
            rb.velocity = new Vector2(x_input * speed * Time.deltaTime, y_input * speed * Time.deltaTime);
            if (x_input > 0 && y_input > 0)
            {
                //play back right animation
                if (isNearRock)
                    playerAnim.ChangeAnimationState(playerAnim.PUSHING_BR);
                else
                    playerAnim.ChangeAnimationState(playerAnim.BACK_RIGHT);
            }

            if (x_input < 0 && y_input < 0)
            {
                //play front left animation
                if (isNearRock)
                    playerAnim.ChangeAnimationState(playerAnim.PUSHING_FL);
                else
                    playerAnim.ChangeAnimationState(playerAnim.FRONT_LEFT);
            }

            if (x_input < 0 && y_input > 0)
            {
                //play front left animation
                if (isNearRock)
                    playerAnim.ChangeAnimationState(playerAnim.PUSHING_BL);
                else
                    playerAnim.ChangeAnimationState(playerAnim.BACK_LEFT);
            }

            if (x_input > 0 && y_input < 0)
            {
                //play front left animation
                if (isNearRock)
                    playerAnim.ChangeAnimationState(playerAnim.PUSHING_FR);
                else
                    playerAnim.ChangeAnimationState(playerAnim.FRONT_RIGHT);
            }
        }



        /*if (x_input != 0)
        {
            rb.velocity = new Vector2(x_input * speed * Time.deltaTime, 0);
        }
        else if (y_input != 0)
        {
            rb.velocity = new Vector2(0, y_input * speed * Time.deltaTime);
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }
        */
    }


    private void OnEnable()
    {
        DialogueController.startDialogue += FreezePlayer;
        DialogueController.endDialogue += UnFreezePlayer;

    }
    private void OnDisable()
    {
        DialogueController.startDialogue -= FreezePlayer;
        DialogueController.endDialogue -= UnFreezePlayer;
    }
}
