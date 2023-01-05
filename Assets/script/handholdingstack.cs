using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class handholdingstack : MonoBehaviour
{
    public slotclass[] hand = new slotclass[3];
    public GameObject uiplayer;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < hand.Length; i++)
        {
            hand[i] = new slotclass();
        }
    }

    public void remove()
    {
        foreach (var item in hand)
        {
            item.clear();
        }
        refreshui();
        uiplayer.SetActive(false);
    }

    void refreshui()
    {
        for (int i = 0; i < uiplayer.transform.childCount; i++)
        {
            try
            {
                uiplayer.transform.GetChild(i).GetComponent<Image>().enabled = true;
                uiplayer.transform.GetChild(i).GetComponent<Image>().sprite = hand[i].getitem().item;
            }
            catch
            {
                uiplayer.transform.GetChild(i).GetComponent<Image>().sprite = null;
                uiplayer.transform.GetChild(i).GetComponent<Image>().enabled = false;
            }
        }
    }

    public bool add(itemclass _item)
    {
        slotclass slot = contains(_item);
        if (slot != null)
            for (int i = 0; i < hand.Length; i++)
            {
                if (hand[i].getitem() == null)
                {
                    hand[i].additem(_item, 1);
                    break;
                }
            }
        else
        {
            for (int i = 0; i < hand.Length; i++)
            {
                if (hand[i].getitem() == null)
                {
                    hand[i].additem(_item,1);
                    break;
                }
            }
        }
        uiplayer.SetActive(true);
        refreshui();
        return true;
    }
    public slotclass contains(itemclass _item)
    {
        for (int i = 0; i < hand.Length; i++)
        {
            if (hand[i].getitem() == _item)
                return hand[i];
        }
        return null;
    }
}
