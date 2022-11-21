using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossActivation : MonoBehaviour
{
    public GameObject bossGo;
    
    private void Start() 
    {
        bossGo.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D colision) {
        if(colision.CompareTag("Player"))
        { 
            BossUI.instance.ActivarBoss(); 
            AudioManager.instance.bckgMusica.Stop();
            AudioManager.instance.PlayAudio(AudioManager.instance.bkcgMBoss);
            StartCoroutine(EsperarJefe());
        }
        
    }

    IEnumerator EsperarJefe()
    {
        var VelocidadActual= DanteMovimiento.Instance.Velocidad;
        DanteMovimiento.Instance.Velocidad=0;
        bossGo.SetActive(true);
        yield return new WaitForSeconds(1f);
        DanteMovimiento.Instance.Velocidad=VelocidadActual;
        Destroy(gameObject);
    }
    // Start is called before the first frame update

}
