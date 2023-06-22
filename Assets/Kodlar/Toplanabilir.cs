using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Toplanabilir : MonoBehaviour
{
    public Esya esya;

    private GameManager gameManager;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }


    public void EsyayiAl()
    {
        Debug.Log(esya.nitelik + " alindi");
        Destroy(gameObject);

        EsyaArttir();

        gameManager.EsyaArttir(esya);
    }

    public void EsyaArttir()
    {
        esya.esyaSayisi++;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Karakter")
        {

            EsyayiAl();

        }

    }
}
