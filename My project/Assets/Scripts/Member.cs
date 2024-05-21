using System;

[Serializable]
public class Member
{
    public string name;
    public int birthday;
    public int birthmonth; 

    public Member(string name, DateTime birthdate)
    {
        this.name = name;
        this.birthday = birthdate.Day;
        this.birthmonth = birthdate.Month;
    }

    public Member(string name, int birthmonth, int birthday)
    {
        this.name = name;
        this.birthday = birthday;
        this.birthmonth = birthmonth;
    }
}
