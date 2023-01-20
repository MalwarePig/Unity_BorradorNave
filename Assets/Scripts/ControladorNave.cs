using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorNave : MonoBehaviour
{

    [SerializeField]
    private GameObject Nave;

    [SerializeField]
    private float impulso = 0.05f;
    private float velocidadActual = 0.1f;
    [SerializeField]
    private float velocidadMaxima = 0.15f;

    [SerializeField]

    private GameObject techo;//LimiteSuperior


    private Quaternion originalRotation;

    private Vector3 posicionCorrecta;


    void Awake()
    {
        originalRotation = Nave.transform.rotation;//Mantiene la rotacion original
        posicionCorrecta = Nave.transform.position;//Mantiene la posicion original
    }


    // Update is called once per frame
    void Update()
    {
        float inputSpaces = 0;
        inputSpaces = Input.GetAxis("Jump"); 
        if (inputSpaces == 1 || Input.touchCount>0)
        { 
            velocidadActual += impulso;
            if (velocidadActual > velocidadMaxima)
            {
                velocidadActual = velocidadMaxima;
            }
            AddForce();
        }
         Estabilidad();
    }

    private void AddForce()
    { 
        Nave.GetComponent<Rigidbody>().AddForce(transform.up * velocidadActual, ForceMode.Impulse);
    }

    void Estabilidad()
    {
        if (Nave.transform.position.y >= techo.transform.position.y)
        {
            Nave.transform.position = new Vector3(posicionCorrecta.x, techo.transform.position.y, 0);
        }
        else
        {
           Nave.transform.position = new Vector3(posicionCorrecta.x, Nave.transform.position.y, 0);//Mantener posicion horizontal
        }

         Nave.transform.rotation = originalRotation;//mantener rotación  original
    }

    
}
