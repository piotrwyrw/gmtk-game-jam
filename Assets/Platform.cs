using UnityEngine;

public abstract class Platform {
    protected Vector2 Dimensions { get; set; }
    protected Vector2 Location { get; set; }

    public Platform(float width, float height, float x, float y) {
        Dimensions = new Vector2(width, height);
        Location = new Vector2(x, y);
    }

    public Platform(Vector2 dimensions, Vector2 location) : this(dimensions.x, dimensions.y, location.x, location.y) { }

    public abstract void Update();
}