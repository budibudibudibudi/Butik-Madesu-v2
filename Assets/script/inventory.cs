using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventory : MonoBehaviour
{
    [Header("Item Dagangan")]
    [SerializeField] slotclass[] item;
    public slotclass[] startingitem;
    [SerializeField] int index;
    private void Start()
    {
        item = new slotclass[startingitem.Length];

        for (int i = 0; i < item.Length; i++)
        {
            item[i] = new slotclass();
        }
        for (int i = 0; i < startingitem.Length; i++)
        {
            item[i] = startingitem[i];
        }

    }

    public void next()
    {
        index++;
        if (index == item.Length)
            index = 0;
        try
        {
            this.transform.Find("pilih baju/placeholder").GetComponent<Image>().enabled = true;
            this.transform.Find("pilih baju/placeholder").GetComponent<Image>().color = new Color(255, 255, 255, 255);
            this.transform.Find("pilih baju/placeholder").GetComponent<Image>().sprite = item[index].getitem().item;
            this.transform.Find("pilih baju/stock").GetComponent<Text>().text = item[0].getstock().ToString();
        }
        catch
        {
            this.transform.Find("pilih baju/placeholder").GetComponent<Image>().sprite = null;
            this.transform.Find("pilih baju/placeholder").GetComponent<Image>().color = new Color(0, 0, 0, 0);
            this.transform.Find("pilih baju/placeholder").GetComponent<Image>().enabled = false;
            this.transform.Find("pilih baju/stock").GetComponent<Text>().text = "";
        }
    }
    public void previous()
    {
        index--;
        if (index == -1)
            index = item.Length-1;
        try
        {
            this.transform.Find("pilih baju/placeholder").GetComponent<Image>().enabled = true;
            this.transform.Find("pilih baju/placeholder").GetComponent<Image>().color = new Color(255, 255, 255, 255);
            this.transform.Find("pilih baju/placeholder").GetComponent<Image>().sprite = item[index].getitem().item;
            this.transform.Find("pilih baju/stock").GetComponent<Text>().text = item[0].getstock().ToString();
        }
        catch
        {
            this.transform.Find("pilih baju/placeholder").GetComponent<Image>().sprite = null;
            this.transform.Find("pilih baju/placeholder").GetComponent<Image>().color = new Color(0, 0, 0, 0);
            this.transform.Find("pilih baju/placeholder").GetComponent<Image>().enabled = false;
            this.transform.Find("pilih baju/stock").GetComponent<Text>().text = "";
        }
    }
    public void refreshui()
    {
        try
        {
            this.transform.Find("pilih baju/placeholder").GetComponent<Image>().enabled = true;
            this.transform.Find("pilih baju/placeholder").GetComponent<Image>().color = new Color(255, 255, 255, 255);
            this.transform.Find("pilih baju/placeholder").GetComponent<Image>().sprite = item[0].getitem().item;
            this.transform.Find("pilih baju/stock").GetComponent<Text>().text = item[0].getstock().ToString();
        }
        catch
        {
            this.transform.Find("pilih baju/placeholder").GetComponent<Image>().sprite = null;
            this.transform.Find("pilih baju/placeholder").GetComponent<Image>().color = new Color(0, 0, 0, 0);
            this.transform.Find("pilih baju/placeholder").GetComponent<Image>().enabled = false;
            this.transform.Find("pilih baju/stock").GetComponent<Text>().text = "";
        }
        
    }

    public bool remove(itemclass _item, int quantity)
    {
        slotclass slot = contains(_item);
        if (slot != null)
            if (slot.getstock()>1)
            {
                slot.substock(quantity);
            }
            else
            {
                int slotremove = 0;
                for (int i = 0; i < item.Length; i++)
                {
                    if(item[i].getitem() == _item)
                    {
                        slotremove = i;
                        break;
                    }
                }
                item[slotremove].clear();
            }
        else
        {
            return false;
        }
        return true;
    }

    public bool add(itemclass _item, int quantity)
    {
        slotclass slot = contains(_item);
        if (slot != null)
            if (slot.getitem().isstackable)
            {
                slot.addstock(quantity);
            }
            else
            {
                for (int i = 0; i < item.Length; i++)
                {
                    if(item[i].getitem() == null)
                    {
                        item[i].additem(_item, quantity);
                        break;
                    }
                }
            }
        else
        {
            for (int i = 0; i < item.Length; i++)
            {
                if (item[i].getitem() == null)
                {
                    item[i].additem(_item, quantity);
                    break;
                }
            }
        }
        return true;
    }

    public void confirm()
    {
        FindObjectOfType<handholdingstack>().add(item[index].getitem());
        remove(item[index].getitem(), 1);
        close();
    }

    public void close()
    {
        this.transform.GetChild(1).gameObject.SetActive(false);
        index = 0;
    }
    public slotclass contains(itemclass _item)
    {
        for (int i = 0; i < item.Length; i++)
        {
            if (item[i].getitem() == _item)
                return item[i];
        }
        return null;
    }
}
