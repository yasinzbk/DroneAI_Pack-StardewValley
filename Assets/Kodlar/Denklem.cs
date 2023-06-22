using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="Denklem")]
public class Denklem : ScriptableObject
{
    public int bilesenSayisi = 1;

    [field:SerializeReference] public List<Esya> gerekenEsyalar { get; private set;}
}
