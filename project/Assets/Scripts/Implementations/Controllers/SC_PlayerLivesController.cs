using TMPro;

public class SC_PlayerLivesController : ConcreteUIElementController
{

    protected override void Init()
    {
        model = new SC_PlayerLivesModel(this,initial_amout);
        view = new SC_PlayerLivesView(GetComponent<TextMeshProUGUI>());
        view.UIUpdate(model.Get());
    }

    private void OnEnable()
    {
        SC_PlayerPowerController.OutOfPower += HandleOutOfPower;
        Concrete_ColFruit.FruitsBonus += HandleFruitBunos;
    }

    private void OnDisable()
    {
        SC_PlayerPowerController.OutOfPower += HandleOutOfPower;
        Concrete_ColFruit.FruitsBonus -= HandleFruitBunos;
    }
    private void HandleFruitBunos()
    {
        model.Inc();
        view.UIUpdate(model.Get());
    }

    private void HandleOutOfPower()
    {
        model.Dec();
        view.UIUpdate(model.Get());
    }
}
