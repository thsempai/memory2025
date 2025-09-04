using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class CardBehavior : MonoBehaviour
{

    [SerializeField] private Vector3 scaleOnFocus = Vector3.one * 1.5f;
    private Vector3 memoScale;

    private Color color;
    private int indexColor;

    private CardsManager manager;

    private void OnMouseEnter()
    {
        memoScale = transform.localScale;
        transform.localScale = scaleOnFocus;
    }

    private void OnMouseExit()
    {
        transform.localScale = memoScale;
    }

    public void Initialize(Color color, int indexColor, CardsManager manager)
    {
        this.color = color;
        this.indexColor = indexColor;
        this.manager = manager;

        // temporary: It will be deleted when we will have finish the initialization.
        ChangeColor(color);
    }
    public void ChangeColor(Color color)
    {
        GetComponent<Renderer>().material.color = color;
    }

}
