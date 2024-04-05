using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public GameObject card;

    void Start()
    {
        for (int i = 0; i < 16; i++)
        {
            GameObject go = Instantiate(card, this.transform); // 임시 변수

            float x = (i % 4) * 1.4f - 2.1f; // 나머지 * 카드 간격
            float y = (i / 4) * 1.4f - 3.0f; // 몫 * 카드 간격

            go.transform.position = new Vector2(x, y); // 카드 배치
        }
    }

    void Update()
    {
        
    }
}
