using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ConcreteUIElementModel
{
    protected int amount;
    public ConcreteUIElementModel(int initial_amount)
    {
        Init(initial_amount);
    }

    protected void Init(int initial_amount)
    {
        if (initial_amount <= 0)
            throw new ArgumentOutOfRangeException("initial_power");
        amount = initial_amount;
    }
    public int Get()
    {
        return amount;
    }

    public void Inc(int a=1)
    {
        amount+=a;
    }

    public void Dec(int a = 1)
    {
        if (amount > 0) amount-=a;
    }
}
