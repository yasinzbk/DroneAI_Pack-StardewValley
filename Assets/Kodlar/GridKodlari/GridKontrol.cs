using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridKontrol : MonoBehaviour
{
    [SerializeField] Tilemap sablonTileMap;
    [SerializeField] GridYoneticisi gridYoneticisi;

    //public GirisKarakter giris;

    private bool kullan; // KALKabilir amele yontemi

    public Karakter karakter;

     public Animator anim;


    private void Start()
    {
        karakter.elindekiEsyaDegistigindeGeriCagir += SifirlaKullan;

    }

    private void Update()
    {
      ZeminEkle();
    }

    private void ZeminEkle()
    {
        //if (giris.saldiri && kullan)
        //{
        //    anim.SetBool("vur", true);

        //    giris.SaldiriGirisiniKullan();
        //    Vector3 worldPoint = giris.fareKonumu;
        //    Vector3Int tiklananPozisyon = sablonTileMap.WorldToCell(worldPoint); // world pozisyonu en yakin hucreye ayarliyor olmasi lazim(yani en yakin int degerlerine)
        //    gridYoneticisi.Ekle(tiklananPozisyon.x, tiklananPozisyon.y, 0);
        //}
    }

    public void Kullan()
    {
        kullan = !kullan;
    }

    void SifirlaKullan()
    {
        kullan = false;
    }
}
