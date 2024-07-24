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
    public GameObject FireBallWeaponPrefab;

    #endregion

    #region Enemies
    public GameObject RockEnemyPrefab;
    public GameObject SnakeEnemyPrefab;
    public GameObject FrogEnemyPrefab;
    public GameObject SpiderEnemyPrefab;
    public GameObject BirdEnemyPrefab;
    #endregion

    #region FriendsAnimals
    public GameObject RedFriendAnimalprefab;
    public GameObject BlueFriendAnimalprefab;
    public GameObject GreenFriendAnimalprefab;
    #endregion

    #region Cards
    public GameObject LeafCardPrefab;
    public GameObject StarCardPrefab;
    public GameObject HeartCardPrefab;

    #endregion
    private void Awake()
    {
        PoolManager.Instance.CreatePool(BoomerangWeaponPrefab, 5);
        PoolManager.Instance.CreatePool(HammergWeaponPrefab, 5);
        PoolManager.Instance.CreatePool(FireBallWeaponPrefab, 5);
        PoolManager.Instance.CreatePool(FireBallWeaponPrefab, 5);
        PoolManager.Instance.CreatePool(RedFriendAnimalprefab, 1);
        PoolManager.Instance.CreatePool(BlueFriendAnimalprefab, 1);
        PoolManager.Instance.CreatePool(GreenFriendAnimalprefab, 1);
    }
}
