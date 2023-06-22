using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AraSahneYoneticisi : MonoBehaviour
{
    public GameObject komsu1;
    public GameObject karakter;
    public GameObject karakterMetin;

    public DialogTetikleyici komsu1Dialog;
    public DialogT karakterDialog;

    public Coco coco;
    public GameObject coco2;

    public GameObject cocoBar;
    public GameObject cocoBar2;

    public Veri cocoVeri;

    public Veri cocoIstenenVeri;

    public GameManager gameManager;
    private void Update()
    {
    }

    public void Karsilama()
    {
        komsu1.SetActive(true);
        komsu1Dialog.DialogTetikle(0);
    }

    public void Hediye()
    {
        komsu1.SetActive(true);
        komsu1Dialog.DialogTetikle(1);

        coco.gameObject.SetActive(true);
        cocoBar.SetActive(true);
        cocoBar2.SetActive(true);

        cocoVeri.veriSayisi = 0;
        cocoIstenenVeri.veriSayisi = 10;
        gameManager.cocoAktifMi2 = true;
    }

    public void Hediye2()
    {
        karakter.SetActive(true);
        karakterDialog.DialogTetikle(0);

        coco2.gameObject.SetActive(true);
        karakterMetin.SetActive(true);
    }
}
