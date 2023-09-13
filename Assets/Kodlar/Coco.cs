using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coco : MonoBehaviour
{

    public GameManager gameManager;

    public Transform bahce;

    private Transform hedef;
    public float hiz = 2f;

    private float hizTutucu=3f;

    List<Transform> childs = new List<Transform>();

    float baslangicZamani;
    Vector3 baslangicPozisyonu;

    bool hareketEdiyorMu;

    public float hasar = 5f;

    public float damageInterval = 1f; // Hasar aralýðý
    private float lastDamageTime = 0f; // Son hasar zamaný

    bool hasarVarMi = false;

    public Transform karakter;

    public GameObject toplamaEfekt;

    public GameObject lvlUpUI;

    public float toplamaMesafesi = 0f;

    public List<Kaynak> kaynakListesi = new List<Kaynak>();
 
    private void Start()
    {
        //KaraktereIlerle();
        HedefeIlerle(karakter);

    }

    private void Update()
    {

        if (hareketEdiyorMu)
        {
            if (hedef == null)
            {
                //hedef = HedefObjeBelirle();
                Debug.Log("hedef null");
                HedefeIlerle(HedefObjeBelirle());
            }
            else
            {


                Vector3 hedefKonum = new Vector3(hedef.position.x, hedef.position.y + toplamaMesafesi, hedef.position.z); // missing transform hatasi

                float distanceCovered = (Time.time - baslangicZamani) * hiz; // Kat edilen mesafe

                float journeyFraction = distanceCovered / Vector3.Distance(baslangicPozisyonu, hedefKonum); // Kat edilen mesafenin toplam yol ile oraný

                transform.position = Vector3.Lerp(baslangicPozisyonu, hedefKonum, journeyFraction); // Hareket ettirme

                if (journeyFraction >= 1f)
                {
                    hareketEdiyorMu = false;

                    if (!gameManager.cocoToplayabilirMi || (kaynakListesi.Count==0 && childs.Count==0))
                    {

                        HedefeIlerle(karakter);


                        //if (Time.time - lastDamageTime >= damageInterval)
                        //{
                            //KaraktereIlerle();



                        //    lastDamageTime = Time.time; // Son hasar zamanýný güncelle
                        //}
                    }

                }
            }
        }


        else if (gameManager.cocoToplayabilirMi)
        {

            //if (hedef == null)
            //{
            //    HedefeIlerle(HedefObjeBelirle());
            //}


            if (hasarVarMi)
            {
                toplamaEfekt.GetComponent<SpriteRenderer>().enabled = true;
                SesYoneticisi.orn.Oynat("coco");

                if (Time.time - lastDamageTime >= damageInterval)
                {

                    for (int i = 0; i < kaynakListesi.Count; i++) // neden tek seferede buyun kaynaklara hasar vermiyor ?
                    {

                        kaynakListesi[i].TakeDamage(hasar);
                        Debug.Log(i);

                    }

                    lastDamageTime = Time.time; // Son hasar zamanýný güncelle
                }

                if (kaynakListesi.Count == 0)
                {
                    hasarVarMi = false;
                    toplamaEfekt.GetComponent<SpriteRenderer>().enabled = false;
                    SesYoneticisi.orn.Durdur("coco");


                    HedefeIlerle(HedefObjeBelirle());

                }

            }

        }


 


    }

    public Transform HedefObjeBelirle()
    {
        childs.Clear();

        foreach (Transform child in bahce)
        {
            if(child !=null)
                childs.Add(child);

        }

        if (childs.Count > 0)
        {
            Transform randomObject = childs[Random.Range(0, childs.Count)];

            return randomObject;
        }

        toplamaMesafesi = 0; // coco toplama mesafesi kadar yukari kalkmasin diye
        hizTutucu = hiz;
        hiz = 3f;
        //KaraktereIlerle();
        return karakter;
    }

    public void HedefeIlerle(Transform hedef)
    {
        baslangicPozisyonu = transform.position;
        this.hedef = hedef;
        baslangicZamani = Time.time;
        hareketEdiyorMu = true;
    }

    public void ToplamaHiziniAyarla()
    {
        hiz = hizTutucu;
    }

    public void ToplamaAlaniArttir(float miktar)
    {
        toplamaEfekt.transform.localScale = new Vector3(toplamaEfekt.transform.localScale.x + miktar, toplamaEfekt.transform.localScale.y, toplamaEfekt.transform.localScale.z);
    }

    //public void HedefeHasarVer()
    //{
    //    hasarVarMi = true;

    //    Debug.Log("hassar");
    //}

    //public void KaraktereIlerle()
    //{
    //    hizTutucu = hiz;
    //    hiz = 3f;
    //    baslangicPozisyonu = transform.position;
    //    this.hedef = karakter;
    //    baslangicZamani = Time.time;
    //    hareketEdiyorMu = true;
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Kaynak kaynakObjesi = collision.GetComponent<Kaynak>();
        if (kaynakObjesi != null)
        {
            hasarVarMi = true;

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


    public void LevelUpUI()
    {
        lvlUpUI.SetActive(true);

        Invoke("DestroyLvlUp", 2f);
    }

    private void DestroyLvlUp()
    {
        lvlUpUI.SetActive(false);
    }
}
