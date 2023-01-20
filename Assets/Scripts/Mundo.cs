using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mundo : MonoBehaviour
{
    [SerializeField]
    private float velocidadRotacion = 0;
    [SerializeField]
    private GameObject Planeta;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Planeta.transform.Rotate(new Vector3(0,-velocidadRotacion,0));
    }
}
