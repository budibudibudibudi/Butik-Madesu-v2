using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class pembeli : MonoBehaviour
{
    //script
    public slotclass[] order;
    GameManager gm;
    NavMeshAgent agen;

    //component
    public GameObject ui;

    //tipe data
    [SerializeField] float kesabaran;
    public bool terpenuhi = false;
    public int pembeliKe = 0;
    public Transform target;
    public int speed = 5;
    void Start()
    {
        order = new slotclass[3];
        gm = FindObjectOfType<GameManager>();
        agen = GetComponent<NavMeshAgent>();
        agen.updateRotation = false;
        agen.updateUpAxis = false;

        agen.speed = speed;
        agen.acceleration = 100;

        for (int i = 0; i < order.Length; i++)
        {
            order[i] = new slotclass();
            order[i] = gm.semuabarang[Random.Range(0, gm.semuabarang.Count)];
        }
        if (target != null)
            agen.SetDestination(target.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (kesabaran <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            if (Vector2.Distance(this.transform.position, this.target.position) < 0.5f)
            {
                if (!terpenuhi)
                {
                    kesabaran -= Time.deltaTime;
                    ui.SetActive(true);
                    refreshui();
                }
                else
                {
                    ui.SetActive(false);
                }
            }
        }
    }

    void refreshui()
    {
        for (int i = 0; i < order.Length; i++)
        {
            try
            {
                ui.transform.GetChild(i).GetComponent<Image>().enabled = true;
                ui.transform.GetChild(i).GetComponent<Image>().sprite = order[i].getitem().item;

            }
            catch
            {
                ui.transform.GetChild(i).GetComponent<Image>().sprite = null;
                ui.transform.GetChild(i).GetComponent<Image>().enabled = false;
            }
        }
    }
    private void OnMouseDown()
    {
        if (FindObjectOfType<handholdingstack>().hand[2].getitem() != null)
        {
            FindObjectOfType<player>().target = FindObjectOfType<GameManager>().slotplayerjalan[pembeliKe];
        }
    }

    IEnumerator leave()
    {
        for (int i = 0; i < 3; i++)
        {
            if(order[i] == FindObjectOfType<handholdingstack>().hand[i])
            {
                gm.terisi[pembeliKe] = false;
                yield return new WaitForSeconds(5);
                Destroy(gameObject);

            }
        }
    }
}
