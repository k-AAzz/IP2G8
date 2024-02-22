using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyItem : MonoBehaviour
{
    [Header("Passed In Variables")]
    private Sprite chosenItem;

    public void InitializeItem(Sprite chosenItem, Sprite[] itemsArray)
    {
        this.chosenItem = chosenItem;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            switch (chosenItem.name)
            {
                case "gems_0":
                    //Gems Item
                    Debug.Log("You Picked Up Gems");
                    break;

                case "heart_item_0":
                    //Heart Item
                    Debug.Log("You Picked Up a Heart");
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
