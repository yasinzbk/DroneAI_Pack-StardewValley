using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMap : MonoBehaviour
{
    public int yukseklik { get; private set; }
    public int uzunluk { get; private set; }

    List<List<int>> grid = new List<List<int>>();

    public void Olustur(int uzunluk, int yukseklik)
    {
        for (int i = 0; i < uzunluk; i++)
        {
            List<int> innerList = new List<int>();
            for (int j = 0; j < yukseklik; j++)
            {
                innerList.Add(0); // 0'larla doldurabilirsiniz, istediðiniz deðerleri ekleyebilirsiniz
            }
            grid.Add(innerList);
        }

        this.uzunluk = uzunluk;
        this.yukseklik = yukseklik;
    }

    public void Set(int x, int y,int t)
    {
        if (!PozisyonKontrol(x, y))
        {
           
            return;
        }
        grid[x][y] = t;
    }

    public int Get(int x, int y)
    {
        if (!PozisyonKontrol(x, y))
        {
            return -1;
        }
        return grid[x][y];
    }

    public bool PozisyonKontrol(int x,int y)
    {
        if (x < 0 || x >= uzunluk)
        {
            return false;
        }

        if (y < 0 || y >= yukseklik)
        {
            return false;
        }

        return true;
    }

    public void SetBuyuklukler(int uzunluk, int yukseklik)
    {
        this.uzunluk = uzunluk;
        this.yukseklik = yukseklik;
    }

}
