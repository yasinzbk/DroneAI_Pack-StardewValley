using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraTakip : MonoBehaviour
{
    public Transform target; // takip edilecek obje

    public GameObject eskiTakipEdilenObje;

    void LateUpdate()
    {
        if (target != null)
        {
            transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
        }
    }



    public void TakipEdilenKisiyiDegistir(GameObject takipEdilecekObje, float kameraDegistirmeSuresi)
    {


        StartCoroutine(KameraTakipDegistir(takipEdilecekObje, kameraDegistirmeSuresi));


    }



    IEnumerator KameraTakipDegistir(GameObject takipEdilecekObje, float kameraDegismeSuresi)
    {


        target = takipEdilecekObje.transform;

        yield return new WaitForSeconds(kameraDegismeSuresi);
        target = eskiTakipEdilenObje.transform;
    }
}