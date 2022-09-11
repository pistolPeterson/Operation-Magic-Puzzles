using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private int amountOfUses = 2;
    [SerializeField] private Transform entry, exit;
    private bool moveToTeleporter = false;
    [SerializeField] Sprite activatedSprite;
    private enum TeleporterType { Default, PressurePlate}
    [SerializeField] TeleporterType type;
    private bool isActive = false;

    private void Start()
    {
        entry = transform.GetChild(0);
        exit = transform.GetChild(1);

        if(type == TeleporterType.Default)
        {
            isActive = true;
            entry.gameObject.GetComponent<SpriteRenderer>().sprite = activatedSprite;
        }
    }

    private void OnEnable()
    {
        PressurePlate.activatedAction += ActivateTeleporter;
    }

    private void OnDisable()
    {
        PressurePlate.activatedAction -= ActivateTeleporter;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && isActive)
        {
            StartCoroutine(TeleportPlayer(collision.gameObject));
        }

    }

    private void Update()
    {
        if (moveToTeleporter)
        {
            Transform player = GameObject.FindGameObjectWithTag("Player").transform;
            player.transform.position = Vector3.MoveTowards(player.transform.position, new Vector3(entry.position.x, entry.position.y - 0.5f, entry.position.z), 20 * Time.deltaTime);
            if (Vector3.Distance(player.transform.position, entry.position) <= 0.5f)
            {
                amountOfUses--;
                moveToTeleporter = false;
            }
        }
    }

    void ActivateTeleporter()
    {
        isActive = true;
        entry.gameObject.GetComponent<SpriteRenderer>().sprite = activatedSprite;
    }

    IEnumerator TeleportPlayer(GameObject player)
    {
        if (amountOfUses <= 0) yield break;


        player.GetComponent<PlayerController>().FreezePlayer();
        player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        moveToTeleporter = true; //sets off moving player to teleport in update function
        yield return new WaitForSeconds(1.5f);
        player.transform.position = new Vector3(exit.position.x, exit.position.y - 0.5f, exit.position.z);
        player.GetComponent<PlayerController>().UnFreezePlayer();
    }
}
