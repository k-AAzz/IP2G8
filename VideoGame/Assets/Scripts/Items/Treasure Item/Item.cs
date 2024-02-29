using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("Passed In Variables")]
    private Sprite chosenItem;
    private Sprite[] itemsArray;

    [Header("Sending Variables")]
    public string itemName;
    public string description;
    public string rarity;
    public ItemPopup itemDisplay;

    public void Start()
    {
        itemDisplay = GameObject.FindGameObjectWithTag("ItemPopup").GetComponent<ItemPopup>();
    }
    public void InitializeItem(Sprite chosenItem, Sprite[] itemsArray)
    {
        this.chosenItem = chosenItem;
        this.itemsArray = itemsArray;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            switch (chosenItem.name)
            {
                case "boots_item":
                    //Boots Action
                    PlayerControls playerControls = other.GetComponent<PlayerControls>();
                    playerControls.StatboostSpeed();

                    itemName = "Boots of Swiftness";
                    description = "Gives the player a bonus movespeed of 10%";
                    rarity = "rare";

                    Debug.Log("Bonus MoveSpeed!");
                break;

                case "heart_item_0":
                    //Health Action
                    PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
                    playerHealth.maxHealthIncrease();

                    itemName = "Heart Crystal";
                    description = "Grants a bonus Heart Container";
                    rarity = "epic";

                    Debug.Log("Bonus Health!");
                break;

                case "ring_item":
                    //Ring Action

                    itemName = "Amulet of Vitality";
                    description = "Gives the player a bonus movespeed of 10%";
                    rarity = "blessed";

                    Debug.Log("Amulet of Vitality!");
                    break;


                //Default Action
                default:
                    Debug.LogWarning("Nothing Assigned: " + chosenItem.name);
                    break;
            }
            //Destroy object after collision with player
            Destroy(gameObject);
            itemDisplay.ItemDisplay(itemName, description, rarity);
        }
    }
}
 