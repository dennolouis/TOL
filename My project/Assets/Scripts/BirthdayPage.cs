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

    RestAPI api;
    
    void Start ()
    {
        api = FindObjectOfType<RestAPI>();

        members = api.GetMembers();

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

    public void RefreshData()
    {
        members = api.GetMembers();
        InstantiatePrefabIntoPanel();
    }
}
