using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pociones : MonoBehaviour
{
    public float VidaADar;
    
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.CompareTag("Player"))
        {
            collision.GetComponent<DanteHealth>().VidaPP+= VidaADar;
            AudioManager.instance.PlayAudio(AudioManager.instance.colec);
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
