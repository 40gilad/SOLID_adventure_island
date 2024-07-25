using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Egg : MonoBehaviour
{
    public Sprite crackingEggSprite;
    private float hatching_intervals = 1.5f;
    private System.Random random = new System.Random();
    private void Start()
    {
        StartCoroutine(Lidgor());
    }
    private IEnumerator Lidgor()
    {
        yield return new WaitForSeconds(hatching_intervals);
        GetComponent<SpriteRenderer>().sprite = crackingEggSprite;
        yield return new WaitForSeconds(hatching_intervals);
        Hatch();
    }

    private void Hatch()
    {
        Debug.Log("Egg Hatched");
        GameObject suprise = RandomCharacter();
        suprise.transform.position = transform.position;
        suprise.SetActive(true);
        gameObject.SetActive(false);

    }

    private GameObject RandomCharacter()
    {
        string suprise_prefab = PrefabList.Instance().Get(random.Next(PrefabList.Instance().Amount()));
        return PoolManager.Instance.GetObjectFromPool(suprise_prefab);
    }
}



