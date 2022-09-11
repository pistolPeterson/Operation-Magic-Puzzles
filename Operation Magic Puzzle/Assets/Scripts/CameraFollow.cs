using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target;
    private float followSpeed = 5f;
    [SerializeField] bool canFollow = false;
    private bool animateToPlayer;
    private Animator anim;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();

    }
    private void Update()
    {

        if (canFollow)
            transform.position = new Vector3(target.transform.position.x, target.transform.position.y, -10f);

        if (animateToPlayer)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.transform.position.x, target.transform.position.y, -10f), followSpeed * Time.deltaTime);
        }

        if(Vector3.Distance(target.transform.position, gameObject.transform.position) < 0.1f)
        {
            animateToPlayer = false;
        }
    }

    public IEnumerator CanFollow()
    {
        animateToPlayer = true;
        anim.enabled = false;
        yield return new WaitForSeconds(2f);
        canFollow = true;
    }
}
