using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ConcreteUIElementModel
{
    protected int amount;
    protected abstract void Init(int initial_amount);

    public ConcreteUIElementModel(int initial_amount)
    {
        Init(initial_amount);
    }
    public int Get()
    {
        return amount;
    }

    public void Inc()
    {
        amount++;
    }

    public void Dec()
    {
        if (amount > 0) amount--;
    }
}
