using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSymbol : RoomSymbol
{
    public override void Encounter()
    {
        base.Encounter();

        Debug.Log("보스 등장!");
    }

    //보스 클리어 시, 레벨 클리어 이벤트 실행
    public override void End()
    {
        LevelManager.Instance.OnLevelClear();
    }
}
