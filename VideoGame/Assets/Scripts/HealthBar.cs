using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public GameObject heartPrefab;

    public PlayerHealth playerHealth;

    List<HealthHearts> hearts = new List<HealthHearts>();

    void Start()
    {
        DrawHearts(); 
    }

    private void OnEnable()
    {
        PlayerHealth.OnPlayerDamaged += DrawHearts;
    }
    private void OnDisable()
    {
        PlayerHealth.OnPlayerDamaged += DrawHearts;
    }
    public void DrawHearts()
    {
        ClearHearts();

        // creates number of hearts based on max health
        float maxHealthRemainder = playerHealth.maxHealth % 2;

        int heartsToMake = (int)((playerHealth.maxHealth / 2) + maxHealthRemainder);

        for (int i = 0; i < heartsToMake; i++)
        {
            CreateEmptyHeart();
        }

        // sets each heart to the correct fullness
        for(int i = 0; i < hearts.Count; i++)
        {
            int heartsStatusRemainder= (int)Mathf.Clamp(playerHealth.health - (i*2), 0, 2);

            hearts[i].SetHeartImage((HeartStatus)heartsStatusRemainder);
        }
    }
    public void CreateEmptyHeart()
    {
        // Instantiates hearts at hud
        GameObject newHeart = Instantiate(heartPrefab);
        newHeart.transform.SetParent(transform);

        // starts the hearts as empty
        HealthHearts heartComponent = newHeart.GetComponent<HealthHearts>();
        heartComponent.SetHeartImage(HeartStatus.Empty);

        hearts.Add(heartComponent);
    }
    public void ClearHearts()
    {
        foreach(Transform t in transform)
        {
            Destroy(t.gameObject);
        }

        hearts = new List<HealthHearts>();
    }
}
