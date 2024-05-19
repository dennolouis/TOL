using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MonthCard : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentMonth;
    [SerializeField] private Button next;
    [SerializeField] private Button prev;
    [SerializeField] private TextMeshProUGUI results;
    [SerializeField] private BirthdayPage birthdayPage;

    private string[] months =
    {
        "January", "February", "March", "April", "May", "June",
        "July", "August", "September", "October", "November", "December"
    };

    private int monthIdx;

    private void Start()
    {
        DateTime today = DateTime.Today;
        int todayMonthIdx = today.Month - 1;
        monthIdx = todayMonthIdx; // Ensure the initial month index is set

        // Handle the current month visibility and UI updates
        HandleCurrentMonth(todayMonthIdx);

        next.onClick.AddListener(Next);
        prev.onClick.AddListener(Prev);
    }

    public void Next()
    {
        HandleCurrentMonth(++monthIdx);
    }

    public void Prev()
    {
        HandleCurrentMonth(--monthIdx);
    }

    private void HandleCurrentMonth(int month)
    {
        monthIdx = (month + 12) % 12;
        currentMonth.text = months[monthIdx];
        birthdayPage.HandleBirthdayCardVisibility(monthIdx);
        results.text = "Results: " + birthdayPage.GetActiveMemberCards(); // Ensure results are updated
    }
}
