using UnityEngine;
using TMPro;

public class InfoCard : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI birthdayText;

    private Member member;

    public void SetMember(Member member)
    {
        this.member = member;
        nameText.text = member.name;
        birthdayText.text = member.birthday.ToString();
    }

    public int GetBirthMonth()
    {
        return member.birthmonth;
    }

    public string GetMemberName()
    {
        return member.name;
    }

    public string GetBirthDayMonth()
    {
        return $"{member.birthmonth}/{member.birthday}";
    }
}
