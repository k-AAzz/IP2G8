using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Gem References")]
    public int gemCount = 0;
    public TextMeshProUGUI gemCountText;

    [Header("Global References")]
    public float enemyDropChance = 40f;
    public List<Item> currentItems = new List<Item>();

    [Header("Player Statuses")]
    public bool frozenSphere = false;
    public float frozenMultiplier = 0.150f;
    public Material frozenMaterial;
    public GameObject frozenParticle;

    void Start()
    {
        gemCountText.text = gemCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DebugLogCurrentItems()
    {
        string itemList = "Current Items:\n";
        foreach (Item item in currentItems)
        {
            itemList += "Item Name: " + item.itemName + "\n";
            itemList += "Description: " + item.description + "\n";
            itemList += "Rarity: " + item.rarity + "\n\n";
        }
        Debug.Log(itemList);
    }

    public void AddGems(int amount)
    {
        gemCount += amount;
        UpdateGemCountText();
    }

    private void UpdateGemCountText()
    {
        gemCountText.text = gemCount.ToString();
    }

    public void ItemIncreaseDropRate()
    {
        enemyDropChance = (float)(enemyDropChance * 1.3);
    }

    public void ItemFrozenActive()
    {
        if (frozenSphere == false)
        {
            frozenSphere = true;
        }

        if(frozenSphere)
        {
            frozenMultiplier = (float)(frozenMultiplier * 1.3);
        }
    }
}
