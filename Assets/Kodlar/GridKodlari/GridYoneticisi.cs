using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Tilemap))]
//[RequireComponent(typeof(GridMap))]
public class GridYoneticisi : MonoBehaviour
{

    public GameObject tas;
    public GameObject kutuk;

    public int tarlaKonumuX = 0;
    public int tarlaKonumuY = 0;

    public Veri genislik;
    public Veri uzunluk;

    Tilemap tilemap;
    //GridMap grid;

    [SerializeField] TileSet tileSet;

    private int rasgele;

    public Transform bahce;

    private void Awake()
    {
        tilemap = GetComponent<Tilemap>();
        //grid = GetComponent<GridMap>();
        //grid.Olustur(genislik.veriSayisi, uzunluk.veriSayisi);
        //Set(1, 1, 2); //Silme
        //Set(2, 1, 2);
        //Set(1, 2, 2);
        TileMapiGuncelle();
    }

    public void TileMapiGuncelle()
    {
        for (int i = 0; i < genislik.veriSayisi; i++)
        {
            for (int j = 0; j < uzunluk.veriSayisi; j++)
            {
                KareyiGuncelle(i, j);
            }
        }
    }

    private void KareyiGuncelle(int i, int j)
    {
        //int tileID = grid.Get(i, j);
        //if (tileID == -1)
        //{
        //    return;
        //}

        tilemap.SetTile(new Vector3Int(i + tarlaKonumuX, -j + tarlaKonumuY, 0), tileSet.tiles[0]);

        Vector3 pozisyon = tilemap.CellToWorld(new Vector3Int(i + tarlaKonumuX, -j + tarlaKonumuY, 0)); // world pozisyonu en yakin hucreye ayarliyor olmasi lazim(yani en yakin int degerlerine)

        rasgele = (Random.value < 0.5f) ? -1 : 1;

        if (rasgele==1)
        {
            GameObject newObject = Instantiate(kutuk, pozisyon + new Vector3(0.5f,0,0), Quaternion.identity);
            newObject.transform.SetParent(bahce);

        }
        else
        {
            GameObject newObject = Instantiate(tas, pozisyon + new Vector3(0.5f, 0, 0), Quaternion.identity);
            newObject.transform.SetParent(bahce);

        }

    }

    public void Set(int x, int y, int to)
    {
        //grid.Set(x, y, to);
        KareyiGuncelle(x, y);
    }

    public void Ekle(int i, int j, int tileID)
    {
        tilemap.SetTile(new Vector3Int(i, j, 0), tileSet.tiles[tileID]);
    }


    public void BahcedekiTumObjeleriSil()
    {
        int childCount = bahce.childCount;

        for (int i = childCount - 1; i >= 0; i--)
        {
            Transform child = bahce.GetChild(i);
            Destroy(child.gameObject);
        }
    }
}
