using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] public Transform start;

    [SerializeField] public Transform end;

    [SerializeField] public List<GameObject> props;
    private float altura = -1f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Spawn();
    }

    void Spawn()
    {
        altura = Random.Range(-1,3);

        foreach (GameObject prop in props)
        {
            if (prop.transform.position.x <= end.position.x)
            {
                prop.transform.position = new Vector3(start.position.x, altura, prop.transform.position.z);
            }
        }
    }
}
