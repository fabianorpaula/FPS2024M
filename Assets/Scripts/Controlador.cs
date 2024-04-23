using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlador : MonoBehaviour
{
    public List<GameObject> MeusSoldados;
    public List<GameObject> LocaisDeNascimento;
    void Start()
    {
        for(int i=0; i<MeusSoldados.Count; i++)
        {
            int valorRandomico = Random.Range(0, LocaisDeNascimento.Count);

            MeusSoldados[i].transform.position =
                LocaisDeNascimento[valorRandomico].transform.position;
            LocaisDeNascimento.Remove(LocaisDeNascimento[valorRandomico]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
