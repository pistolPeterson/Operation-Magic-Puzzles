using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DialogueController : MonoBehaviour
{
    
    private Queue<string> dialogueQueue;
    public TextMeshProUGUI npcNameText, dialogueText;
    public GameObject dialogueSystem;

    public static event Action endDialogue;

    private void Start()
    {
        dialogueQueue = new Queue<string>();
    }

    public void ActivateDialogue(Dialogue dialogue)
    {
        dialogueSystem.SetActive(true);
        dialogueQueue.Clear();
        foreach(string sentence in dialogue.sentences)
        {
            dialogueQueue.Enqueue(sentence);
            npcNameText.text = dialogue.npcName;
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(dialogueQueue.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = dialogueQueue.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }

    }
    private void EndDialogue()
    {

        Debug.Log("Ending Dialogue");
        dialogueSystem.SetActive(false);
        endDialogue ?.Invoke();
    }
}