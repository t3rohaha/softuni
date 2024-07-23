﻿using SOLID.P04_Recharge.Interfaces;

namespace SOLID.P04_Recharge.Models;
public class Robot : Worker, IRechargeable
{
    public Robot(string id, int capacity) : base(id)
    {
        Capacity = capacity;
    }

    public int Capacity { get; }
    public int CurrentPower { get; private set; }

    public override void Work(int hours)
    {
        if (hours > CurrentPower)
        {
            hours = CurrentPower;
        }

        base.Work(hours);

        CurrentPower -= hours;
    }

    public void Recharge()
    {
        CurrentPower = Capacity;
    }
}