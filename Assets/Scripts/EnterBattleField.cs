using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterBattleField : MonoBehaviour {

    //indicate which monster met for the project
    public Monster monsterMet;
    //indicate how many of those mosnters did player met
    public int number;
    //indicate which battle field will be displayed on
    public string place;
    public GameObject monsterCounter;

    void OnCollisionEnter2D(Collision2D col)
    {
        //if hit player in the main field, go to battle field
        if(col.gameObject.tag == "Player")
        {
            //change static value of the monster counter;
            BattleFieldMonstersCreepSetting.monsterSet.Add(new MonsterSet(monsterMet, number));
            //go to the battle scene
            SceneManager.LoadScene(place);

            Debug.Log(BattleFieldMonstersCreepSetting.monsterSet[0].monster.monsterName);
        }            
    }
}
