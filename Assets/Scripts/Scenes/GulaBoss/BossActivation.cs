using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossActivation : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D colision) {
        if(colision.CompareTag("Player"))
        {
            BossUI.instance.ActivarBoss();
            StartCoroutine(EsperarJefe());
            
        }
        
    }

    IEnumerator EsperarJefe()
    {
        var VelocidadActual= DanteMovimiento.Instance.Velocidad;
        DanteMovimiento.Instance.Velocidad=0;
        yield return new WaitForSeconds(3f);
        DanteMovimiento.Instance.Velocidad=VelocidadActual;
        Destroy(gameObject);
    }
    // Start is called before the first frame update

}
