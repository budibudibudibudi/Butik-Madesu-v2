using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class cube : MonoBehaviour
{
    NavMeshAgent agen;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        agen = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            agen.SetDestination(target.position);
        }
    }
}
