using System;

namespace DeliverySystem.User;

public class User
{
    public string Name { get; }
    public string Address { get; }

    public User(string name, string address)
    {
        Name = name;
        Address = address;
    }
}
