using TMPro;

public class SC_PlayerBoomerangView : ConcreteUIElementView
{
    public SC_PlayerBoomerangView(TextMeshProUGUI txt) : base(txt) { }

    public override void UIDec(int amount,int damage)
    {
        throw new System.NotImplementedException();
    }

    public override void UIUpdate(int amount)
    {
        text_element.text = amount.ToString();
    }
}
