using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PressurePlate : MonoBehaviour
{
    public string activationObjectTag = "Rock";


    private bool isCheckingDistance = false;
    private GameObject activationObject = null;
    private bool isActivated = false;

    public static event Action activatedAction;

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
            if (dist < 0.4f)
            {
                activationObject.GetComponent<Rigidbody2D>().mass = Int32.MaxValue;
                isActivated = true;
                activatedAction?.Invoke();
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
            //unlock check distance state
            isCheckingDistance = true;
            activationObject = collider.gameObject;
        }
    }


    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag(activationObjectTag))
        {
            isCheckingDistance = false;
            activationObject = null;
        }
    }
}
