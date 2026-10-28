using UnityEngine;

public class BGScroller : MonoBehaviour
{
    [SerializeField] Vector2 moveSpeed;
    Vector2 offset;
    Material mat;

    void Start()
    {
        mat = GetComponent<SpriteRenderer>().material;


    }

    void Update()
    {
        Scroll();
    }

    void Scroll()
    {
        offset += moveSpeed * Time.deltaTime;
        mat.mainTextureOffset = offset;
    }
}
