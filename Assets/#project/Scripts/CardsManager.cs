using System.Collections.Generic;
using UnityEngine;

public class CardsManager : MonoBehaviour
{
    List<CardBehavior> deck;
    Color[] colors;

    public void Initialize(List<CardBehavior> deck, Color[] colors)
    {
        this.colors = colors;
        this.deck = deck;

        int colorIndex;
        for (int index = 0; index < deck.Count; index++)
        {
            colorIndex = Random.Range(0, colors.Length);
            deck[index].Initialize(colors[colorIndex], colorIndex, this);
        }
    }
}
