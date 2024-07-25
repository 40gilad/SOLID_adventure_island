using System;
using UnityEngine;

public class SC_PlayerLivesModel : ConcreteUIElementModel
{
    public SC_PlayerLivesModel(ConcreteUIElementController _controller,
        int initial_amount) : base(_controller,initial_amount)
    {

    }
    public override void Dec(int damage = 1)
    {
        base.Dec(damage);
        // make text bigger and Black for 1 second and then return to original state
    }
    public override void Inc(int a = 1)
    {
        base.Inc(a);
        // make text bigger and Red for 1 second and then return to original state

    }

}
