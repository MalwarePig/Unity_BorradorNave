using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSatelite : MonoBehaviour
{
    [SerializeField] private Transform Inicio;
    [SerializeField] private Transform Final;

    [SerializeField] public List<GameObject> props;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Final: " + other.name);
        float EjeX = Random.Range(0.0f, 6f);//Para tener diferentes alturas
        foreach (GameObject prop in props)
        {
            if (prop.name == other.name)
            {
                prop.transform.position = new Vector3(Inicio.position.x + EjeX, prop.transform.position.y, prop.transform.position.z); 
            }
        }
    }
}



