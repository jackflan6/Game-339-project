using System;
using UnityEngine;

public class CardDisplay : MonoBehaviour
{
    public Card cardData;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer.sprite = cardData.sprite;
    }
}
