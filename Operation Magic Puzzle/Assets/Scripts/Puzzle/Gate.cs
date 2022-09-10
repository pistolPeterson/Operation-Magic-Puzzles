using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    private SpriteRenderer sRenderer;
    private Collider2D myCollider;
    [SerializeField] Sprite openSprite;
    private bool isOpen = false;

    private void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();
        myCollider = GetComponent<Collider2D>();
    }

    private void OnEnable()
    {
        Brazier.brazierEnabled += OpenGate;
    }
    private void OnDisable()
    {
        Brazier.brazierEnabled -= OpenGate;
    }

    private void OpenGate()
    {
        sRenderer.sprite = openSprite;
        myCollider.enabled = false;
    }
}
