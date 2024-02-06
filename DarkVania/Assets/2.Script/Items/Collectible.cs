using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int heartsToGive;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           // Debug.Log(heartsToGive);
            
      
            
                Heart.instance.Hearts(heartsToGive);
            
            Destroy(gameObject);
        }
    }
}
