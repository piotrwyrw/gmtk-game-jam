using System.Collections.Generic;
using Extensions;
using UnityEngine;

public class PlatformGenerator {
    private float _lastX;
    private float _lastY;

    // ---- Initial setup ----
    private const float clearance = 0.5f;

    // ---- Generator Settings ----
    private const float overlapFlux = -0.5f;

    private float minVerticalDelta = 0.0f;
    private float verticalDeltaFlux = 1.0f;

    private GameObject prefab;
    private  GameObject player;

    public PlatformGenerator(float orgX, float orgY) {
        _lastX = orgX;
        _lastY = orgY;
        LoadPrefab();
    }

    public PlatformGenerator() {
        LoadPrefab();
        _lastX = player.transform.position.x + prefab.transform.localScale.y - 0.5f;
        _lastY = player.transform.position.y + prefab.transform.localScale.y - 0.5f;
    }

    private void LoadPrefab() {
        GameObject obj = Resources.Load("Platform") as GameObject;
        prefab = obj;
        player = GameObject.Find("Player");
        minVerticalDelta = player.transform.localScale.y;
    }

    private float RandomVerticalDelta() {
        return Util.Random(minVerticalDelta, minVerticalDelta + verticalDeltaFlux);
    }

    private float MaxSpacing() {
        return prefab.transform.localScale.x;
    }

    private GameObject Platform(float x, float y) {
        GameObject p1 = GameObject.Instantiate(prefab);
        p1.transform.position = new Vector3(x, y, 0.0f);
        DynamicObject dynObj = p1.GetComponent<DynamicObject>();
        dynObj.AddIfNotPresent<BoxCollider2D>();
        dynObj.frozen = true;
        return p1;
    }

    private KeyValuePair<GameObject, GameObject> OuterPlatforms() {
        GameObject p1 = Platform(_lastX, _lastY);
        GameObject p2 = Platform(_lastX + MaxSpacing() + prefab.transform.localScale.x, _lastY);
        _lastX += p2.transform.position.x + p2.transform.localScale.x;
        return new KeyValuePair<GameObject, GameObject>(p1, p2);
    }

    private GameObject MiddlePlatform(KeyValuePair<GameObject, GameObject> outer) {
        float k1 = outer.Key.transform.position.x;
        float k2 = outer.Value.transform.position.x + outer.Value.transform.localScale.x;
        float x = ((k1 + k2) / 2.0f) - (outer.Value.transform.localScale.x / 2.0f);
        float y = outer.Key.transform.position.y + minVerticalDelta + prefab.transform.localScale.y + Util.Random(0.0f, verticalDeltaFlux);
        return Platform(x, y);
    }

    public void GenerateNext() {
        MiddlePlatform(OuterPlatforms());
    }
    
}