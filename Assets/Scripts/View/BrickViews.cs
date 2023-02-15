using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickViews : Part
{
    [SerializeField] private GameObject brickViewPrefab;
    [SerializeField] private Sprite defaultSprite;
    [SerializeField] private Sprite dirtSprite;
    [SerializeField] private Sprite stoneSprite;
    [SerializeField] private Sprite stoneBrokenSprite;
    [SerializeField] private Sprite leafSprite;
    [SerializeField] private Sprite redBrickSprite;
    [SerializeField] private Sprite stoneBrickSprite;
    [SerializeField] private Sprite stoneBrickBrokenSprite;

    public void Start()
    {
        foreach (Brick brick in root.model.brickContainer.getAllBricks())
        {
            Sprite brokenSprite;
            Sprite sprite = getSprite(brick.type, out brokenSprite);

            GameObject obj = Instantiate(brickViewPrefab, brick.transform.position, brick.transform.rotation);
            BrickView brickView = obj.GetComponent<BrickView>();
            // initialization of brickview must be in the same frame as instatniating the object 
            // otherwise it would destroy itself due to lack of its model
            brickView.initialize(sprite, brokenSprite, brick);

            obj.transform.parent = transform;
        }
    }

    private Sprite getSprite(Brick.BrickType type, out Sprite brokenSprite)
    {
        switch (type)
        {
            case Brick.BrickType.DIRT:
                brokenSprite = defaultSprite;
                return dirtSprite;

            case Brick.BrickType.STONE:
                brokenSprite = stoneBrokenSprite;
                return stoneSprite;

            case Brick.BrickType.LEAF:
                brokenSprite = defaultSprite;
                return leafSprite;

            case Brick.BrickType.RED_BRICK:
                brokenSprite = defaultSprite;
                return redBrickSprite;

            case Brick.BrickType.STONE_BRICK:
                brokenSprite = stoneBrickBrokenSprite;
                return stoneBrickSprite;

            default:
                brokenSprite = defaultSprite;
                return defaultSprite;
        }
    }
}
