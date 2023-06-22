using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Karakter : MonoBehaviour
{
    public delegate void ElindekiEsyaDegistiginde();
    public ElindekiEsyaDegistiginde elindekiEsyaDegistigindeGeriCagir;

    public float hareketHizi = 2f;

    public Rigidbody2D RB { get; private set; }
    private Vector2 calismaAlani;
    public Vector2 SuankiHiz { get; private set; }  // karakterin hizina gore farkli eylemler yapildiginda kullanilacak

    float screenWidth = Screen.width;
    public Camera mainCamera;



    public int yuzununYonu = 1;


    public Animator anim;

    bool hareketEdiyorMu = false;

    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        anim = GetComponent<Animator>();

    }

    void Update()
    {
        Hareket();

        //Dondur();
    }

    void Hareket()
    {
        float yonX = Input.GetAxis("Horizontal");
        float yonY = Input.GetAxis("Vertical");


        anim.SetFloat("yYonu", yonY);

        if (yonX != 0.0f)
        {
            anim.SetBool("xVarMi", true);
        }
        else
        {
            anim.SetBool("xVarMi", false);

        }

        if (yonX == 0.0f && yonY == 0.0f)
        {
            hareketEdiyorMu = false;
        }
        else
        {
            hareketEdiyorMu = true;
        }

        anim.SetBool("hareket", hareketEdiyorMu);
        anim.SetInteger("yonu", yuzununYonu);

        XhiziniKur(hareketHizi * yonX);
        YhiziniKur(hareketHizi * yonY);


        if (yonX < 0.0)
        {
            if (yuzununYonu == 1)
            {
                RB.transform.Rotate(0, 180f, 0);
                yuzununYonu = -yuzununYonu;

            }
        }
        else if (yonX > 0.0 && yuzununYonu == -1)
        {
            // Fare karakterin saginda
            RB.transform.Rotate(0, 180f, 0);
            yuzununYonu = -yuzununYonu;
        }
    }

    void Dondur()
    {
        Vector3 mousePosition = Input.mousePosition;
        float normalizedX = mousePosition.x / screenWidth;
        Vector3 karakterinEkranKonumu = mainCamera.WorldToScreenPoint(transform.position);

        float normalizedKarX = karakterinEkranKonumu.x / screenWidth;

        if (normalizedX < normalizedKarX)
        {
            // Fare karakterin solunda

            if (yuzununYonu == 1)
            {
                RB.transform.Rotate(0, 180f, 0);
                yuzununYonu = -yuzununYonu;

            }
        }
        else if (yuzununYonu == -1)
        {
            // Fare karakterin saginda
            RB.transform.Rotate(0, 180f, 0);
            yuzununYonu = -yuzununYonu;
        }

    }

    public void XhiziniKur(float hiz)
    {
        calismaAlani.Set(hiz, SuankiHiz.y);
        SonHizKur();
    }

    public void YhiziniKur(float hiz)
    {
        calismaAlani.Set(SuankiHiz.x, hiz);
        SonHizKur();
    }

    private void SonHizKur()
    {
        RB.velocity = calismaAlani;
        SuankiHiz = calismaAlani;
    }


}
