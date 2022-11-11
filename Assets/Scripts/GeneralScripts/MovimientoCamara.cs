using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCamara : MonoBehaviour
{
    public GameObject Player;

    // Update is called once per frame
    void Update()
    {
        Vector3 posicion = transform.position;
        posicion.x = Player.transform.position.x;
        posicion.y = Player.transform.position.y;
        transform.position = posicion;
    }
}
