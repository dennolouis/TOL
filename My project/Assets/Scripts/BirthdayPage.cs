using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class BirthdayPage : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] GameObject infoCardPrefab;

    List<Member> members = new List<Member>();
    List<GameObject> memberCards = new List<GameObject>();
    int activememberCards;

    RestAPI api;

    async void Start()
    {
        api = FindObjectOfType<RestAPI>();
        await RefreshData();
    }

    public void InstantiatePrefabIntoPanel()
    {
        foreach (GameObject card in memberCards)
        {
            Destroy(card);
        }
        memberCards.Clear();

        if (panel != null && infoCardPrefab != null)
        {
            foreach (Member member in members)
            {
                GameObject instantiatedUI = Instantiate(infoCardPrefab, panel.transform);
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
        foreach (GameObject memberCard in memberCards)
        {
            int memberBirthmonth = memberCard.GetComponent<InfoCard>().GetBirthMonth() - 1;
            memberCard.SetActive(monthIdx == memberBirthmonth);
            if (monthIdx == memberBirthmonth) activememberCards++;
        }
    }

    public int GetActivememberCards()
    {
        return activememberCards;
    }

    public async Task RefreshData()
    {
        await api.GetDataAsync();
        members = api.GetMembers();
        InstantiatePrefabIntoPanel();
        // Update visibility after refreshing data
        DateTime today = DateTime.Today;
        HandleBirthdayCardVisability(today.Month - 1);
    }
}
