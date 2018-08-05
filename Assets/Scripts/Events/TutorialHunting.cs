using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialHunting : MonoBehaviour {

    public int eventCode;
    public string description;
    public Button btPrefab;

    PlayerInfo playerInfo;

    public void StartTutorial1()
    {
        playerInfo = GameObject.FindGameObjectWithTag("PlayerInfoStorage").GetComponent<PlayerInfo>();
        Text info = GameObject.FindGameObjectWithTag("Info").GetComponent<Text>();
        Scrollbar infoBar = GameObject.FindGameObjectWithTag("InfoBar").GetComponent<Scrollbar>();
        info.text += "\n";

        if (playerInfo.family.aFamily.Count != 0)
        {
            Debug.Log("First hunting with family.");
            //let your family know you, set their releationship point towards u
            foreach (Villager fm in playerInfo.family.aFamily)
            {
                playerInfo.rsrData.Add(new ReleationshipRecord(fm, Random.Range(80, 120), 0));
            }

            info.text += playerInfo.monsterName + " is gonna start the first hunt with family.\n";

            if (playerInfo.family.aFamily[0].gender == 0)
            {
                info.text += "Brother " + playerInfo.family.aFamily[0] + " is bringing " + playerInfo.monsterName
                    + " to hunt, at the Icewind Cave.\n";
            }
            else if (playerInfo.family.aFamily[0].gender == 1)
            {
                info.text += "Sister " + playerInfo.family.aFamily[0] + " is bringing " + playerInfo.monsterName
                    + " to hunt, at the Icewind Cave.\n";
            }
            else
            {
                info.text += playerInfo.family.aFamily[0] + " is bringing " + playerInfo.monsterName
                       + " to hunt, at the Icewind Cave.\n";
            }

            infoBar.value = 1;
        }
        else
        {
            Debug.Log("First hunting alone.");
            info.text += playerInfo.monsterName + " is going to start the first hunt!\n";

            infoBar.value = 1;
        }

        info.text += "Click the button to start the hunt!\n";
        GameObject selectionP = GameObject.FindGameObjectWithTag("SelectionPanel");
        Button confirmBt = Instantiate(btPrefab);
        confirmBt.transform.SetParent(selectionP.transform);
        confirmBt.GetComponentInChildren<Text>().text = "Let The Hunt Start!";
        confirmBt.GetComponent<Button>().onClick.AddListener(LoadHuntingScene);
    }

    public void LoadHuntingScene()
    {
        SceneManager.LoadScene("FirstHunt");
    }
}
