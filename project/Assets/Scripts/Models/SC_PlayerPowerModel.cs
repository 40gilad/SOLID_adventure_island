using System;
using UnityEngine;

public class SC_PlayerPowerModel
{
    private int power;

    public SC_PlayerPowerModel(int initial_power)
    {
        if (initial_power <= 0)
            throw new ArgumentOutOfRangeException("initial_power");
        this.power = initial_power;
    }

    public int Get()
    {
        return power;
    }

    public void Inc()
    {
        power++;
    }

    public void Dec()
    {
        if (power > 0) power--;
    }

}
