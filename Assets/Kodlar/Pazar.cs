using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pazar : MonoBehaviour
{

    private GameManager gameManager;

    public int odunFiyati = 3;
    public int tasFiyati = 2;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Karakter")
        {

        }
    }

    public void TasHarca()
    {
        int miktar = gameManager.TasHarca()*tasFiyati;
        gameManager.ParaArttir(miktar);
    }

    public void OdunHarca()
    {
        int miktar = gameManager.OdunHarca() * odunFiyati;
        gameManager.ParaArttir(miktar);
    }
}
