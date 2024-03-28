using System.Collections.Generic;
using UnityEngine;

public class EnemyCheck : MonoBehaviour
{
    public Transform enemyParent;
    public int enemyCount = 0;

    [SerializeField]
    private GameObject[] objectsToDisable;

    [SerializeField]
    private GameObject[] objectsToEnable;

    void Start()
    {
        if (enemyParent == null)
        {
            Debug.LogError("Parent object reference is not assigned!");
            return;
        }
        enemyCount = enemyParent.childCount;

        if(enemyCount == 0)
        {
            Objects(); 
        }
    }

    void Update()
    {
        int currentEnemyCount = enemyParent.childCount;

        if (currentEnemyCount != enemyCount)
        {
            enemyCount = currentEnemyCount;
            if (currentEnemyCount == 0)
            {
                Objects();
            }
        }
    }

    void Objects()
    {
        foreach (GameObject obj in objectsToDisable)
        {
            obj.SetActive(false);
        }

        foreach (GameObject obj in objectsToEnable)
        {
            obj.SetActive(true);
        }
    }
}
