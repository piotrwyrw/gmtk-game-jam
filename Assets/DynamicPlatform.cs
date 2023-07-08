using UnityEngine;

public class DynamicPlatform : Platform {

    private Vector2 _velocity;
    
    public DynamicPlatform(float width, float height, float x, float y) : base(width, height, x, y) { }
    public DynamicPlatform(Vector2 dimensions, Vector2 location) : base(dimensions, location) { }
    
    public override void Update() {
        Location += _velocity;
    }
}