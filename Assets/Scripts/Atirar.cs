using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atirar : MonoBehaviour
{
    public Soldado Sd;
    public float DistanciaTiro;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Atirando()
    {
        RaycastHit hit;

        Vector3 miraDaArma = transform.TransformDirection(
            Vector3.forward) * (20+DistanciaTiro);
        if (Physics.Raycast(transform.position, miraDaArma, out hit, 20+DistanciaTiro))
        {
            if (hit.collider.gameObject.tag == "Inimigo")
            {
                Debug.Log("Acertei O Inimigo");
                hit.collider.gameObject.GetComponent<Soldado>().vida--;
                Debug.DrawLine(transform.position, miraDaArma, Color.blue);
            }

        }

    }
}
