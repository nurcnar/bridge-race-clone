using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    public List<Tile> tiles = new List<Tile>();
    public static Bridge instance;
    private void Awake()
    {
        instance = this;
    }
}
