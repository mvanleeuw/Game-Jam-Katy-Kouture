using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WearClothing : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject clothingPrefab;
    public Transform snapPoint;

    public void PlaceClothing()
    {

        foreach (Transform child in snapPoint)
        {
            Destroy(child.gameObject);
        }

        GameObject newClothing = Instantiate(clothingPrefab, snapPoint.position, Quaternion.identity, snapPoint);

        RectTransform newClothingRect = newClothing.GetComponent<RectTransform>();
        RectTransform snapRect = snapPoint.GetComponent<RectTransform>();

        newClothingRect.localScale = Vector3.one;
        newClothingRect.anchoredPosition = Vector2.zero;
        newClothingRect.sizeDelta = snapRect.sizeDelta;
        
    }
}
