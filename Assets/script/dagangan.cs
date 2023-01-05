using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dagangan : MonoBehaviour
{
    public int index;
    private void OnMouseDown()
    {
        FindObjectOfType<player>().target = this.transform.GetChild(0).transform;
        FindObjectOfType<GameManager>().closeall();
        //FindObjectOfType<player>().agen.SetDestination(this.transform.GetChild(0).transform.position);
        //this.transform.GetChild(1).gameObject.SetActive(true);
    }

}
