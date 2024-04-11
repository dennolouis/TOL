using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoCard : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI memberName;
    [SerializeField] TextMeshProUGUI birthday;

    public void SetMember(Member member)
    {
        memberName.text = member.name;
        birthday.text = member.birthday.ToString();
    }
}
