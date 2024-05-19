using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BirthdayPage : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject infoCardPrefab;
    [SerializeField] private TextMeshProUGUI results; // Add this field

    private List<Member> members = new List<Member>();
    private List<GameObject> memberCards = new List<GameObject>();
    private int activeMemberCards;

    private RestAPI api;

    private async void Start()
    {
        api = FindObjectOfType<RestAPI>();
        await api.InitializeAsync();
        members = api.GetMembers();
        InstantiatePrefabIntoPanel();

        // Ensure only the current month's member cards are visible
        DateTime today = DateTime.Today;
        int todayMonthIdx = today.Month - 1;
        HandleBirthdayCardVisibility(todayMonthIdx);
        UpdateResultsCount(); // Update the results count
    }

    public void InstantiatePrefabIntoPanel()
    {
        if (panel != null && infoCardPrefab != null)
        {
            foreach (Member member in members)
            {
                GameObject instantiatedUI = Instantiate(infoCardPrefab, panel.transform);
                InfoCard infoCard = instantiatedUI.GetComponent<InfoCard>();
                if (infoCard != null)
                {
                    infoCard.SetMember(member);
                    memberCards.Add(instantiatedUI);
                }
                else
                {
                    Debug.LogError("InfoCard component not found on instantiated prefab.");
                }
            }
        }
        else
        {
            Debug.LogError("Panel or UI Prefab references are missing!");
        }
    }

    public void HandleBirthdayCardVisibility(int monthIdx)
    {
        activeMemberCards = 0;
        foreach (GameObject memberCard in memberCards)
        {
            int memberBirthmonth = memberCard.GetComponent<InfoCard>().GetBirthMonth() - 1;
            memberCard.SetActive(monthIdx == memberBirthmonth);
            if (monthIdx == memberBirthmonth) activeMemberCards++;
        }
    }

    public int GetActiveMemberCards()
    {
        return activeMemberCards;
    }

    public void RefreshData()
    {
        members = api.GetMembers();
        InstantiatePrefabIntoPanel();
    }

    // Add this method to update the results count
    private void UpdateResultsCount()
    {
        if (results != null)
        {
            results.text = "Results: " + GetActiveMemberCards();
        }
    }
}
