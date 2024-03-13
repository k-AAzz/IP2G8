using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class HealthSystem : MonoBehaviour
{
    [Header("Main References")]
    public GameObject heartPrefab;
    public Transform heartsParent;
    public GameObject shieldPrefab;

    [Header("Sprite References")]
    public Sprite fullHeartSprite;
    public Sprite halfHeartSprite;
    public Sprite emptyHeartSprite;
    public Sprite shieldSprite;

    [Header("Variables")]
    public int maxHealth = 6;
    public int currentHealth;
    public bool isDead;
    public bool hasShield = false;
    private List<GameObject> heartObjects = new List<GameObject>();
    private GameObject shieldObject;

    void Start()
    {
        currentHealth = maxHealth;
        InitializeHearts();
    }

    void Update()
    {
        // checks if player is dead
        if (currentHealth <= 0 && !isDead)
        {
            isDead = true;
            Destroy(gameObject);
        }
    }

    void InitializeHearts()
    {
        for (int i = 0; i < maxHealth / 2; i++)
        {
            GameObject heartInstance = Instantiate(heartPrefab, heartsParent);
            heartObjects.Add(heartInstance);
        }
    }

    public void TakeDamage(int amount)
    {
        if (hasShield)
        {
            hasShield = false;
            Destroy(shieldObject);
            return;
        }

        currentHealth -= amount;
        if (currentHealth < 0)
            currentHealth = 0;

        UpdateHeartsUI();
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;

        UpdateHeartsUI();
    }

    void UpdateHeartsUI()
    {
        int remainingHealth = currentHealth;
        int fullHearts = remainingHealth / 2;
        int halfHeart = remainingHealth % 2;

        for (int i = 0; i < heartObjects.Count; i++)
        {
            Image heartImage = heartObjects[i].GetComponent<Image>();

            if (remainingHealth >= 2)
            {
                heartImage.sprite = fullHeartSprite;
                remainingHealth -= 2;
            }
            else if (remainingHealth == 1)
            {
                heartImage.sprite = halfHeartSprite;
                remainingHealth -= 1;
            }
            else
            {
                heartImage.sprite = emptyHeartSprite;
            }
        }
    }

    public void ItemHealthIncrease()
    {
        maxHealth += 2;
        currentHealth += 2;

        GameObject heartInstance = Instantiate(heartPrefab, heartsParent);
        heartInstance.transform.SetAsLastSibling();

        heartObjects.Add(heartInstance);
        UpdateHeartsUI();
    }

    public void ItemShieldAdd()
    {
        hasShield = true;
        shieldObject = Instantiate(shieldPrefab, heartsParent);
        shieldObject.GetComponent<Image>().sprite = shieldSprite;
        shieldObject.transform.SetAsLastSibling();
    }
}
