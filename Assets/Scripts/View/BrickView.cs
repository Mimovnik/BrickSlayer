using UnityEngine;

public class BrickView : Part
{
    private Sprite brokenSprite;
    public SpriteRenderer spriteRenderer;
    public Brick model;
    private Sprite sprite;

    public void initialize(Sprite sprite, Sprite brokenSprite, Brick model)
    {
        this.sprite = sprite;
        this.brokenSprite = brokenSprite;
        this.model = model;

        spriteRenderer.sprite = sprite;
    }

    public new void Awake()
    {
        base.Awake();

        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void Update()
    {
        if (model == null)
        {
            Destroy(gameObject);
            return;
        }

        transform.position = model.transform.position;
        if (model.maxDurability > 1 && model.durability < model.maxDurability)
        {
            spriteRenderer.sprite = brokenSprite;
        }
    }
}
