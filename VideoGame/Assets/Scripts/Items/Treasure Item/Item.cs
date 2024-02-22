using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("Passed In Variables")]
    private Sprite chosenItem;
    private Sprite[] itemsArray;

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
                    if (playerControls != null)
                    {
                        playerControls.StatboostSpeed();
                        Debug.Log("Bonus MoveSpeed!");
                    }
                    break;

                case "heart_item_0":
                    //Health Action
                    PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
                    if (playerHealth != null)
                    {
                        playerHealth.maxHealthIncrease();
                        Debug.Log("Bonus Health!");
                    }
                    break;

                case "ring_item":
                    //Ring Action
                    break;

                //Default Action
                default:
                    Debug.LogWarning("Nothing Assigned: " + chosenItem.name);
                    break;
            }
            //Destroy object after collision with player
            Destroy(gameObject);
        }
    }
}
 