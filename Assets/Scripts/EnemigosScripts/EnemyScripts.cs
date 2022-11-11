using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScripts : MonoBehaviour
{
     Enemy enemy;
    private void Start()
    {
        enemy=GetComponent<Enemy>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Arma"))
        {
            enemy.vida -=2f;
            if(enemy.vida<=0)
            {
                Destroy(gameObject);
            }
        }
    }
}
