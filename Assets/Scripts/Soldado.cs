using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Soldado : MonoBehaviour
{
    private NavMeshAgent agente;
    public List<GameObject> ListaLocais;
    public int indice;
    public GameObject Destino;
    public bool EncontreiInimigo = false;

    // Start is called before the first frame update
    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        Sorte();
        Destino = ListaLocais[indice];
    }

   
    void Update()
    {
        if(EncontreiInimigo == false)
        {
            agente.SetDestination(Destino.transform.position);
            float Distancia = Vector3.Distance(transform.position,
                Destino.transform.position);
            if (Distancia < 5)
            {
                Sorte();
                Destino = ListaLocais[indice];
            }
        }
        if(EncontreiInimigo == true)
        {
            agente.SetDestination(Destino.transform.position);
        }
       

    }

    void Sorte()
    {
        indice = Random.Range(0, ListaLocais.Count);
    }
}
