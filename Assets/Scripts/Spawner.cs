using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//spawner is used when enter into the battle field
public class Spawner : MonoBehaviour {

    public GameObject monsterCounter;

    private void Start()
    {
        //spawn all the monster in the monster counter
        List<MonsterSet> ms = BattleFieldMonstersCreepSetting.monsterSet;
        
        foreach(MonsterSet m in ms)
        {
            for(int i = 0; i < m.monsterCount; i++)
            {
                //spawn single monster of the type

            }
        }

        //then clear the mosnter counter to empty
        BattleFieldMonstersCreepSetting.monsterSet = new List<MonsterSet>();
    }
}
