using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GeneradorEnemigos : MonoBehaviour
{
    provate float minX, maxX, minY, maxY;
    [SerializeField] private Transform[] puntos;
    [SerializeField] private GameObject[] enemigos;
    [SerializeField] private float tiempoEnemigos;

    // puntos es el objeto vacio donde haran respawn y en enemigos va el prefab de los enemigos
    void Start()
    {
        maxX = respawn.Max(punto => punto.position.x);
        minX = respawn.Min(punto => punto.position.x);
        maxY = respawn.Max(punto => punto.position.y);
        minY = respawn.Min(punto => punto.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        tiempoSiguienteEnemigo += Time.deltaTime;

        if (tiempoSiguienteEnemigo >= tiempoEnemigos)
        {
            tiempoSiguienteEnemigo = 0;
            CrearEnemigo();
        }    
    }

    private void CrearEnemigo()
    {
        int numeroEnemigo = Random.Range(0, enemigos.Length);
        Vector2 posicionAleatoria = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

        Instantiate(enemigos[numeroEnemigo], posicionAleatoria, Quaternion.identity);
    }
}
