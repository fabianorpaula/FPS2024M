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
    public Atirar MinhaArma;
    public int vida = 10;

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
       if(MeuEstado == Estados.Atacar)
        {
            Ataque();
        }

       if(vida < 0)
        {
            Destroy(this.gameObject);
        }

    }

    void Patrulha()
    {
        agente.speed = 7;
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
        //Inimigo Ta vivo ?
        if (Destino != null)
        {
            agente.speed = 7;
            if (EncontreiInimigo == true)
            {
                agente.SetDestination(Destino.transform.position);
                float distancia = Vector3.Distance(transform.position,
                    Destino.transform.position);
                if (distancia < 20)
                {
                    MeuEstado = Estados.Atacar;
                }
            }
            else
            {
                MeuEstado = Estados.Ronda;
            }
        }
        else
        {
            Sorte();
            Destino = ListaLocais[indice];
            MeuEstado = Estados.Ronda;
        }
    }

    void Ataque()
    {
        //Inimigo Ta vivo ?
        if(Destino != null)
        {
            agente.SetDestination(Destino.transform.position);
            MinhaArma.Atirando();
            float distancia = Vector3.Distance(transform.position,
                    Destino.transform.position);
            if (distancia < 5)
            {
                agente.speed = 0;
            }
            else
            {
                agente.speed = 7;
            }
        }
        else
        {
            Sorte();
            Destino = ListaLocais[indice];
            MeuEstado = Estados.Ronda;
        }
        
    }


    void Sorte()
    {
        indice = Random.Range(0, ListaLocais.Count);
    }
}
