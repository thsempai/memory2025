using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class CardBehavior : MonoBehaviour
{

    [SerializeField] private Vector3 scaleOnFocus = Vector3.one * 1.5f;
    [SerializeField] private float changeColorTime = 1f;
    private Vector3 memoScale;

    private Color color;
    [SerializeField] private Color baseColor = Color.gray;
    public int IndexColor { get; private set; }

    public bool IsFaceUp { get; private set; } = false;

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

    private void OnMouseDown()
    {
        manager.CardIsClicked(this);
    }

    public void Initialize(Color color, int indexColor, CardsManager manager)
    {
        this.color = color;
        IndexColor = indexColor;
        this.manager = manager;

        ChangeColor(baseColor);
        IsFaceUp = false;

    }

    private void ChangeColor(Color color)
    {
        GetComponent<Renderer>().material.color = color;
    }

    public void FaceUp()
    {
        StartCoroutine(ChangeColorWithLerp(color));
        IsFaceUp = true;
    }

    public void FaceDown(float delay = 0f)
    {
        StartCoroutine(ChangeColorWithLerp(baseColor, delay));
        IsFaceUp = false;
    }

    private IEnumerator ChangeColorWithLerp(Color color, float delay = 0f)
    {
        yield return new WaitForSeconds(delay);

        float chrono = 0f;
        Color startColor = GetComponent<Renderer>().material.color;

        while (chrono < changeColorTime)
        {
            chrono += Time.deltaTime;
            Color c = Color.Lerp(startColor, color, chrono / changeColorTime);
            ChangeColor(c);
            yield return new WaitForEndOfFrame(); // => yield return null;
        }
        ChangeColor(color);
    }

}
