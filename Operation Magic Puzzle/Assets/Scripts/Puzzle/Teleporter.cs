using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private int amountOfUses = 2;
    [SerializeField] private Transform entry, exit;
    private bool moveToTeleporter = false;
    [SerializeField] Sprite activatedSprite;
    private enum TeleporterType { Default, PressurePlate, TeacherDialogue }
    [SerializeField] TeleporterType type;
    private bool isActive = false;

    [SerializeField] private AudioSource audioSource;
    public AudioClip entrySFX;
    public AudioClip exitSFX;

    private void Start()
    {
        entry = transform.GetChild(0);
        exit = transform.GetChild(1);

        if (type == TeleporterType.Default)
        {
            isActive = true;
            entry.gameObject.GetComponent<SpriteRenderer>().sprite = activatedSprite;
        }
    }

    private void OnEnable()
    {
        PressurePlate.activatedAction += ActivateTeleporter;
        if (type == TeleporterType.TeacherDialogue)
        {
            DialogueController.endDialogue += ActivateTeleporter;
        }
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
            player.transform.position = Vector3.MoveTowards(player.transform.position, new Vector3(entry.position.x - 1f, entry.position.y - 1f, entry.position.z), 20 * Time.deltaTime);
            if (Vector3.Distance(player.transform.position, entry.position) <= 1.5f)
            {
                amountOfUses--;
                moveToTeleporter = false;
            }
        }
    }

    void ActivateTeleporter()
    {
        isActive = true;
        if (entry != null)
            entry.gameObject.GetComponent<SpriteRenderer>().sprite = activatedSprite;
    }

    IEnumerator TeleportPlayer(GameObject player)
    {
        if (amountOfUses <= 0) yield break;
        audioSource.PlayOneShot(entrySFX);
        player.GetComponent<PlayerController>().FreezePlayer();
        player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        moveToTeleporter = true; //sets off moving player to teleport in update function
        yield return new WaitForSeconds(1.5f);
        audioSource.PlayOneShot(exitSFX);
        player.transform.position = new Vector3(exit.position.x - 1f, exit.position.y - 1f, exit.position.z);
        player.GetComponent<PlayerController>().UnFreezePlayer();
    }
}
