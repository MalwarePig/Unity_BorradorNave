using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    [SerializeField] private int velocidad = 4;

    public List<GameObject> props;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    { 
        foreach (GameObject prop in props)
        {
            prop.transform.Translate((-1 * Time.deltaTime * Vector3.right)*velocidad);
        }

    }
}
