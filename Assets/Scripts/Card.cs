using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    int idx = 0;

    public SpriteRenderer front;

    public void Setting(int number)
    {
        idx = number;
        front.sprite = Resources.Load<Sprite>($"rtan{idx}");
    }
}
