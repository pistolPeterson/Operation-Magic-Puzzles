using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PressurePlate : MonoBehaviour
{
    public static event Action pressurePlatePressed;
    public string activationObjectTag = "Rock";


    private bool isCheckingDistance = false;
    private GameObject activationObject = null;
    private bool isActivated = false;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (isCheckingDistance && activationObject != null && !isActivated)
        {


            float dist = Vector3.Distance(activationObject.transform.position, this.gameObject.transform.position);
            Debug.Log(dist);
            if (dist < 0.1f)
            {
                Debug.Log("OBJECT IS RIGHT ON TOP");
                isActivated = true;
            }
        }
        //if check distance state is on 
        //check the distance 
        //if distance is satisfied 
        //invoke, and isInvoked is true
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject.CompareTag(activationObjectTag))
        {
            Debug.Log("hit rock");
            //unlock check distance state
            isCheckingDistance = true;
            activationObject = collider.gameObject;
        }
    }


    private void OnTriggerExit2D(Collider2D collider)
    {
        isCheckingDistance = false;
        activationObject = null;
    }
}
