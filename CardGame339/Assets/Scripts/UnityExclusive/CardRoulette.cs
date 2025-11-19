using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardRoulette : MonoBehaviour
{
    private CardRoulette Instance;
    public UnityEngine.UI.Image[] SlotImages;
    public RectTransform[] Panels;
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
    
    public void Spin(string cardName, UnityEngine.UI.Image targetImage, RectTransform targetPanel)
    {
        targetImage.transform.SetParent(targetPanel, false);
        Sprite targetCard = cardSprites.Find(sprite => sprite.name == cardName);

        if (targetCard == null)
        {
            Debug.LogError($"No sprite found that matches the name: {cardName}");
            return;
        }
        StartCoroutine(SpinRoutine(targetCard, targetImage));
    }
    

    IEnumerator SpinRoutine(Sprite targetCard, UnityEngine.UI.Image targetImage)
    {
        float totalSpinDuration = 5f;
        float minInterval = 0.03f;
        float maxInterval = 0.25f;

        float elapsed = 0f;

        while (elapsed < totalSpinDuration)
        {
            targetImage.sprite = cardSprites[Random.Range(0, cardSprites.Count)];

            float t = elapsed / totalSpinDuration;
            float currentInterval = Mathf.Lerp(minInterval, maxInterval, t);

            elapsed += currentInterval;
            yield return new WaitForSeconds(currentInterval);
        }

        selectedCard = targetCard;
        targetImage.sprite = selectedCard;
    }
}
