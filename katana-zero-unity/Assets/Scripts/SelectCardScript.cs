using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SelectCardScript : MonoBehaviour
{
    public Button[] Cards = new Button[3];
    public Sprite[] Sprites;

    // Start is called before the first frame update
    void Start()
    {
        Sprites = Resources.LoadAll<Sprite>("cards");

        List<Sprite> list = new(Sprites); // создаем список из массива
        Sprite[] result = new Sprite[3];
        int count = list.Count;

        for (int i = 0; i < 3; i++)
        {
            int index = UnityEngine.Random.Range(0, count);
            result[i] = list[index];
            count--;
            list[index] = list[count];
            list.RemoveAt(count);
        }

        for (int i = 0; i < 3; i++)
        {
            Image cardImage = Cards[i].GetComponent<Image>();
            cardImage.sprite = result[i];
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
