using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recolectable : MonoBehaviour
{
    public int DagasADar;

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.CompareTag("Player"))
        {
            Arrojables.instance.Arrojable(DagasADar);
            AudioManager.instance.PlayAudio(AudioManager.instance.colec);
            Destroy(gameObject);
        }
        
    }
    // Start is called before the first frame update
}
