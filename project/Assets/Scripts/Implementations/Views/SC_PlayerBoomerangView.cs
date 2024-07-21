using TMPro;

public class SC_PlayerBoomerangView : ConcreteUIElementView
{
    public SC_PlayerBoomerangView(TextMeshProUGUI txt) : base(txt) { }

    public override void UIUpdate(int amount)
    {
        text_element.text = amount.ToString();
    }
}
