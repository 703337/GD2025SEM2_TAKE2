using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    List<GameObject> Cards = new List<GameObject>(); 

    public void AddCardToList(GameObject Card)
    {
        Cards.Add(Card);
    }

    public void DestroyAllCards()
    {
        for (int i = Cards.Count - 1; i >= 0; i--)
        {
            Destroy(Cards[i]);
        }
        Cards.Clear();
    }
}
