using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Toplanabilir : MonoBehaviour
{
    public Esya esya;

    private GameManager gameManager;

    public float shiftAmount = 2f;

    private int birikenEsya = 1;

    public Transform parent;

    public Vector3 targetUI; // esyayi gosteren UI
    public float moveSpeed = 0.1f;

    public bool toplandiMi = false;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        targetUI = gameManager.ToplanabilireHedefBelirle(esya);
        //targetUI = FindObjectOfType<Karakter>().transform;
    }

    private void Update()
    {
        if (toplandiMi)
        {
            MoveToTargetUI();
        }
    }

    public void EsyayiAl()
    {
        //Debug.Log(esya.nitelik + " alindi");
        //Destroy(transform.parent.gameObject);
        if (!toplandiMi)
        {
            toplandiMi = true;

        }
    }

    public void EsyaArttir()
    {
        esya.esyaSayisi += birikenEsya;
    }

    private void MoveToTargetUI()
    {

        parent.position = Vector3.MoveTowards(parent.position, targetUI, moveSpeed * Time.deltaTime);
        targetUI = gameManager.ToplanabilireHedefBelirle(esya);

        if (Vector3.Distance(parent.position, targetUI) <= 0.9f)
        {

            SesYoneticisi.orn.Oynat("toplama"); 

            EsyaArttir();

            gameManager.EsyaArttir(esya);

            Destroy(parent.gameObject);
        }



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Karakter")
        {
           
            EsyayiAl();

        }

        if (collision.tag == "toplanabilir")
        {
            Debug.Log("heyuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu");
            GameObject otherObject = collision.gameObject;

            // Çakýþan objeleri kaydýr
            Vector3 shiftVector = new Vector3(shiftAmount, 0, 0);
            transform.parent.position += shiftVector;
            otherObject.transform.parent.position -= shiftVector;
        }

    }
}
