using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileHolder  : MonoBehaviour
{
    public Tile tileOnMe; // küp objesine bağlı script, groundPos konum bilgisini barındırıyor
    public GameObject tile;
    Color color;
    void Start()
    {

        tileOnMe = Instantiate(tile, transform.position , Quaternion.identity,transform).GetComponent<Tile>(); // Tile tipinde obje(küpler) yaratıp konumunu kendimizin olduğu yere verip çocuğumuz yaptık // boş objeye küp ekleyip onu çocuğumuz yaptık
        //color = CreateTile.instance.SelectColor(); // rengini verdik
        InitializeTile(); // yarattığımız küpe özellik ekleme fonksiyonunu çağırdık
        
    }

    void InitializeTile() // yarattığımız küpe özellik eklicez
    {
        tileOnMe.GetComponent<Tile>().groundPos = transform.position;
        tileOnMe.GetComponent<Transform>().tag = "tile";
        color = CreateTile.instance.SelectColor(); // rengini verdik

        tileOnMe.GetComponent<Renderer>().material.color = color;
    }

    public void RemoveTileOnMe() //küp ele alındığında o küpü yerden silme
    {
        tileOnMe.transform.parent = null; // küpü kendimizden ayırdık
        tileOnMe = null; // küpü sildik, referansını sildik
        StartCoroutine(RespawnTile());
    }
     IEnumerator RespawnTile()
    {
        yield return new WaitForSeconds(3);

        tileOnMe = Instantiate(tile, transform.position, Quaternion.identity, transform).GetComponent<Tile>(); // 3 saniye bekleyip yeni küp yarattık
        InitializeTile(); // yaratılan küpe özellik ekledik

    }
















    /*private void Start()
    {  
        tileOnMe = Instantiate(tile, transform.position, Quaternion.identity, transform).GetComponent<Tile>();
        color = CreateTile.instance.SelectColor();
        InitializeTile();
    }

    public void InitializeTile()
    {
        tileOnMe.GetComponent<Tile>().groundPos = transform.position;
        tileOnMe.GetComponent<Renderer>().material.color = color;
        tileOnMe.GetComponent<Transform>().tag = "tile";
    }

    public void RemoveTileOnMe()
    {
        tileOnMe.transform.parent = null;
        tileOnMe = null;
        StartCoroutine(RespawnTile());
    }
    
    public IEnumerator RespawnTile()
    {
        yield return new WaitForSeconds(3);
        tileOnMe = Instantiate(tile, transform.position, Quaternion.identity, transform).GetComponent<Tile>();
        //tileOnMe.transform.parent = this.gameObject.transform;
        InitializeTile();
    }*/
}
