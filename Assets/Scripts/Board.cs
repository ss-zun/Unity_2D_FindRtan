using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public GameObject card;

    void Start()
    {
        for(int i = 0; i < 16; i++)
        {
            Instantiate(card, this.transform);
        }
    }

    void Update()
    {
        
    }
}
