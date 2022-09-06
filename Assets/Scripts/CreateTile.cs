using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTile : MonoBehaviour
{
    public static CreateTile instance;
    private void Awake()
    {
        instance = this;
    }

    public GameObject tileHolder;
    Color color;
    public Color SelectColor()
    {
        int r = Random.Range(0, 3);
        switch (r)
        {
            case 0:
                color = Color.blue;
                break;
            case 1:
                color = Color.green;
                break;
            case 2:
                color = Color.red;
                break;
        }
        return color;
    }
    private void Start()
    {
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                GameObject clone = Instantiate(tileHolder, new Vector3(-9 + 3 * i, 0, -9 + 3 * j), Quaternion.identity); // boş bir gameobject yarattık
            }
        }
    }
}