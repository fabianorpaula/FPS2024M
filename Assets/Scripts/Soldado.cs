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

    public enum Estados { Ronda, Perseguir, Atacar};
    public Estados MeuEstado;

    // Start is called before the first frame update
    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        Sorte();
        Destino = ListaLocais[indice];
    }

   
    void Update()
    {
       
        if(MeuEstado == Estados.Ronda)
        {
            Patrulha();
        }
       if(MeuEstado == Estados.Perseguir)
        {
            Perseguicao();
        }

    }

    void Patrulha()
    {
        if (EncontreiInimigo == false)
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
        else
        {
            MeuEstado = Estados.Perseguir;
        }
    }

    void Perseguicao()
    {
        if (EncontreiInimigo == true)
        {
            agente.SetDestination(Destino.transform.position);
        }
        else
        {
            MeuEstado = Estados.Ronda;
        }
    }

    void Ataque()
    {

    }


    void Sorte()
    {
        indice = Random.Range(0, ListaLocais.Count);
    }
}
