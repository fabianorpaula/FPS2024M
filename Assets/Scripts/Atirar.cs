using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atirar : MonoBehaviour
{
    public Soldado Sd;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Atirando()
    {
        RaycastHit hit;

        Vector3 miraDaArma = transform.TransformDirection(
            Vector3.forward) * 20;
        if (Physics.Raycast(transform.position, miraDaArma, out hit, 20))
        {
            if (hit.collider.gameObject.tag == "Inimigo")
            {
                Debug.Log("Acertei O Inimigo");
                Debug.DrawLine(transform.position, miraDaArma, Color.blue);
            }

        }

    }
}
