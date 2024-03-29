using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirthdayPage : MonoBehaviour
{

    List<Member> members = new List<Member>();
    
    void Start()
    {
        //Mock data
        members.Add(new Member("Denno", new System.DateTime(2001, 18, 01)));
        members.Add(new Member("John", new System.DateTime(1995, 7, 12)));
        members.Add(new Member("Emily", new System.DateTime(1988, 4, 25)));
        members.Add(new Member("Michael", new System.DateTime(1990, 9, 8)));
        members.Add(new Member("Sarah", new System.DateTime(1982, 11, 15)));
        members.Add(new Member("Daniel", new System.DateTime(1987, 3, 20)));
        members.Add(new Member("Jessica", new System.DateTime(1992, 5, 30)));
        members.Add(new Member("David", new System.DateTime(1984, 8, 9)));
        members.Add(new Member("Ashley", new System.DateTime(1991, 10, 18)));
        members.Add(new Member("James", new System.DateTime(1986, 12, 22)));
        members.Add(new Member("Amanda", new System.DateTime(1989, 2, 3)));
        members.Add(new Member("Matthew", new System.DateTime(1983, 6, 7)));
        members.Add(new Member("Jennifer", new System.DateTime(1994, 1, 14)));
        members.Add(new Member("Christopher", new System.DateTime(1980, 11, 28)));
        members.Add(new Member("Elizabeth", new System.DateTime(1993, 9, 5)));
        members.Add(new Member("Ryan", new System.DateTime(1981, 7, 17)));
        members.Add(new Member("Nicole", new System.DateTime(1985, 5, 10)));
        members.Add(new Member("Justin", new System.DateTime(1998, 3, 24)));
        members.Add(new Member("Lauren", new System.DateTime(1996, 2, 6)));
        members.Add(new Member("Brandon", new System.DateTime(1987, 12, 11)));
        members.Add(new Member("Hannah", new System.DateTime(1990, 10, 1)));

    }
}
