using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("barang dagangan")]
    public GameObject daganganslotholder;
    public inventory[] kumpulaninvent;
    GameObject[] paradagangan;
    [HideInInspector] public List<slotclass> semuabarang = new List<slotclass>();


    [Header("PEMBELI")]
    public Transform[] tempatpembeli;
    public Transform startpos;
    public int jumlahPelanggan = 0;
    public int currentcustomer = 0;
    public GameObject pembeli;
    public bool[] terisi = new bool[5];

    [Header("player pos")]
    public Transform[] slotplayerjalan;

    [Header("other")]
    int index;
    //int level = 1;
    // Start is called before the first frame update
    void Start()
    {
        paradagangan = new GameObject[daganganslotholder.transform.childCount];
        kumpulaninvent = new inventory[daganganslotholder.transform.childCount];

        for (int i = 0; i < paradagangan.Length; i++)
        {
            paradagangan[i] = daganganslotholder.transform.GetChild(i).gameObject;
        }
        for (int i = 0; i < kumpulaninvent.Length; i++)
        {
            kumpulaninvent[i] = daganganslotholder.transform.GetChild(i).GetComponent<inventory>();
            foreach (var item in daganganslotholder.transform.GetChild(i).GetComponent<inventory>().startingitem)
            {
                semuabarang.Add(item);
            }
        }
        InvokeRepeating("spawnpembeli",5, Random.Range(3, 5));
    }

    public void spawnpembeli()
    {
        for (int i = 0; i < terisi.Length; i++)
        {
            if(!terisi[i])
            {
                pembeli.GetComponent<pembeli>().target = tempatpembeli[i];
                pembeli.GetComponent<pembeli>().pembeliKe = i;
                Instantiate(pembeli, startpos.position, Quaternion.identity);
                terisi[i] = true;
                break;
            }
            
        }
    }
    public void openbox(int _index)
    {
        if(!FindObjectOfType<player>().firsttouch)
        {
            paradagangan[_index].transform.GetChild(1).gameObject.SetActive(true);
            index = _index;

        }
        else
        {
            paradagangan[index].transform.GetChild(1).gameObject.SetActive(false);
            index = _index;
            paradagangan[_index].transform.GetChild(1).gameObject.SetActive(true);

        }
    }

    public void closeall()
    {
        foreach (var item in paradagangan)
        {
            item.transform.GetChild(1).gameObject.SetActive(false);
        }
    }    
}
