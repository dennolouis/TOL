using System;

public class Member
{
    public string Name { get; private set; }
    public DateTime Birthday { get; private set; }

    public Member(string name, DateTime birthday)
    {
        this.Name = name;
        this.Birthday = birthday;
    }
}
