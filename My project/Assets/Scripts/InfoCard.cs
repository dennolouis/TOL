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
        birthday.text = member.birthday.ToString();
        birthmonth = member.birthday.Month;
    }

    public int GetBirthMonth()
    {
        return birthmonth;
    }
}
