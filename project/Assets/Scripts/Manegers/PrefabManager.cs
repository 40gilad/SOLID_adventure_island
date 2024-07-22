using UnityEngine;

public class PrefabManager : MonoBehaviour
{
    #region Collectibles

        #region Fruits
            public GameObject ColPineapplePrefab;
            public GameObject ColGrapePrefab;
        #endregion

        #region Weapons

            public GameObject ColBoomerangPrefab;
            public GameObject ColHammerPrefab;

    #endregion

    #endregion

    #region Weapons

    public GameObject BoomerangWeaponPrefab;
    public GameObject HammergWeaponPrefab;

    #endregion

    #region Enemies
    GameObject RockEnemyPrefab;
    #endregion

    private void Awake()
    {
        PoolManager.Instance.CreatePool(BoomerangWeaponPrefab, 5);
        PoolManager.Instance.CreatePool(HammergWeaponPrefab, 5);
    }
}
