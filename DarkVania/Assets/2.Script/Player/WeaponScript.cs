using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = FindObjectOfType<PlayerController>().transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = FindObjectOfType<PlayerController>().transform.position;
    }
}
