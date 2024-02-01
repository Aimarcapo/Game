using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Image healthImg;
    public float inmunityTime;
    bool isInmune;
    Blink material;
    SpriteRenderer sprite;
    public float knockbackForceX;
    public float knockbackForceY;
    Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        material = GetComponent<Blink>();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthImg.fillAmount = health/maxHealth;
        if(health>maxHealth)
        {
            health = maxHealth;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy")&& !isInmune)
        {
            health -= collision.GetComponent<Enemy>().damageToGive;
            if (collision.transform.position.x < transform.position.x)
            {
                rigidbody2D.AddForce(new Vector2(knockbackForceX, knockbackForceY), ForceMode2D.Force);
            }
            else
            {
                rigidbody2D.AddForce(new Vector2(-knockbackForceX, knockbackForceY), ForceMode2D.Force);
            }
            StartCoroutine(Inmunity());
            if(health <=0)
            {
                //Pantalla de game over
                print("player dead");
            }
        }
    }
    IEnumerator Inmunity()
    {
        isInmune= true;
        sprite.material = material.blink;
        yield return new WaitForSeconds(inmunityTime);
        sprite.material = material.original;
        isInmune = false;
    }
}
