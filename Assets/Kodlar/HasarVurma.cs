using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasarVurma : MonoBehaviour
{
    public Camera mainCamera;

    public LayerMask kaynakLayeri;

    public Vector2 characterPosition { get; private set; }

    public float yakinMesKarakterin = 5f;

    public bool vurabilirMi;


    public float hasar = 10f;

    public Animator anim;

    Kaynak hedefTut;

    void Update()
    {
        Hasar();
    }


    public void Hasar()
    {

        Vector3 fareKonumu = Input.mousePosition;
        fareKonumu.z = 10f;
        Vector2 mouseWorldPosition = mainCamera.ScreenToWorldPoint(fareKonumu);

        Collider2D hitCollider = Physics2D.OverlapPoint(mouseWorldPosition, kaynakLayeri);



        if (hitCollider != null && hitCollider.gameObject.tag == "kaynak") // && hitCollider.gameObject.tag == "kaynak"
        {
            characterPosition = transform.position;
            float distanceToResource = Vector2.Distance(characterPosition, hitCollider.transform.position);

            Kaynak hedef = hitCollider.gameObject.GetComponent<Kaynak>();

            if (distanceToResource < yakinMesKarakterin)
            {


                hedef.CerceveAc();

                if (Input.GetButtonDown("Fire1") && vurabilirMi)
                {
                    //giris.SaldiriGirisiniKullan();

                    //sesYonetim.Oynat("vurma");

                    //hedef.TakeDamage(hasar);
                    SesYoneticisi.orn.Oynat("vurma");

                    hedefTut = hedef;   // animasyondan sonra vurmasi icin hedef objeyi tutuyor

                    anim.SetBool("vur", true);

                    vurabilirMi = false; // animasyon icin kullanilacak

                }

            }
            else
            {
                hedef.CerceveKapa();
            }
        }

        if (hitCollider != null && hitCollider.gameObject.tag == "toplanabilir")
        {
            hitCollider.GetComponent<Toplanabilir>().EsyayiAl();
        }
        
    }

    public void VurAnim() //Vurma animasyonu bitince hedefe hasar veriyor ve karakterin tekrar vurabilme iznini veriyor
    {
        hedefTut.TakeDamage(hasar);

        anim.SetBool("vur", false);
        vurabilirMi = true;
        SesYoneticisi.orn.Durdur("vurma");

    }
}
