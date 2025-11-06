using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardRoulette : MonoBehaviour
{
    private CardRoulette Instance;
    public SpriteRenderer displayRenderer;
    public List<Sprite> cardSprites;

    private Sprite selectedCard;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            cardSprites = new List<Sprite>(Resources.LoadAll<Sprite>("New Cards"));
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    
    public void Spin(string cardName)
    {
        Sprite targetCard = cardSprites.Find(sprite => sprite.name == cardName);

        if (targetCard == null)
        {
            Debug.LogError($"No sprite found that matches the name: {cardName}");
            return;
        }
        StartCoroutine(SpinRoutine(targetCard));
    }

    IEnumerator SpinRoutine(Sprite targetCard)
    {
        float totalSpinDuration = 5f;
        float minInterval = 0.03f;
        float maxInterval = 0.25f;

        float elapsed = 0f;

        while (elapsed < totalSpinDuration)
        {
            displayRenderer.sprite = cardSprites[Random.Range(0, cardSprites.Count)];

            float t = elapsed / totalSpinDuration;
            float currentInterval = Mathf.Lerp(minInterval, maxInterval, t);

            elapsed += currentInterval;
            yield return new WaitForSeconds(currentInterval);
        }

        selectedCard = targetCard;
        displayRenderer.sprite = selectedCard;
    }
}
