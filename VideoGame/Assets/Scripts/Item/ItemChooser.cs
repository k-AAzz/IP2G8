using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemChooser : MonoBehaviour
{
    [Header("Item Arrays")]
    public Sprite[] commonItems;
    public Sprite[] rareItems;
    public Sprite[] epicItems;
    public Sprite[] legendaryItems;

    [Header("References")]
    public GameObject spawnLocation;
    public GameObject player;
    public GameObject healthBar;
    
    // Start is called before the first frame update
    void Start()
    {
        //
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnRandomItem();
        }
    }

    public void SpawnRandomItem()
    {
        //Generate a random value between 0 -> 100
        int randomValue = Random.Range(0, 100);

        if (randomValue <= 69)
        {
            SpawnItem(commonItems);
        }
        else if (randomValue >= 70 && randomValue <= 85 )
        {
            SpawnItem(rareItems);
        }
        else if (randomValue >= 86 && randomValue <= 95)
        {
            SpawnItem(epicItems);
        }
        else
        {
            SpawnItem(legendaryItems);
        }

        Debug.Log(randomValue);
    }

    void SpawnItem(Sprite[] itemsArray)
    {
        if (itemsArray != null && itemsArray.Length > 0)
        {
            int randomIndex = Random.Range(0, itemsArray.Length);
            Sprite chosenItem = itemsArray[randomIndex];

            //Create the item above the pedastool
            GameObject newItem = new GameObject("NewItem");

            Vector3 offset = new Vector3(0, 0.8f, 0);

            newItem.transform.position = spawnLocation.transform.position;
            newItem.transform.position += offset;


            //Add a sprite renderer with values
            SpriteRenderer spriteRenderer = newItem.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = chosenItem;
            spriteRenderer.sortingOrder = 2;

            //Change the scale of the sprite / My references are too small can be removed later on
            float scaleMultiplier = 2f;
            newItem.transform.localScale = new Vector3(scaleMultiplier, scaleMultiplier, 1.0f);

            Debug.Log("Item: " + chosenItem.name);

            if (chosenItem.name == "Boots")
            {
                player.GetComponent<PlayerControls>().StatboostSpeed(); //Boots of swiftness from concept doc
                Debug.Log("Hell yeah");
            }
            if (chosenItem.name == "heart_item_0")
            {
                player.GetComponent<PlayerHealth>().maxHealthIncrease();
                healthBar.GetComponent<HealthBar>().DrawHearts(); //Enduring Vigor
                Debug.Log("What the");
            }
            if (chosenItem.name == "Ring")
            {
                player.GetComponent<PlayerHealth>().Start();
            }
        }
        else
        {
            Debug.Log("No item array is empty");
        }
    }
}
