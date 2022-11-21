using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuerteInsta : MonoBehaviour
{
     private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player"))
        {
            DanteHealth.instancia.VidaPP=0;
            AudioManager.instance.PlayAudio(AudioManager.instance.muertePP);
            DanteHealth.instancia.estaMuerto=true;
        }
    // Start is called before the first frame update
     }
}
