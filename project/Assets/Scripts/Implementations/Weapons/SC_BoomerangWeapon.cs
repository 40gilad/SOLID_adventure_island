public class SC_BoomerangWeapon : ConcreteWeaponController
{
    protected override void Init()
    {
        base.Init();
        model = new SC_BoomerangWeaponModel();
    }
}
