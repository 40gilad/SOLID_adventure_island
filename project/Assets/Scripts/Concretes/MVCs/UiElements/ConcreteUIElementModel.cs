using System;
public abstract class ConcreteUIElementModel
{
    protected int amount;
    ConcreteUIElementController controller;
    public ConcreteUIElementModel(ConcreteUIElementController _controller,int initial_amount)
    {
        Init(_controller,initial_amount);
    }

    protected void Init(ConcreteUIElementController _controller,int initial_amount)
    {
        if (initial_amount <= 0)
            throw new ArgumentOutOfRangeException("initial_amount");
        if (_controller == null)
            throw new ArgumentNullException("controller");
        amount = initial_amount;
        controller = _controller;

    }
    public int Get()
    {
        return amount;
    }

    public virtual void Inc(int a=1)
    {
        amount+=a;
    }

    public virtual void Dec(int damage = 1)
    {
        controller.Dec(amount, damage);
        if (amount >= 0) amount -= damage;
    }

    ~ConcreteUIElementModel()
    {
        controller = null;
    }
}
