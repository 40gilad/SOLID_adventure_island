using UnityEngine;

public class Cards_FriendsAnimalsManaeger : MonoBehaviour
{
    public void SetAnimal(string color)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject curr = PoolManager.Instance.GetObjectFromPool("AnimalDummy");
        curr.transform.SetParent(player.transform, false);
        curr.transform.localPosition = new Vector3(0.2f, -0.7f,1f);
    }
}