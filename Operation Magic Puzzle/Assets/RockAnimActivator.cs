using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockAnimActivator : MonoBehaviour
{

    private bool isPushing = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            isPushing = true;
            FindObjectOfType<PlayerController>().isNearRock = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            FindObjectOfType<PlayerController>().isNearRock = false;
            isPushing = false;
        }

    }
}
