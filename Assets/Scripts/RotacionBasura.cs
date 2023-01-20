using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionBasura : MonoBehaviour
{

    [SerializeField]
    private float velocidadRotacion = 0;
    [SerializeField]
    private Transform Planeta; 

    [SerializeField] public List<GameObject> props;

 

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject prop in props)
        {
            prop.transform.RotateAround(Planeta.transform.position, Vector3.forward, Time.deltaTime * velocidadRotacion); 
        } 
    }

     
 


}
