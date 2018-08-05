using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleFieldMonstersCreepSetting: MonoBehaviour{
    
    public List<MonsterSet> monsterSetOnMap;

    public static List<MonsterSet> monsterSet = new List<MonsterSet>();
    
    private void Update()
    {
        monsterSetOnMap = monsterSet;
    }

}
