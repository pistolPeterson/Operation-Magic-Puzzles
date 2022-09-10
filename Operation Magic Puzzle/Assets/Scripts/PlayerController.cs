using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 200f;
    float x_input;
    float y_input;

    private bool freezePlayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        x_input = Input.GetAxisRaw("Horizontal");
        y_input = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        if (!freezePlayer)
            MovePlayer();
    }

    public void FreezePlayer()
    {
        freezePlayer = true;
    }

    public void UnFreezePlayer()
    {
        freezePlayer = false;
    }
    void MovePlayer()
    {
        rb.velocity = new Vector2(x_input * speed * Time.deltaTime, y_input * speed * Time.deltaTime);
    }
}
