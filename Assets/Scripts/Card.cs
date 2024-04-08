using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    int idx = 0;

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
    }
}
