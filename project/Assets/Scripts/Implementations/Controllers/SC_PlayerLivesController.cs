using TMPro;

public class SC_PlayerLivesController : ConcreteUIElementController
{

    protected override void Init()
    {
        model = new SC_PlayerLivesModel(this,initial_amout);
        view = new SC_PlayerLivesView(GetComponent<TextMeshProUGUI>());
        view.UIUpdate(model.Get());
    }
}
