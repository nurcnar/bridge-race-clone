using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PoolingManager : MonoBehaviour
{
    public List<GameObject> pool = new List<GameObject>();

    public GameObject player;
    public Vector3 p;

    public static PoolingManager instance;
    private void Awake()
    {
        instance = this;
    }
    public void Start()
    {
    }
    public void AddGameobjectToPool(GameObject tile)
    {
        pool.Add(tile);

    }
    
   
}
