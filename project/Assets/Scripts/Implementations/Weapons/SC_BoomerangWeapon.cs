public class SC_BoomerangWeapon : ConcreteWeaponController
{
    protected override void Init()
    {
        model = new SC_BoomerangWeaponModel();
        base.Init();
    }
}
