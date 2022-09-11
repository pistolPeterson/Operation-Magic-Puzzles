using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target;
    private float followSpeed = 5f;
    [SerializeField] bool canFollow = false;
    private Animator anim;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();

    }
    private void Update()
    {

        if (canFollow)
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.transform.position.x, target.transform.position.y, -10f), followSpeed * Time.deltaTime);
    }

    public void setCanFollow(bool boolState)
    {
        canFollow = boolState;
        anim.enabled = false;
        
    }
}
