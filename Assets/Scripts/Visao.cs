using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visao : MonoBehaviour
{
    public Soldado Sd;
    public float DistanciaVisao;
    void Start()
    {
        
    }

    
    void Update()
    {

        RaycastHit hit;

        Vector3 olharprafrente = transform.TransformDirection(
            Vector3.forward) * (40+ DistanciaVisao);
        if(Physics.Raycast(transform.position, olharprafrente, out hit, 40+DistanciaVisao))
        {
            if (hit.collider.gameObject.tag == "Inimigo")
            {
                Debug.Log("LEGAL Encontrei o Inimigo");
                Debug.DrawLine(transform.position, olharprafrente, Color.gray);
                //Informa Quem é o Inimigo e que achou ele
                Sd.Destino = hit.collider.gameObject;
                Sd.EncontreiInimigo = true;

            }
            else
            {
                Debug.Log("Errei parede");
                Debug.DrawLine(transform.position, olharprafrente, Color.black);
            }
        }
        else
        {
            Debug.Log("Errei não achei nada");
            Debug.DrawLine(transform.position, olharprafrente, Color.magenta);
        }


    }
}
