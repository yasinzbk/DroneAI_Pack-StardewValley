
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Yeni Esya", menuName = "Esya")]
public class Esya : ScriptableObject
{
    public int esyaSayisi = 0;

    public EsyaNiteligi nitelik;

    public enum EsyaNiteligi
    {
        tas,
        odun,
        para
    }
}
