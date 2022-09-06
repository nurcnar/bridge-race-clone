using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Color color;
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        StartCoroutine(ChangePlayerColor());
        
    }

    IEnumerator ChangePlayerColor()
    {
        while(true)
        {
            color = CreateTile.instance.SelectColor();
            PlayerMovement.instance.GetComponent<Renderer>().material.color = color;

            yield return new WaitForSeconds(10);
        }

    }
}
