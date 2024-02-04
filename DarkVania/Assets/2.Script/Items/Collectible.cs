using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int arrowsToGive;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log(arrowsToGive);
            
      
            
                Arrow.instance.Arrows(arrowsToGive);
            
            Destroy(gameObject);
        }
    }
}
