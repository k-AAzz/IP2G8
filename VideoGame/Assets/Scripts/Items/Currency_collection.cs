using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency_collection : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        //    audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
          
            Destroy(gameObject);
            //    audioSource.Play();
        }
    }
}
