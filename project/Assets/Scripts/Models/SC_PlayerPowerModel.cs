using System;
using UnityEngine;

public class SC_PlayerPowerModel : ConcreteUIElementModel
{
    public SC_PlayerPowerModel(int initial_amount) : base(initial_amount)
    {

    }
    protected override void Init(int initial_amount)
    {
        if (initial_amount <= 0)
            throw new ArgumentOutOfRangeException("initial_power");
        amount = initial_amount;
    }
}
