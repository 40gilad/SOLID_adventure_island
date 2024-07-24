using System.Drawing;
using UnityEngine;

public class FairyFriendAnimal : FriendAnimal
{
    GameObject player;
    private string color = "Fairy";
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player_weapon_manager = player.GetComponent<SC_PlayerWeaponsManager>();
        transform.SetParent(GameObject.FindGameObjectWithTag("Player").transform);
        transform.localPosition = new Vector3(-1.5f, 1f, 0f);
        player_weapon_manager.SetFriendAnimalColor(color);

    }

    private void OnDisable()
    {
        player_weapon_manager.SetFriendAnimalColor(string.Empty);

    }
    protected override bool CanBeCollected()
    {
        Debug.Log("FairyFriendAnimal CanBeCollected? retuens true");
        return true;
    }

    public override void Attack()
    {
        Debug.Log("Fairy Animal attacks with turn");
    }

    protected override void CombineWithPlayer()
    {
        Debug.Log("Player is now riding Fairy Animal");
    }
}
