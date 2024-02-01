using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    float speed;
    Rigidbody2D rb;
    public bool isStatic;
    // Start is called before the first frame update
    void Start()
    {
     speed=GetComponent<Enemy>().speed;   
        rb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if(isStatic) { }
    }
}
