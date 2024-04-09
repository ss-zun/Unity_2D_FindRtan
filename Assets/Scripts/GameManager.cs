using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Card firstCard;   // 첫 번째로 선택한 카드
    public Card secondCard;  // 두 번째로 선택한 카드

    public Text timeTxt;  // 게임 시간 표시
    public GameObject endTxt;   // 게임이 끝났을 때 뜨는 '끝'

    public int cardCount = 0;  // 현재 남아있는 카드의 개수
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
        Application.targetFrameRate = 60; // 어떤 기기든지 초당 60프레임으로 렌더링 설정
        Time.timeScale = 1.0f;
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
            cardCount -= 2;
            if(cardCount == 0)
            {
                Time.timeScale = 0.0f;
                endTxt.SetActive(true); // Text 형으로 안받고 GameObject형으로 받아서 생략가능
            }
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
