using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GamePlay : MonoBehaviour
{

    [SerializeField] public Image BarraVida;

    [SerializeField] float vidaActual = 100f;
    [SerializeField] float vidaMax = 100f;
    [SerializeField] float vidaMin = 0f;
    [SerializeField] public ParticleSystem ParticulasChoque;

    [SerializeField] public ParticleSystem ParticulasMotor;
    [SerializeField] public ParticleSystem Particulas_Destruccion;
    [SerializeField] private AudioClip audio_Choque;
    [SerializeField] private AudioClip audio_Destruccion;
    private bool NaveDestruida = false;

    private GameObject[] Hijos;
    AudioSource audioSource;

    private void Awake()
    {
        ParticulasChoque.Stop();
        Particulas_Destruccion.Stop();
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other)
    {
        vidaActual = vidaActual - 25f;
        // Debug.Log("Nombre: " + other);
        if (vidaActual > 0)
        {
            ParticulasChoque.Play();
        }

        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(audio_Choque, 1F);
            EstatusVida();
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        vidaActual = vidaActual - 25f;
        //Debug.Log("Nombre: " + other);
        if (vidaActual > 0)
        {
            ParticulasChoque.Play();
        }
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(audio_Choque, 1F);
            EstatusVida();
        }
    }

    void Update()
    {

    }

    void EstatusVida()
    {
        //BarraVida.fillAmount = vidaActual / vidaMax;
        // Debug.Log("Vida: " + vidaActual / vidaMax);
        if (vidaActual <= 0 && NaveDestruida == false)
        {
            NaveDestruida = true;
            audioSource.PlayOneShot(audio_Destruccion, .5F);
            Particulas_Destruccion.Play();//Explosion

            this.GetComponent<MeshRenderer>().enabled = false;//Desaparece la nave
            ParticulasChoque.Stop();//Detiene particulas de choque  
            ParticulasMotor.Stop();//Detiene particulas de motor 

            GameObject originalGameObject = GameObject.Find("Punta");
            originalGameObject.GetComponent<MeshRenderer>().enabled = false;//Oculta la punta de nave

            GameObject Controlador = GameObject.Find("Controlador");
            Controlador.GetComponent<ControladorNave>().enabled = false;

            //audioSource.mute = true;

            Destroy(gameObject, 2f);

            

            //  SceneManager.LoadScene("SampleScene");
        }
    }
 
}
