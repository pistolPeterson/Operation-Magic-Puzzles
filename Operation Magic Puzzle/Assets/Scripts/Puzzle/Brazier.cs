using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brazier : MonoBehaviour
{
    private bool isActive = false;
    private GameObject spellUI;

    private void OnEnable()
    {
        Spellcaster.fireCast += ActivateBrazier;
    }

    private void OnDisable()
    {
        Spellcaster.fireCast -= ActivateBrazier;
    }
    private void Start()
    {
        spellUI = transform.GetChild(0).gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && isActive == false)
        {
            spellUI.SetActive(true);
        }
    }

    private void ActivateBrazier()
    {
        Debug.Log("Brazier has been activated");
        spellUI.SetActive(false);
        isActive = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && isActive == false)
        {
            spellUI.SetActive(false);
        }
    }










}
