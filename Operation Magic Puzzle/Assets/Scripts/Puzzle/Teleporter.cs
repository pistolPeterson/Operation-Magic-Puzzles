using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private int amountOfUses = 2;
    [SerializeField] private Transform entry, exit;
    private bool moveToTeleporter = false;
    private void Start()
    {
        entry = transform.GetChild(0);
        exit = transform.GetChild(1);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(TeleportPlayer(collision.gameObject));
        }

    }

    private void Update()
    {
        if (moveToTeleporter)
        {
            Transform player = GameObject.FindGameObjectWithTag("Player").transform;
            player.transform.position = Vector3.MoveTowards(player.transform.position, entry.position, 20 * Time.deltaTime);
            if (player.position == entry.position)
            {
                amountOfUses--;
                moveToTeleporter = false;
            }
        }
    }

    void setActive()
    {
        //isActive = true;
    }

    IEnumerator TeleportPlayer(GameObject player)
    {
        if (amountOfUses <= 0) yield break;


        player.GetComponent<PlayerController>().FreezePlayer();
        player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        moveToTeleporter = true; //sets off moving player to teleport in update function
        yield return new WaitForSeconds(1.5f);
        player.transform.position = exit.transform.position;
        player.GetComponent<PlayerController>().UnFreezePlayer();
    }
}
