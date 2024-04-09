using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int idx = 0;

    public GameObject front; // 카드 이미지면
    public GameObject back;  // 카드 물음표면

    public Animator anim; // Card 프리팹의 애니메이션

    public SpriteRenderer frontImage; // 카드 이미지

    // 카드 랜덤값, 이미지 셋팅
    public void Setting(int number)
    {
        idx = number; // 카드마다 랜덤값 지정
        frontImage.sprite = Resources.Load<Sprite>($"rtan{idx}"); // 리소스 이미지 불러오기
    }

    // 카드가 오픈됐을 때
    public void OpenCard()
    {
        anim.SetBool("isOpen", true);
        front.SetActive(true);
        back.SetActive(false);

        // firstCard가 비었다면,
        if(GameManager.Instance.firstCard == null)
        {
            // firstCard에 내 정보를 넘겨준다.
            GameManager.Instance.firstCard = this;
        }
        // firstCard가 비어있지 않다면,
        else
        {
            // secondCard에 내 정보를 넘겨준다.
            GameManager.Instance.secondCard = this;
            // Mached 함수를 호출해 준다.
            GameManager.Instance.Matched();
        }
    }

    // 1초 후 카드 파괴
    public void DestroyCard()
    {
        Invoke("DestroyCardInvoke", 0.5f);
    }

    // 카드 파괴
    public void DestroyCardInvoke()
    {
        Destroy(gameObject);
    }

    // 1초 후 카드 닫기
    public void CloseCard()
    {
        Invoke("CloseCardInvoke", 0.5f);
    }

    // 카드 닫기
    public void CloseCardInvoke()
    {
        anim.SetBool("isOpen", false); // Idle 상태로 변경
        front.SetActive(false);
        back.SetActive(true);
    }
}
