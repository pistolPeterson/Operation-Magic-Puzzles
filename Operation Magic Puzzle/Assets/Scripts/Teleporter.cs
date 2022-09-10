using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] Transform entry, exit;
    private bool moveToTeleporter = false;


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
            player.transform.position = Vector3.MoveTowards(player.transform.position, entry.position, 15 * Time.deltaTime);
            if(player.position == entry.position)
            {
                moveToTeleporter = false;
            }
        }
    }

    IEnumerator TeleportPlayer(GameObject player)
    {
        player.GetComponent<PlayerController>().enabled = false;
        player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        moveToTeleporter = true;
        yield return new WaitForSeconds(2f);
        player.transform.position = exit.transform.position;
        player.GetComponent<PlayerController>().enabled = true;
    }
}
