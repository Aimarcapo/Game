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
    Rigidbody2D rigidbody2D;
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        material = GetComponent<Blink>();
        enemy = GetComponent<Enemy>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon") & !isDamaged)
        {
            enemy.healthPoints -= 1f;
            if (collision.transform.position.x < transform.position.x)
            {
                rigidbody2D.AddForce(new Vector2(enemy.knockBackForceX, enemy.knockBackForceY), ForceMode2D.Force);
            }
            else
            {
                rigidbody2D.AddForce(new Vector2(-enemy.knockBackForceX, enemy.knockBackForceY), ForceMode2D.Force);
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
        sprite.material = material.blink;
        yield return new WaitForSeconds(0.5f);
        isDamaged = false;
        sprite.material = material.original;
    }
}
