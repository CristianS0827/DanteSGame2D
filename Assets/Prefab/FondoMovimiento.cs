using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FondoMovimiento : MonoBehaviour
{
    [SerializeField] private Vector2 VelocidadMovimiento;
    private Vector2 offset;
    private Material material;
    private void Awake() 
    {
        material= GetComponent<SpriteRenderer>().material;    
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        offset = VelocidadMovimiento*Time.deltaTime;
        material.mainTextureOffset+= offset;
    }
}
