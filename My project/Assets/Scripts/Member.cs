using System;

public struct Member
{
    string name { get; set; }
    DateTime birthday { get; set; }

    public Member(string name, DateTime birthday)
    {
        this.name = name;
        this.birthday = birthday;
    }
}
