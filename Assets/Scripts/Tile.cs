using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Vector3 groundPos;

    public static Tile instance;
    private void Awake()
    {
        instance = this;
    }

}
 