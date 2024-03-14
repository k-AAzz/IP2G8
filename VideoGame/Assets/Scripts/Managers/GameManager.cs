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

    [Header("Player Statuses")]
    public bool frozenSphere = false;
    public float frozenMultiplier = 12.5f;

    void Start()
    {
        gemCountText.text = gemCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
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
        if (!frozenSphere)
        {
            frozenSphere = true;
        }

        if(frozenSphere)
        {
            frozenMultiplier = (float)(frozenMultiplier * 1.3);
        }
    }
}
