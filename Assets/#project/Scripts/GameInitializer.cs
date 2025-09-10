using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    const float CARD_SIZE = 1.0f;

    [Header("Cards")]
    [Space]
    [SerializeField] private int rows = 2;
    [SerializeField] private int columns = 3;
    [SerializeField] private float gap = 0.5f;
    [SerializeField] private CardBehavior cardPrefab;

    private List<CardBehavior> deck = new();
    [SerializeField] private Color[] colors;

    [SerializeField] private CardsManager cardsManager;

    [Header("Victory")]
    [Space]
    [SerializeField] private VictoryManager victoryManager;
    [SerializeField] private string victoryScene;


    private void Start()
    {
        if ((rows * columns) % 2 != 0)
        {
            Debug.LogError("The cards number need to be even.");
            return;
        }

        if (colors.Length < (rows * columns / 2))
        {
            Debug.LogError("There is not enough colors to fill all the cards.");
            return;
        }

        ObjectsCreation();
        ObjectsInitialization();
    }

    private void ObjectsCreation()
    {
        Vector3 position;
        for (float x = 0f; x < columns * (CARD_SIZE + gap); x += CARD_SIZE + gap)
        {
            for (float z = 0f; z < rows * (CARD_SIZE + gap); z += CARD_SIZE + gap)
            {
                position = transform.position + Vector3.right * x + Vector3.forward * z;

                deck.Add(Instantiate(cardPrefab, position, Quaternion.identity));
            }

        }

        cardsManager = Instantiate(cardsManager);
        victoryManager = Instantiate(victoryManager);

    }

    private void ObjectsInitialization()
    {
        cardsManager.Initialize(deck, colors, victoryManager);
        victoryManager.Initialize(victoryScene);

    }
}
