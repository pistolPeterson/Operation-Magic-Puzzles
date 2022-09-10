using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GoalArea : MonoBehaviour
{
    public static event Action PlayerReachedGoal;
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
            PlayerReachedGoal?.Invoke();
            Debug.Log("Time to go to the next level!");
        }
    }
}
