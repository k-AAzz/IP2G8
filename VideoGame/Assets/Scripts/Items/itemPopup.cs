using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemPopup : MonoBehaviour
{
    [Header("Text References")]
    public TextMeshProUGUI itemNameText;
    public TextMeshProUGUI descriptionText;
    public Text rarityText;

    [Header("Tween References")]
    public float fadeInTime = 1.0f;
    public float moveUpDistance = 50.0f;
    public float fadeOutTime = 1.0f;
    public float delayBeforeFadeOut = 3.0f;


    public void Start()
    {
        //Hide texts
        itemNameText.canvasRenderer.SetAlpha(0f);
        descriptionText.canvasRenderer.SetAlpha(0f);
    }

    public void ItemDisplay(string itemName, string description, string rarity)
    {
        //Assign passed in values
        itemNameText.text = itemName.ToUpper();
        descriptionText.text = description;

        //Call Functions
        RarityColour(rarity);
        StartCoroutine(AnimatePopup());
    }

    private void RarityColour(string rarity)
    {
        Color textColor;

        // You can define your own RGB values for each rarity
        switch (rarity.ToLower())
        {
            case "common":
                textColor = new Color(1f, 255f, 1f);
                break;

            case "rare":
                textColor = new Color(255f, 1f, 0f);
                break;

            case "epic":
                textColor = new Color(0f, 0f, 255f);
                break;

            case "legendary":
                textColor = new Color(255f, 255f, 1f);
                break;

            case "blessed":
                textColor = new Color(0f, 255f, 255f); // Blue
                break;

            default:
                textColor = Color.white;
                break;
        }

        // Debug statements to verify the color values
        Debug.Log($"Rarity: {rarity}, Color: {textColor}");

        // Set the color of the itemNameText
        itemNameText.color = textColor;
    }

    private IEnumerator AnimatePopup()
    {
        //Set intial  values
        itemNameText.canvasRenderer.SetAlpha(0f);
        descriptionText.canvasRenderer.SetAlpha(0f);

        //Fade in timers
        itemNameText.CrossFadeAlpha(1.0f, fadeInTime, true);
        descriptionText.CrossFadeAlpha(1.0f, fadeInTime, true);

        //Set target positions for the objects
        Vector3 itemNameStartPos = itemNameText.transform.position;
        Vector3 itemNameTargetPos = itemNameStartPos + new Vector3(0f, moveUpDistance, 0f);

        Vector3 descriptionStartPos = descriptionText.transform.position;
        Vector3 descriptionTargetPos = descriptionStartPos + new Vector3(0f, moveUpDistance, 0f);

        float elapsedTime = 0f;

        while (elapsedTime < fadeInTime)
        {
            itemNameText.transform.position = Vector3.Lerp(itemNameStartPos, itemNameTargetPos, elapsedTime / fadeInTime);
            descriptionText.transform.position = Vector3.Lerp(descriptionStartPos, descriptionTargetPos, elapsedTime / fadeInTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        //Hold text on screen before moving down
        yield return new WaitForSeconds(delayBeforeFadeOut);

        //Fade out the text
        itemNameText.CrossFadeAlpha(0f, fadeOutTime, true);
        descriptionText.CrossFadeAlpha(0f, fadeOutTime, true);

        //Move it back down
        elapsedTime = 0f;

        while (elapsedTime < fadeOutTime)
        {
            itemNameText.transform.position = Vector3.Lerp(itemNameTargetPos, itemNameStartPos, elapsedTime / fadeOutTime);
            descriptionText.transform.position = Vector3.Lerp(descriptionTargetPos, descriptionStartPos, elapsedTime / fadeOutTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

}