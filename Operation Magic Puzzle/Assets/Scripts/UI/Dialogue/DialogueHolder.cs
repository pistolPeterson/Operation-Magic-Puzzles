using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour
{
    public Dialogue dialogue;
    private bool canActivateDialogue, dialogueActive;
    [SerializeField] GameObject interactHint;

    private void OnEnable()
    {
        DialogueController.endDialogue += setDialogueActiveFalse;
    }
    private void OnDisable()
    {
        DialogueController.endDialogue -= setDialogueActiveFalse;
    }
    private void Start()
    {
        interactHint.SetActive(false);
    }

    public void setDialogueActiveFalse()
    {
        Debug.Log("Setting false");
        dialogueActive = false;
    }


    private void Update()
    {
        if (canActivateDialogue && !dialogueActive)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                ActivateDialogue();
                dialogueActive = true;
            }
        }
    }

    public void ActivateDialogue()
    {
        FindObjectOfType<DialogueController>().ActivateDialogue(dialogue);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            canActivateDialogue = true;
            interactHint.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            interactHint.SetActive(false);
            canActivateDialogue = false;
        }
    }

}
