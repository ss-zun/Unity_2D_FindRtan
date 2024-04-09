using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Board : MonoBehaviour
{
    public GameObject card;

    void Start()
    {
        // OrderBy : 오름차순 정렬, 정렬 기준 지정은 람다식 활용
        // OrderByDescending : 내림차순 정렬
        // X => : 0부터 순서대로 순회한다는 뜻
        // 0부터 Random.Range(0f, 7f)에서 나온 값을 우선순위로 지정
        // 각 요소마다 지정된 우선순위대로 정렬
        // 즉, 랜덤한 우선순위는 Random.Range(0f, 7f)에서 생성되며, 각 요소마다 랜덤한 우선순위가 부여됨
        // 이 우선순위에 따라 요소들이 정렬되어 새로운 배열이 생성됨
        // ToArray() 사용 이유 : OrderBy 자료형이 Array가 아니기 때문에 정렬한거를 배열로 바꾸기 위함
        int[] arr = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };
        arr = arr.OrderBy(x => Random.Range(0f, 7f)).ToArray();

        for (int i = 0; i < 16; i++)
        {
            GameObject go = Instantiate(card, this.transform); // 임시 변수

            float x = (i % 4) * 1.4f - 2.1f; // 나머지 * 카드 간격
            float y = (i / 4) * 1.4f - 3.0f; // 몫 * 카드 간격

            go.transform.position = new Vector2(x, y); // 카드 배치
            go.GetComponent<Card>().Setting(arr[i]);
        }

        GameManager.Instance.cardCount = arr.Length;
    }
}
