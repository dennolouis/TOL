using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirthdayPage : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] GameObject infoCardPrefab;

    List<Member> members = new List<Member>();
    List<GameObject> memberCards = new List<GameObject>();
    int activememberCards;
    
    void Awake ()
    {
        //Mock data
        members.Add(new Member("Denno", new System.DateTime(2001, 01, 18)));
        members.Add(new Member("John", new System.DateTime(1995, 12, 07)));
        members.Add(new Member("Emily", new System.DateTime(1988, 04, 25)));
        members.Add(new Member("Michael", new System.DateTime(1990, 08, 09)));
        members.Add(new Member("Sarah", new System.DateTime(1982, 11, 15)));
        members.Add(new Member("Daniel", new System.DateTime(1987, 03, 20)));
        members.Add(new Member("Jessica", new System.DateTime(1992, 05, 30)));
        members.Add(new Member("David", new System.DateTime(1984, 09, 08)));
        members.Add(new Member("Ashley", new System.DateTime(1991, 10, 18)));
        members.Add(new Member("James", new System.DateTime(1986, 12, 22)));
        members.Add(new Member("Amanda", new System.DateTime(1989, 02, 03)));
        members.Add(new Member("Matthew", new System.DateTime(1983, 06, 07)));
        members.Add(new Member("Jennifer", new System.DateTime(1994, 01, 14)));
        members.Add(new Member("Christopher", new System.DateTime(1980, 11, 28)));
        members.Add(new Member("Elizabeth", new System.DateTime(1993, 09, 05)));
        members.Add(new Member("Ryan", new System.DateTime(1981, 07, 17)));
        members.Add(new Member("Nicole", new System.DateTime(1985, 05, 10)));
        members.Add(new Member("Justin", new System.DateTime(1998, 03, 24)));
        members.Add(new Member("Lauren", new System.DateTime(1996, 02, 06)));
        members.Add(new Member("Brandon", new System.DateTime(1987, 12, 11)));
        members.Add(new Member("Hannah", new System.DateTime(1990, 10, 01)));

        InstantiatePrefabIntoPanel();
    }

    public void InstantiatePrefabIntoPanel()
    {
        if (panel != null && infoCardPrefab != null)
        {
            foreach(Member member in members)
            {
                GameObject instantiatedUI = Instantiate(infoCardPrefab, panel.transform);
                // Optionally, you can set properties or adjust the instantiated UI here
                instantiatedUI.GetComponent<InfoCard>().SetMember(member);
                memberCards.Add(instantiatedUI);
                print(member.birthday.Month);
            }        
        }
        else
        {
            Debug.LogError("Panel or UI Prefab references are missing!");
        }
    }

    public void HandleBirthdayCardVisability(int monthIdx)
    {
        activememberCards = 0;
        foreach(GameObject memberCard in memberCards)
        {
            int memberBirthmonth = memberCard.GetComponent<InfoCard>().GetBirthMonth()- 1;
            memberCard.SetActive(monthIdx == memberBirthmonth);
            if (monthIdx == memberBirthmonth) activememberCards++;
        }
    }
    
    public int GetActivememberCards()
    {
        return activememberCards;
    }
}
