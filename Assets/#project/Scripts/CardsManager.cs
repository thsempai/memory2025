
using System.Collections.Generic;
using UnityEngine;

public class CardsManager : MonoBehaviour
{
    [SerializeField] private float delayBeforeFaceDown = 1f;

    private VictoryManager victoryManager;
    private List<CardBehavior> deck;

    private Color[] colors;

    private CardBehavior memoCard = null;

    private int combinaisonsFound = 0;

    public void Initialize(List<CardBehavior> deck, Color[] colors, VictoryManager victoryManager)
    {
        this.colors = colors;
        this.deck = deck;
        this.victoryManager = victoryManager;

        int colorIndex;
        int cardIndex;

        memoCard = null;
        combinaisonsFound = 0;

        List<int> colorsAlreadyInGame = new();
        List<CardBehavior> cards = new(deck);

        for (int _ = 0; _ < deck.Count / 2; _++)
        {
            colorIndex = Random.Range(0, colors.Length);

            while (colorsAlreadyInGame.Contains(colorIndex))
            {
                colorIndex = Random.Range(0, colors.Length);
            }
            colorsAlreadyInGame.Add(colorIndex);


            for (int __ = 0; __ < 2; __++)
            {
                cardIndex = Random.Range(0, cards.Count);
                cards[cardIndex].Initialize(colors[colorIndex], colorIndex, this);
                cards.RemoveAt(cardIndex);
            }
        }
    }

    public void CardIsClicked(CardBehavior card)
    {
        if (card.IsFaceUp) return;

        card.FaceUp();

        if (memoCard != null)
        {
            if (card.IndexColor != memoCard.IndexColor)
            {
                memoCard.FaceDown(delayBeforeFaceDown);
                card.FaceDown(delayBeforeFaceDown);
            }
            else
            {
                combinaisonsFound++;

                if (combinaisonsFound == deck.Count / 2)
                {
                    victoryManager.LaunchVictory();
                }
            }

            memoCard = null;
        }
        else
        {
            memoCard = card;
        }
    }
}
