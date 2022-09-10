using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float followSpeed = 1f;
    private bool canFollow = false;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        if(canFollow)
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.transform.position.x, target.transform.position.y, -10f), followSpeed * Time.deltaTime);
    }

    public void setCanFollow(bool boolState)
    {
        canFollow = boolState;
    }
}
