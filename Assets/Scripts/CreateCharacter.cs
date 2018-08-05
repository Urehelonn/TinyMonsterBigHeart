using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CreateCharacter : MonoBehaviour {
    
    Text info;
    Scrollbar infoBar;

    GameObject familyInTribe;

    public GameObject playerInfo;
    public GameObject startingPanel;

    public GameObject personalitiesCollection;
    public GameObject talentsCollection;
    public GameObject nameInput;

    public GameObject littleMonsterSprite;

    public GameObject nextEvent;

    void Start()
    {
        info = GameObject.FindGameObjectWithTag("Info").GetComponent<Text>();
        infoBar = GameObject.FindGameObjectWithTag("InfoBar").GetComponent<Scrollbar>();
        familyInTribe = GameObject.FindGameObjectWithTag("FamilyInTribe");
        littleMonsterSprite.SetActive(false);

        info.text += "Please Name your character. \n";
        info.text += "Identify its gender, and faith. \n";
        info.text += "Confirm the character by hit the button. \n \n \n";
    }

    public void GetProjectName()
    {
        playerInfo.GetComponent<PlayerInfo>().monsterName = nameInput.GetComponentInChildren<Text>().text;
    }

    public void CreateNano()
    {
        info.text += "......\n\nProject: " + playerInfo.GetComponent<PlayerInfo>().monsterName
            + "\nGender as: ";
        switch (playerInfo.GetComponent<PlayerInfo>().gender)
        {
            case 0: info.text += " Male \nFaith as: ";
                break;
            case 1: info.text += " Female \nFaith as: ";
                break;
            default:
                info.text += " Neutral \nFaith as: ";
                break;
        }
        
        switch (playerInfo.GetComponent<PlayerInfo>().belief)
        {
            case 0:
                info.text += " Sun ";
                break;
            case 1:
                info.text += " Moon ";
                break;
            default:
                info.text += " Star ";
                break;
        }

        info.text += "\nIs created.\n";
        
        //Destroy the starting panel
        Destroy(startingPanel,0f);

        //show little monster sprite
        playerInfo.GetComponent<PlayerInfo>().monsterColour = new Color(Random.Range(0F, 1F), Random.Range(0, 1F), Random.Range(0, 1F));
        littleMonsterSprite.SetActive(true);
        littleMonsterSprite.GetComponent<Renderer>().material.color
            = playerInfo.GetComponent<PlayerInfo>().monsterColour;

        //random generate other attributes for the character
        //generate random personalities        
        int temp1 = Random.Range(personalitiesCollection.GetComponent<Personalities>().personalities.Count-6,
            personalitiesCollection.GetComponent<Personalities>().personalities.Count-2); //Random.Range(7,10)
        List<int> personalities = new List<int>();

        //full the list with int
        for(int i = 0; i < personalitiesCollection.GetComponent<Personalities>().personalities.Count; i++)
        {
            personalities.Add(i);
        }
        //remove 1 between 5, 6
        personalities.RemoveAt(Random.Range(5,6));
        //remove 1 between 1, 2
        personalities.RemoveAt(Random.Range(1, 2));

        //remove random from the list
        for (int i = 0; i < temp1; i++)
        {
            int temp2 = Random.Range(0, personalities.Count);
            personalities.RemoveAt(temp2);
        }
        //if not evil(2), remove killer(9) as well
        if (!personalities.Contains(2) && personalities.Contains(9))
        {
            personalities.Remove(9);
            temp1--;
            Debug.Log("Removed killer since monster is not evil");
        }

        Debug.Log("gonna get " + (11 - temp1) + " personalities.");
        
        info.text += playerInfo.GetComponent<PlayerInfo>().monsterName + " has personality of: \n";

        //add personality unity into player info storage and the info console
        for (int i = 0; i < personalities.Count; i++)
        {
            playerInfo.GetComponent<PlayerInfo>().personalities.Add(
                personalitiesCollection.GetComponent<Personalities>()
                .personalities[personalities[i]]);

            info.text += " "+playerInfo.GetComponent<PlayerInfo>().personalities[i].name+" ";            
        }
        

        //start to add talents
        info.text += "\n and has talents of: \n";
        List<int> talents = new List<int>();
        //full the talent list first
        for (int i = 0; i < talentsCollection.GetComponent<Talents>().talents.Count; i++)
        {
            talents.Add(i);
        }

        //get new random size
        temp1 = Random.Range(talentsCollection.GetComponent<Talents>().talents.Count-2,
            talentsCollection.GetComponent<Talents>().talents.Count); //Random.Range(5,6);
        
        //remove random from the list
        for (int i = 0; i < temp1; i++)
        {
            talents.RemoveAt(Random.Range(0, talents.Count));
        }

        //add personality unity into player info storage and the info console
        for (int i = 0; i < talents.Count; i++)
        {
            playerInfo.GetComponent<PlayerInfo>().talents.Add(
                talentsCollection.GetComponent<Talents>()
                .talents[talents[i]]);

            info.text += " " + playerInfo.GetComponent<PlayerInfo>().talents[i].name + " ";
        }
        
        //add strength, agility and looking to project

        playerInfo.GetComponent<PlayerInfo>().strength =  Random.Range(2, 5);

        //if strong get 2 extra starter bonus
        if (talents.Contains(3))
        {
            playerInfo.GetComponent<PlayerInfo>().strength += 2;
        }
        //add to console
        info.text += "\nStrength: "+ playerInfo.GetComponent<PlayerInfo>().strength;

        playerInfo.GetComponent<PlayerInfo>().agility = Random.Range(2, 5);
        //if LikeACat get 2 extra starter bonus
        if (talents.Contains(6))
        {
            playerInfo.GetComponent<PlayerInfo>().agility += 2;
        }
        //add to console
        info.text += "\nAgility: " + playerInfo.GetComponent<PlayerInfo>().agility;


        playerInfo.GetComponent<PlayerInfo>().looking = Random.Range(1, 10);
        //if Charming get 2 or 1/4 bonus on looking;
        if (talents.Contains(2))
        {
            if (playerInfo.GetComponent<PlayerInfo>().looking / 4 > 2)
            {
                playerInfo.GetComponent<PlayerInfo>().looking +=
                    playerInfo.GetComponent<PlayerInfo>().looking / 4;
            }
            else playerInfo.GetComponent<PlayerInfo>().looking += 2;
        }
        //not gonna show project's looking to the player, this only effect on other villager;

        //find random family to project
        temp1 = Random.Range(0, familyInTribe.GetComponent<Tribe>().families.Count-1);
        playerInfo.GetComponent<PlayerInfo>().family = familyInTribe.GetComponent<Tribe>().families[temp1];

        info.text += "\nIs in the family of "+ playerInfo.GetComponent<PlayerInfo>().family.fName;

        //after finish create the character update all the information into the data obejct
        playerInfo.GetComponent<PlayerInfo>().CreateNewData();

        info.text += "\n\n"+ playerInfo.GetComponent<PlayerInfo>().monsterName+" is now a part of the tribe.";

        infoBar.value = 1;

        //starter part finished, now entering the first event, toturial.
        nextEvent.GetComponent<TutorialHunting>().StartTutorial1();
    }    
}