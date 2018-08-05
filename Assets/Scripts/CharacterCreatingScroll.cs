using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCreatingScroll : MonoBehaviour {

    public Scrollbar sbGender;
    public Text txtGender;

    public Scrollbar sbBelief;
    public Text beliefExp;
    public Text txtBelief;

    public PlayerInfo playerInfo;

	public void onGenderScrollBarChanged()
    {
        if (sbGender.value < 0.4)
        {
            txtGender.text = "Male";
            //playerInfo.gender = 0;
            playerInfo.gender = 0;
        }
        else if (sbGender.value > 0.6)
        {
            txtGender.text = "Female";
            playerInfo.gender = 1;
        }
        else
        {
            txtGender.text = "Neutral";
            playerInfo.gender = 2;
        }
    }

    public void onFaithScrollBarChanged()
    {
        if (sbBelief.value < 0.4)
        {
            txtBelief.text = "Sun";
            beliefExp.text = "When gain happiness, has 40% chance to gain 10% - 50% extra happiness.";
            playerInfo.belief = 0;
        }
        else if (sbBelief.value > 0.7)
        {
            txtBelief.text = "Moon";
            beliefExp.text = "Droping of happiness decreased by 20%.";
            playerInfo.belief = 1;
        }
        else
        {
            txtBelief.text = "Star";
            beliefExp.text = "All the basic needs are decresed by 15%.";
            playerInfo.belief = 2;
        }
    }
}
