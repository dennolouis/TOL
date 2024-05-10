using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoCard : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI memberName;
    [SerializeField] TextMeshProUGUI birthday;
    int birthmonth;
    public void SetMember(Member member)
    {
        memberName.text = member.name;
        birthday.text = FormatBirthday(member.birthday);
        birthmonth = member.birthday.Month;
    }

    public int GetBirthMonth()
    {
        return birthmonth;
    }

    string FormatBirthday(DateTime birthday)
    {
        return birthday.Day.ToString();
    }
}
