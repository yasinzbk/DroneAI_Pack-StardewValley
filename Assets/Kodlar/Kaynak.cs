using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kaynak : MonoBehaviour
{
    public float startingHealth = 100; 
    public float currentHealth; 
    public bool isDead = false; 

    public GameObject cerceve;

    public GameObject tasCevher;
    public float dagilma;
    private int carpan;

    public Veri cocoVeri;

    void Start()
    {
        currentHealth = startingHealth;

        dagilma = Random.Range(dagilma, dagilma * 2);
        carpan = (Random.value < 0.5f) ? -1 : 1;
    }

    // Hasar almak için ça?r?lacak fonksiyon
    public void TakeDamage(float damageAmount)
    {
        // E?er öldüyse, fonksiyondan ç?k
        if (isDead)
        {
            return;
        }

        // Hasar alinir, saglik azalir
        currentHealth -= damageAmount;

        // Objenin Oldugunu gosterir
        if (currentHealth <= 0)
        {
            isDead = true;
            // Ölümle ilgili ek i?lemler yapabilirsiniz
            // Örne?in, ölüm animasyonunu oynatmak
            // veya nesneyi yok etmek
            GameObject kaynak = Instantiate(tasCevher);
            kaynak.transform.position = new Vector2(transform.position.x + dagilma*carpan, transform.position.y + dagilma);

            carpan = (Random.value < 0.5f) ? -1 : 1; // carpani yeniler

            GameObject kaynak2 = Instantiate(tasCevher);
            kaynak2.transform.position = new Vector2(transform.position.x + dagilma*carpan, transform.position.y - dagilma);


            cocoVeri.veriSayisi++;  // Coco nun ogrenmesini arttirir

            Destroy(gameObject);
        }
    }


    private void OnMouseExit()
    {
        CerceveKapa();

    }

    public void CerceveAc()
    {
        cerceve.SetActive(true);
    }
    public void CerceveKapa()
    {
        cerceve.SetActive(false);
    }

}
