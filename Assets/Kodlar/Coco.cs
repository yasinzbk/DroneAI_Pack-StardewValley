using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coco : MonoBehaviour
{
    public GameManager gameManager;

    public Transform bahce;

    private Transform hedef;
    public float hiz = 2f;

    List<Transform> childs = new List<Transform>();

    float baslangicZamani;
    Vector3 baslangicPozisyonu;

    bool hareketEdiyorMu;

    public float hasar = 5f;

    public float damageInterval = 1f; // Hasar aralýðý
    private float lastDamageTime = 0f; // Son hasar zamaný

    bool hasarVarMi = false;

    public Transform karakter;

    public List<Kaynak> kaynakListesi = new List<Kaynak>();
 
    private void Start()
    {
        KaraktereIlerle();
    }

    private void Update()
    {

        if (hareketEdiyorMu)
        {
            float distanceCovered = (Time.time - baslangicZamani) * hiz; // Kat edilen mesafe
            if (hedef == null)
            {
                hedef = HedefObjeBelirle();
            }

            float journeyFraction = distanceCovered / Vector3.Distance(baslangicPozisyonu, hedef.position); // Kat edilen mesafenin toplam yol ile oraný

            transform.position = Vector3.Lerp(baslangicPozisyonu, hedef.position, journeyFraction); // Hareket ettirme

            if (journeyFraction >= 1f)
            {
                hareketEdiyorMu = false;

                if (!gameManager.cocoToplayabilirMi)
                {
                    //if (Time.time - lastDamageTime >= damageInterval)
                    //{
                        KaraktereIlerle();



                    //    lastDamageTime = Time.time; // Son hasar zamanýný güncelle
                    //}
                }

                HedefeHasarVer(); // Hedefe vardi, altindakilere hasar verirr
            }
        }

        if (hedef == null && gameManager.cocoToplayabilirMi)
        {
            HedefeIlerle();
        }

        if (gameManager.cocoToplayabilirMi)
        {

            if (hasarVarMi)
            {
                if (Time.time - lastDamageTime >= damageInterval)
                {

                    for (int i = 0; i < kaynakListesi.Count; i++)
                    {

                        kaynakListesi[i].TakeDamage(hasar);


                    }

                    lastDamageTime = Time.time; // Son hasar zamanýný güncelle
                }
            }

            if (kaynakListesi.Count == 0)
            {
                hasarVarMi = false;
            }
        }


 


    }

    private Transform HedefObjeBelirle()
    {
        foreach (Transform child in bahce)
        {
            childs.Add(child);

        }

        if (childs.Count > 0)
        {
            Transform randomObject = childs[Random.Range(0, childs.Count)];

            return randomObject;
        }
        return null;
    }

    public void HedefeIlerle()
    {
        baslangicPozisyonu = transform.position;
        this.hedef = HedefObjeBelirle();
        baslangicZamani = Time.time;
        hareketEdiyorMu = true;
    }

    public void HedefeHasarVer()
    {
        hasarVarMi = true;


    }

    public void KaraktereIlerle()
    {
        baslangicPozisyonu = transform.position;
        this.hedef = karakter;
        baslangicZamani = Time.time;
        hareketEdiyorMu = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Kaynak kaynakObjesi = collision.GetComponent<Kaynak>();
        if (kaynakObjesi != null)
        {
            kaynakListesi.Add(kaynakObjesi); // Kaynak objesini listeye ekle
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Kaynak kaynakObjesi = collision.GetComponent<Kaynak>();
        if (kaynakObjesi != null)
        {
            kaynakListesi.Remove(kaynakObjesi); // Kaynak objesini listeden çýkar
        }
    }

}
