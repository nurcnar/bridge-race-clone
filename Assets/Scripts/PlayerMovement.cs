using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    int lastY=0;

    public List<Tile> hand = new List<Tile>();

    public Vector2 p1;
    public Vector2 p2;
    public Vector2 deltaV2;
    public Vector3 delta;
    public float r;

    public static PlayerMovement instance;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetMouseButtonDown(0))
        {
            p1 = Input.mousePosition;  
        }
        if(Input.GetMouseButton(0))
        {
            p2 = Input.mousePosition;
            deltaV2 = p2 - p1;
            
            r = Screen.height * .125f;

            if (deltaV2.magnitude>r)
            {
                float x = (deltaV2.magnitude - r);
                p1 += deltaV2.normalized * x;
            }


            deltaV2 = Vector2.ClampMagnitude(deltaV2, r);
            delta = new Vector3(deltaV2.x, 0, deltaV2.y);

            transform.position += delta * Time.deltaTime * .125f;

        }
        if (Input.GetMouseButtonUp(0))
        {
            //transform.position += delta * Time.deltaTime*.25f;
            
        }











        /*if (Input.GetKey(KeyCode.Mouse0))
        {
            target = playerCamera.ScreenToWorldPoint(Input.mousePosition);
            target.y = 0;
            //Vector3 direction = target - transform.position;
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
           
        }
        /*if (Input.GetMouseButton(0))
        {
            target = playerCamera.ScreenToWorldPoint(Input.mousePosition);
            target.y = 0;
        }
        transform.position = Vector3.MoveTowards(transform.position, target, .5f);
        */
        /*var delta = speed * Time.deltaTime;
        if (ShipAccelerates)
        {
            delta *= Vector3.Distance(transform.position, target);
        }

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;*/
        //transform.rotation = Quaternion.Euler(0f, 0f, rotation_z + offset);


    }


    private void OnTriggerEnter(Collider other)
    { 
        if(other.gameObject.CompareTag("tile") )
        {
            if(other.gameObject.GetComponent<Renderer>().material.color == GameManager.instance.color)
            {
                other.transform.parent.GetComponent<TileHolder>().RemoveTileOnMe(); // 3 saniye sonra yenisini yaratması için
                hand.Add(other.GetComponent<Tile>()); // objeyi eline ekliyo o anki konumuyla ilgili

                lastY++;
                other.transform.parent = this.transform;
                other.transform.localPosition = Vector3.up * lastY;
            }
        }


    }


    private void Update()
    {

        if(hand.Count>0) // elinde elemanla köprüye girdiyse
        {
            if(Bridge.instance.tiles.Count == 0) // köprüde eleman yoksa
            {
                if (transform.position.z > 9.5f)
                {
                    var tile = hand.Last(); //eldeki son obje yani en alttaki

                    Destroy(tile.GetComponent<Collider>()); //tekrar eline almaması için
                    tile.transform.parent = null; //konumu playerdan bağımsız artık
                    tile.transform.position = new Vector3(Bridge.instance.transform.position.x, Bridge.instance.transform.position.y, 10.5f); //köprünün önüne koyduk

                    Bridge.instance.tiles.Add(tile); //artık bridge listesinde
                    hand.Remove(tile); //elimizden sildik
                    lastY--; //sahnedekileri eline alırken dengesiz olmasın diye
                }

            }
            else
            {
                if(transform.position.z>Bridge.instance.tiles.Last().transform.position.z) //playerın konumu köprüdeki son objenin konumundan ilerdeyse
                {
                    var tile = hand.Last(); //en alttaki obje

                    Destroy(tile.GetComponent<Collider>());
                    tile.transform.parent = null;
                    tile.transform.position = Bridge.instance.tiles.Last().transform.position + Vector3.forward; //köprüdeki objenin bi önüne koyduk

                    Bridge.instance.tiles.Add(tile);
                    hand.Remove(tile);
                    lastY--;



                }
            }
            
        } 
        /*


        if (hand.Count > 0)
        {
            if (Bridge.instance.tiles.Count > 0)
            {
                if (transform.position.z > Bridge.instance.tiles.Last().transform.position.z)
                {
                    var tile = hand.Last();

                    tile.transform.position = Bridge.instance.tiles.Last().transform.position + Vector3.forward;
                    tile.transform.parent = null;
                    Destroy(tile.GetComponent<Collider>());

                    Bridge.instance.tiles.Add(tile);
                    hand.Remove(tile);
                    lastY--;
                }

            }
            else
            {
                if (transform.position.z > 9.5f)
                {
                    var tile = hand.Last();

                    tile.transform.position = new Vector3(Bridge.instance.transform.position.x, Bridge.instance.transform.position.y, 10.5f);
                    tile.transform.parent = null;
                    Destroy(tile.GetComponent<Collider>());

                    Bridge.instance.tiles.Add(tile);
                    hand.Remove(tile);
                    lastY--;
                    

                }
            }
        }*/
    }





    


}

