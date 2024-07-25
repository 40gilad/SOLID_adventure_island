using TMPro;

public class SC_PlayerHammerController : ConcreteUIElementController
{
    protected override void Init()
    {
        model = new SC_PlayerHammerModel(this, initial_amout);
        view = new SC_PlayerHammerView(GetComponent<TextMeshProUGUI>());
        view.UIUpdate(model.Get());
    }
}
