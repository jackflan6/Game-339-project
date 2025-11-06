using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardRoulette : MonoBehaviour
{
    public SpriteRenderer displayRenderer;
    public List<Sprite> cardSprites;

    private Sprite selectedCard;

    public void Spin()
    {
        StartCoroutine(SpinRoutine());
    }

    IEnumerator SpinRoutine()
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
        
        //selected card comes from the gacha manacher
        displayRenderer.sprite = selectedCard;
    }
}
