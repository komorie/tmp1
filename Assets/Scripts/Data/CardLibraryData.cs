using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//1. 전체 카드 데이터를 들고 있는 클래스.
//2. 다른 UI 등에서 사용할, 특정 카드 가져오기 함수 존재.

public class CardLibraryData : Singleton<CardLibraryData>
{
    //모든 카드가 담긴 딕셔너리
    private Dictionary<int, Card> CardLibraryDic { get; set; } = new Dictionary<int, Card>();

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
        JsonData CardLibraryData = DataManager.Instance.LoadJson("CardLibrary");

        for (int i = 0; i < CardLibraryData.Count; i++)
        {
            Card card = new Card(
                int.Parse(CardLibraryData[i]["index"].ToString()),
                CardLibraryData[i]["name"].ToString(),
                CardLibraryData[i]["description"].ToString(),
                int.Parse(CardLibraryData[i]["cost"].ToString()),
                int.Parse(CardLibraryData[i]["damage"].ToString()),
                int.Parse(CardLibraryData[i]["attackCount"].ToString()),
                CardLibraryData[i]["attackRange"].ToString(),
                CardLibraryData[i]["attribute"]?.ToString(),
                CardLibraryData[i]["damagetype"]?.ToString(),
                CardLibraryData[i]["rarity"].ToString()
            );

            CardLibraryDic.Add(card.index, card);    

        }


    }

    //특정 번호의 카드를 가져온다.
    public Card GetCard(int index)
    {
        Card card;
        CardLibraryDic.TryGetValue(index, out card);
        return card;
    }
}
