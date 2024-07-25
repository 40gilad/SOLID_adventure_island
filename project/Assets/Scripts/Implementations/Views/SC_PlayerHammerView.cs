
using TMPro;

public class SC_PlayerHammerView : ConcreteUIElementView
{
    public SC_PlayerHammerView(TextMeshProUGUI txt) : base(txt) { }

    public override void UIDec(int amount, int damage)
    {
        UIUpdate(amount);
    }

    public override void UIUpdate(int amount)
    {
        text_element.text = amount.ToString();
    }
}
