using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Brazier : MonoBehaviour
{
    private bool isActive = false;
    public static event Action brazierEnabled;
    enum BrazierType { Fire, Water }
[SerializeField] BrazierType type;

    private GameObject spellUI;


    private void OnEnable()
    {
        Spellcaster.fireCast += type == BrazierType.Fire ? ActivateBrazier : NoEffect;
        Spellcaster.waterCast += type == BrazierType.Water ? ActivateBrazier : NoEffect;

    }
    private void OnDisable()
    {
        Spellcaster.fireCast -= type == BrazierType.Fire ? ActivateBrazier : NoEffect;
        Spellcaster.waterCast -= type == BrazierType.Water ? ActivateBrazier : NoEffect;
    }

    private void ActivateBrazier()
    {
        Debug.Log("Activated");
    }
    private void NoEffect()
    {
        Debug.Log("No Effect");
    }
   
    private void Start()
    {
        spellUI = transform.GetChild(0).gameObject;
        spellUI.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && isActive == false)
        {
            spellUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && isActive == false)
        {
            spellUI.SetActive(false);
        }
    }










}
