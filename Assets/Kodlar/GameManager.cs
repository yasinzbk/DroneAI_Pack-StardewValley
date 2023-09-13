using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Veri gun;

    public Esya para;

    public Esya odunEsya;
    public Esya tasEsya;
    public Esya uParaEsya;
    public Esya gParaEsya;

    public TextMeshProUGUI tasTxt;
    public TextMeshProUGUI odunTxt;
    public TextMeshProUGUI paraTxt;
    public TextMeshProUGUI uzunlukParaTxt;
    public TextMeshProUGUI genislikParaTxt;

    public Image tasImage;
    public Image odunImage;
    public Image paraImage;

    public AraSahneYoneticisi araSahneYoneticisi;

    public Coco coco;

    public bool cocoToplayabilirMi = false;

    public Image cocoBar;

    public Veri cocoVeri;

    public Veri cocoIstenenVeri;

    private bool cocoAktifMi;
    public bool cocoAktifMi2;

    public float toplamaAlaniArtisi;
    public SpriteRenderer karakter;
    public Sprite pembe;

    public Camera mainCamera;

    private void Start()
    {
        odunTxt.text = odunEsya.esyaSayisi.ToString();
        tasTxt.text = tasEsya.esyaSayisi.ToString();
        paraTxt.text = para.esyaSayisi.ToString();
        uzunlukParaTxt.text = uParaEsya.esyaSayisi.ToString();
        genislikParaTxt.text = gParaEsya.esyaSayisi.ToString();

        GunKontrol();
        //coco.HedefeIlerle();
    }

    private void Update()
    {
        cocoBar.fillAmount = (float)cocoVeri.veriSayisi / cocoIstenenVeri.veriSayisi; // Dolum oranýný hesapla

        if (cocoVeri.veriSayisi >= cocoIstenenVeri.veriSayisi && cocoAktifMi2)
        {
            if (!cocoAktifMi)
            {
                cocoToplayabilirMi = true;
                coco.toplamaMesafesi = 3f;
                coco.HedefeIlerle(coco.HedefObjeBelirle());
                cocoVeri.veriSayisi = 0;
                cocoIstenenVeri.veriSayisi = 10; // simdilik gecici onlem
                cocoAktifMi = true;

                coco.LevelUpUI();
                SesYoneticisi.orn.Oynat("level");
            }
            else
            {
                cocoVeri.veriSayisi = 0;
                cocoIstenenVeri.veriSayisi = 10;
                coco.hiz += 2;
                coco.hasar += 2;
                coco.ToplamaAlaniArttir(toplamaAlaniArtisi);

                coco.LevelUpUI();
                SesYoneticisi.orn.Oynat("level");
            }

        }
    }

    public void EsyaArttir(Esya esya)
    {
        if (esya.nitelik == Esya.EsyaNiteligi.odun)
        {
            odunTxt.text = esya.esyaSayisi.ToString();

        }
        else if (esya.nitelik == Esya.EsyaNiteligi.tas)
        {

            tasTxt.text = esya.esyaSayisi.ToString();

        }
    }

    public int EsyaHarca(Esya esya)
    {
        int esyaSayisi;
        esyaSayisi = esya.esyaSayisi;
        esya.esyaSayisi = 0;
        return esyaSayisi;
    }

    public int TasHarca()
    {
        int esyaSayisi;
        esyaSayisi = tasEsya.esyaSayisi;
        tasEsya.esyaSayisi = 0;
        tasTxt.text = tasEsya.esyaSayisi.ToString();
        return esyaSayisi;
    }
    public int OdunHarca()
    {
        int esyaSayisi;
        esyaSayisi = odunEsya.esyaSayisi;
        odunEsya.esyaSayisi = 0;
        odunTxt.text = odunEsya.esyaSayisi.ToString();
        return esyaSayisi;
    }

    //public int TasHarca(int miktar)
    //{
    //    if (miktar < tasSayisi)
    //    {
    //        tasSayisi -= miktar;

    //        return miktar;
    //    }
    //    return 0;
    //}


    public Vector3 ToplanabilireHedefBelirle(Esya esya)
    {
        if (esya.nitelik == Esya.EsyaNiteligi.odun)
        {
            return mainCamera.ScreenToWorldPoint(odunImage.transform.position);
        }
        else if(esya.nitelik== Esya.EsyaNiteligi.tas)
        {
            return mainCamera.ScreenToWorldPoint(tasImage.transform.position);
        }

        return mainCamera.ScreenToWorldPoint(paraImage.transform.position);
    }


    public void ParaArttir(int miktar)
    {
        para.esyaSayisi += miktar;
        paraTxt.text = para.esyaSayisi.ToString();
    }
    public void ParaAzalt(int miktar)
    {
        para.esyaSayisi -= miktar;
        paraTxt.text = para.esyaSayisi.ToString();
    }

    public void GunArttir()
    {
        gun.veriSayisi++;
        GunKontrol();
        if (cocoToplayabilirMi)
        {
            coco.toplamaMesafesi = 3f;
            coco.ToplamaHiziniAyarla();
            coco.HedefeIlerle(coco.HedefObjeBelirle());

        }
    }
    private void GunKontrol()
    {
        if (gun.veriSayisi == 1)
        {
            araSahneYoneticisi.Karsilama();
        }else if (gun.veriSayisi == 5)
        {
            araSahneYoneticisi.Hediye();
        }else if (gun.veriSayisi == 10)
        {
            karakter.sprite = pembe;
            araSahneYoneticisi.Hediye2();
        }
    }
}
