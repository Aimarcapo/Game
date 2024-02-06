using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    Enemy enemy;
    public bool isDamaged;
    public GameObject deathEffect;
    SpriteRenderer sprite;
    Blink material;
    Animator anim;
    Rigidbody2D rigidbody2D;
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        material = GetComponent<Blink>();
        enemy = GetComponent<Enemy>();
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Weapon") & !isDamaged)
        {
            Debug.Log("Caminando entra");
            enemy.healthPoints -= 1f;
            if (collision.transform.position.x < transform.position.x)
            {
                Debug.Log("El daño viene por la izquierda");
                rigidbody2D.AddForce(new Vector2(enemy.knockBackForceX, enemy.knockBackForceY), ForceMode2D.Force);
                Debug.Log(enemy.knockBackForceX+"fuerza");
            }
            else
            {
                Debug.Log("El daño viene por la derecha");
                rigidbody2D.AddForce(new Vector2(-enemy.knockBackForceX, enemy.knockBackForceY), ForceMode2D.Force);
                Debug.Log(enemy.knockBackForceX+"fuerza");
            }

            StartCoroutine(Damager());
            if (enemy.healthPoints <= 0)
            {
                Instantiate(deathEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
    IEnumerator Damager()
    {
        isDamaged = true;
       // anim.SetBool("Idle", true);
        sprite.material = material.blink;
        yield return new WaitForSeconds(0.5f);
        isDamaged = false;
        sprite.material = material.original;
    }
}
