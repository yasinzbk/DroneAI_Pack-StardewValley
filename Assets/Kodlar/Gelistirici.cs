using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Gelistirici : MonoBehaviour
{
    public int paraArtisiUzunluk;
    public int paraArtisiGenislik;

    public Veri uzunluk;
    public Veri genislik;
    public Veri evSeviye;

    public Esya UzunlukPara;
    public Esya GenislikPara;
    public Esya evPara;
    public Esya evOdun;

    public Denklem uzunlukDenklemi;
    public Denklem genilikDenklemi;
    public Denklem evDenklem;

    public GameManager gameManager;

    public TextMeshProUGUI uzunlukParaTxt;
    public TextMeshProUGUI genislikParaTxt;

    public SpriteRenderer evSR;

    public Sprite ev1;
    public Sprite ev2;

    public GameObject Ev2Buton;

    public GameObject Ev3Buton;
    [field: SerializeReference] public List<Esya> esyalar { get; private set; }


    public bool DenklemKontrol(Denklem denklem)
    {

        int tamamlananEsyalar = 0;
        int gerekenEsyaMiktari = denklem.gerekenEsyalar.Count;

        for (int i = 0; i < gerekenEsyaMiktari; i++)
        {
            for (int j = 0; j < esyalar.Count; j++)
            {
                if (denklem.gerekenEsyalar[i].nitelik == esyalar[j].nitelik)
                {
                    if (esyalar[j].esyaSayisi >= denklem.gerekenEsyalar[i].esyaSayisi)
                    {
                        tamamlananEsyalar++;
                    }
                }
            }
        }

        if (tamamlananEsyalar == gerekenEsyaMiktari)
        {
            return true;
        }

            return false;
     
    }

    public void UzunlukGelistir()
    {
        if (DenklemKontrol(uzunlukDenklemi))
        {
            uzunluk.veriSayisi++;

            int miktar = UzunlukPara.esyaSayisi;
            // uzunluk gereken para artar
            UzunlukPara.esyaSayisi= UzunlukPara.esyaSayisi + paraArtisiUzunluk;
            // UI guncellenir
            uzunlukParaTxt.text = UzunlukPara.esyaSayisi.ToString();
            // parayi azalt
            gameManager.ParaAzalt(miktar);

        }
    }

    public void GenislikGelistir()
    {
        if (DenklemKontrol(genilikDenklemi))
        {
            genislik.veriSayisi++;

            int miktar = GenislikPara.esyaSayisi;
            // uzunluk gereken para artar
            GenislikPara.esyaSayisi = GenislikPara.esyaSayisi + paraArtisiGenislik;
            // UI guncellenir
            genislikParaTxt.text = GenislikPara.esyaSayisi.ToString();
            // parayi azalt
            gameManager.ParaAzalt(miktar);

        }
    }

    public void EvGelistir()
    {
        if (DenklemKontrol(evDenklem))
        {

            if (evSeviye.veriSayisi == 2)
            {
                // ev sprite 2 degis 
                evSR.sprite = ev1;
                evSeviye.veriSayisi++;

                int miktar = evPara.esyaSayisi;
                gameManager.ParaAzalt(miktar);

                evPara.esyaSayisi = 500;

                Ev2Buton.SetActive(false);
                Ev3Buton.SetActive(true);
               

            }
            else
            {
                // ev sprite 3 degis
                evSR.sprite = ev2;

                int miktar = evPara.esyaSayisi;
                gameManager.ParaAzalt(miktar);

            }

        }
    }

}
