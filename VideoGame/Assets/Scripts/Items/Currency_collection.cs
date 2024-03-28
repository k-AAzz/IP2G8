using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency_collection : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            gameManager.AddGems(1);
            Destroy(gameObject);
            //    audioSource.Play();
        }
    }
}
