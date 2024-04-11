using System;

public struct Member
{
    public string name { get; set; }
    public DateTime birthday { get; set; }

    public Member(string name, DateTime birthday)
    {
        this.name = name;
        this.birthday = birthday;
    }
}
