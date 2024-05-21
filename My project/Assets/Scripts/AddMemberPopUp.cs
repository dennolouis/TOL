using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AddMemberPopUp : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInputField;
    [SerializeField] private TMP_Dropdown monthDropdown;
    [SerializeField] private TMP_Dropdown dayDropdown;
    [SerializeField] private Button submitButton;
    [SerializeField] private GameObject popUpPanel;

    private RestAPI restAPI;

    private void Start()
    {
        restAPI = FindObjectOfType<RestAPI>();
        InitializeMonthDropdown();
        InitializeDayDropdown();
        submitButton.onClick.AddListener(OnSubmit);
        popUpPanel.SetActive(false);
    }

    private void InitializeMonthDropdown()
    {
        monthDropdown.ClearOptions();
        List<string> months = new List<string>
        {
            "January", "February", "March", "April", "May", "June",
            "July", "August", "September", "October", "November", "December"
        };
        monthDropdown.AddOptions(months);
    }

    private void InitializeDayDropdown()
    {
        dayDropdown.ClearOptions();
        List<string> days = new List<string>();
        for (int i = 1; i <= 31; i++)
        {
            days.Add(i.ToString());
        }
        dayDropdown.AddOptions(days);
    }

    public void OpenPopUp()
    {
        popUpPanel.SetActive(true);
    }

    private void OnSubmit()
    {
        string name = nameInputField.text;
        int month = monthDropdown.value + 1; // Dropdown value is 0-based, adding 1 for correct month number
        int day = int.Parse(dayDropdown.options[dayDropdown.value].text);

        StartCoroutine(restAPI.AddNewMember(name, day, month));

        // Close the pop-up
        popUpPanel.SetActive(false);

        // Optionally, clear the input fields
        nameInputField.text = string.Empty;
        monthDropdown.value = 0;
        dayDropdown.value = 0;
    }
}
