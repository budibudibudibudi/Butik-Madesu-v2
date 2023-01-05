using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class player : MonoBehaviour
{
    private NavMeshAgent agen;
    public Camera cam;
    [HideInInspector] public Transform target;
    [HideInInspector] public GameObject pembeli;
    public bool firsttouch = false;
    public int speed = 5;

    private void Start()
    {
        agen = GetComponent<NavMeshAgent>();

        agen.updateRotation = false;
        agen.updateUpAxis = false;

        agen.speed = speed;
        agen.acceleration = 100;
    }
    private void Update()
    {
        if (target != null)
        {
            agen.SetDestination(target.position);
            if (Vector2.Distance(this.transform.position, target.position) <= 1)
            {
                if(target.parent.gameObject.tag == "bajubaju")
                {
                    FindObjectOfType<GameManager>().openbox(target.parent.GetComponent<dagangan>().index);
                    target.parent.GetComponent<inventory>().refreshui();
                    target = null;
                    firsttouch = true;
                }
                else if(target.gameObject.tag == "pembeli")
                {
                    Debug.Log(target.gameObject.name);
                }
            }
        }
        else
            return;
    }

}
