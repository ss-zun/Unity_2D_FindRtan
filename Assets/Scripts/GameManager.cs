using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Card firstCard;   // 첫 번째로 선택한 카드
    public Card secondCard;  // 두 번째로 선택한 카드

    public Text timeTxt;

    float time = 0.0f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timeTxt.text = time.ToString("N2");
    }

    // 카드 매치 기능
    public void Matched()
    {
        // 같은 그림
        if(firstCard.idx == secondCard.idx)
        {
            // 파괴해라.
            firstCard.DestroyCard();
            secondCard.DestroyCard();
        } // 다른 그림
        else
        {
            // 닫아라.
            firstCard.CloseCard();
            secondCard.CloseCard();
        }

        // 파괴든, 닫는거든 정보들을 빼주어야 함
        // 그래야 다음 카드 매치때 새로운 정보를 넣음
        firstCard = null;
        secondCard = null;
    }
}
