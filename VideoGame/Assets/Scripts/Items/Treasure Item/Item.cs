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

                //Common Items

                case "bootsOfSwiftness":
                    //Boots Action
                    PlayerControls playerControls = other.GetComponent<PlayerControls>();
                    playerControls.StatboostSpeed();

                    itemName = "Boots of Swiftness";
                    description = "Gives the player a bonus movespeed of 10%";
                    rarity = "common";

                    Debug.Log("Bonus MoveSpeed!");
                break;

                case "gauntletsOfStrength":
                    //Health Action
                    PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
                    playerHealth.MaxHealthIncrease();

                    itemName = "Gauntlet's Of Strength";
                    description = "Grants a bonus Heart Container";
                    rarity = "common";

                    Debug.Log("Bonus Health!");
                break;

                case "steelCapBoots":
                    //Ring Action

                    itemName = "Steelcap Boots";
                    description = "Gives the player a bonus movespeed of 10%";
                    rarity = "common";

                    Debug.Log("Amulet of Vitality!");
                    break;

                case "charmOfFortune":
                    //Ring Action

                    itemName = "Charm Of Fortune";
                    description = "Gives the player a bonus movespeed of 10%";
                    rarity = "common";

                    Debug.Log("Amulet of Vitality!");
                    break;

                //Rare Items

                case "frozenSphere":
                    //Ring Action

                    itemName = "Frozen Sphere";
                    description = "Gives the player a bonus movespeed of 10%";
                    rarity = "rare";

                    Debug.Log("Amulet of Vitality!");
                    break;

                case "teatheredHearts":
                    //Ring Action

                    itemName = "Teathered Hearts";
                    description = "Gives the player a bonus movespeed of 10%";
                    rarity = "rare";

                    Debug.Log("Amulet of Vitality!");
                    break;

                //Epic Items

                case "Amulet Of Ascendence":
                    //Ring Action

                    itemName = "Frozen Sphere";
                    description = "Gives the player a bonus movespeed of 10%";
                    rarity = "epic";

                    Debug.Log("Amulet of Vitality!");
                    break;

                //Legendary Items

                //Blessed Items




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
 