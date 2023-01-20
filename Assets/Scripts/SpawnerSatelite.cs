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
        foreach (GameObject prop in props)
        {
            if (prop.name == other.name)
            {
                prop.transform.position = new Vector3(Inicio.position.x, prop.transform.position.y, prop.transform.position.z); 
            }
        }
    }
}
