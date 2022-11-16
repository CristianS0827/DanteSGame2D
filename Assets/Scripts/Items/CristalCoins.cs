using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CristalCoins : MonoBehaviour
{
    public float dineroADar;

    private void OnTriggerEnter2D(Collider2D collision) 
    {

        if(collision.CompareTag("Player"))
        {
            CuentaBanco.instance.Dinero(dineroADar);
            Destroy(gameObject);
        }
    }
        
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
