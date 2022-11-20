using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonScript : MonoBehaviour
{
    float velocidadMov;
    Rigidbody2D rb;
    Vector2 direccionMov;
    DanteMovimiento target;

    void Start()
    {
        velocidadMov=GetComponent<Enemy>().velocidad;
        rb=GetComponent<Rigidbody2D>();
        target=DanteMovimiento.Instance;

        direccionMov=(target.transform.position-transform.position).normalized*velocidadMov;
        rb.velocity=new Vector2(direccionMov.x, direccionMov.y);  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
