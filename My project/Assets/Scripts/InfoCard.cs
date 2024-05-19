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
        nameText.text = member.Name;
        birthdayText.text = member.Birthday.ToString("MMMM dd");
    }

    public int GetBirthMonth()
    {
        return member.Birthday.Month;
    }
}
