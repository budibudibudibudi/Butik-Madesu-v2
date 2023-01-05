using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "itembackpack", menuName = "item")]
public class itemclass : ScriptableObject
{
    public string nama;
    public bool isstackable;
    public int harga_restock;
    public int harga_jual;
    public Sprite item;
    public jenis type;
    public enum jenis { Topi,Baju,Sabuk,Celana,Sepatu }
}
