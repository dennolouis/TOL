using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MonthCard : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI currentMonth;
    [SerializeField] Button next;
    [SerializeField] Button prev;
    [SerializeField] TextMeshProUGUI results;

    [SerializeField] BirthdayPage birthdayPage;

    string[] months = 
        {"January","February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"};

    int monthIdx;
    void Awake()
    {
        HandleCurrentMonth(0);
    }

    private void Start()
    {
        birthdayPage.HandleBirthdayCardVisability(monthIdx);
    }

    public void Next()
    {
        HandleCurrentMonth(++monthIdx);
    }

    public void Prev()
    {
        HandleCurrentMonth(--monthIdx);
    }

    void HandleCurrentMonth(int month)
    {
        monthIdx = month == -1? 11: month % 12;
        currentMonth.text = months[monthIdx];
        birthdayPage.HandleBirthdayCardVisability(monthIdx);
        results.text = "Results: " + birthdayPage.GetActivememberCards().ToString();
    }
}
