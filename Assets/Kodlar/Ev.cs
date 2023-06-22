using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ev : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject uykuButonu;

    public GameObject gece;

    public GridYoneticisi grid;

    public GameObject komsu;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        uykuButonu.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        uykuButonu.SetActive(false);

    }

    public void Uyu()
    {
        // tarlayi yeniden baslat
        grid.BahcedekiTumObjeleriSil();
        grid.TileMapiGuncelle();

        //gun isigini yak
        gece.SetActive(true);
        komsu.SetActive(false);
        gameManager.GunArttir();
    }

    public void GeceKapat()
    {
        gece.SetActive(false);
    }
}
