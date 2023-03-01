using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPrincipal : MonoBehaviour
{
    private int naveActual = 1;

    [SerializeField]
    Text record;
    private float tiempo = 0f;
    private float tiempoRecord = 0f;
    private float rotacionActual = 0f;

    private float[] Angulos = { 0.0f, 90.0f, 180.0f, 270.0f };

    [SerializeField]
    Transform cubeMenu;

    // Start is called before the first frame update
    void Start()
    {
        record.text = "00";
        //Formateo minutos y segundos a dos dígitos
        string minutos = Mathf.Floor(tiempoRecord / 60).ToString("00");
        string segundos = Mathf.Floor(tiempoRecord % 60).ToString("00");
        record.text = minutos + ":" + segundos;
    }

    // Update is called once per frame
    void Update()
    {
        Cronometro();
    }

    public void LoadLevel()
    {
        Debug.Log("Iniciar Nivel");
        SceneManager.LoadScene("PlanetaRojo");
    }

    public void RightPlayer()
    {
        if (naveActual < 4)
        {
            naveActual = naveActual + 1;
            Rotar("sumar");
            PlayerPrefs.SetInt("NaveActual", naveActual);
            Debug.Log("nave Actual " + naveActual);
        }
    }

    public void LeftPlayer()
    {
        if (naveActual > 1)
        {
            naveActual = naveActual - 1;
            Rotar("restar");
            PlayerPrefs.SetInt("NaveActual", naveActual);
            Debug.Log("nave Actual " + naveActual);
        }
    }

    private void Cronometro()
    {
        //lineaTiempo = (int)Time.time;
        tiempo += Time.deltaTime; //Le añade a la variable tiempo el tiempo de un frame

        //Formateo minutos y segundos a dos dígitos
        string minutos = Mathf.Floor(tiempo / 60).ToString("00");
        string segundos = Mathf.Floor(tiempo % 60).ToString("00");

        //Mlostrar el cronometro
        record.text = minutos + ":" + segundos;
    }

    public void Rotar(string parametro)
    {
        if (parametro == "sumar")
        {
            cubeMenu.transform.Rotate(0.0f, 90, 0.0f);
        }else{
            cubeMenu.transform.Rotate(0.0f, -90, 0.0f);
        } 
    }
}
