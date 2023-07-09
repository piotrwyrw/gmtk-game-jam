using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator {
    private float orgY;
    private float _lastX;

    // ---- Generator Settings ----
    private const float overlapFlux = 2.0f;

    private float minVerticalDelta = 4.0f;
    private float verticalDeltaFlux = 5.0f;
    
    private const int _minPlatformCount = 10;
    private float deathZoneYMax = 100.0f;
    private float deathZoneYMin = 0.0f;

    private int count = 0;

    private GameObject _prefab;
    private GameObject _deathBlock;
    private GameObject _background;
    private GameObject _player;
    private PhysicsMaterial2D _material2D;

    private List<KeyValuePair<GameObject, DynamicObject>> _platforms;

    private enum PlatformPosition {
        UPPER,
        LOWER
    };

    private PlatformPosition _lastPosition = PlatformPosition.UPPER;

    public PlatformGenerator(float orgX, float orgY) {
        _lastX = orgX;
        this.orgY = orgY;
        LoadPrefab();
    }

    public PlatformGenerator() {
        LoadPrefab();
        _lastX = _player.transform.position.x + _prefab.transform.localScale.x - _player.transform.localScale.x;
        orgY = _player.transform.position.y + _prefab.transform.localScale.y - 0.5f;
    }

    private void LoadPrefab() {
        _platforms = new List<KeyValuePair<GameObject, DynamicObject>>();
        GameObject obj = Resources.Load("Platform") as GameObject;
        _prefab = obj;
        _player = GameObject.Find("Player");
        _material2D = Resources.Load("Frictionless") as PhysicsMaterial2D;
        minVerticalDelta = _player.transform.localScale.y;
        _deathBlock = Resources.Load("Deathblock") as GameObject;
        _deathBlock.transform.localScale = obj.transform.localScale;
        GameObject.Destroy(_deathBlock.GetComponent<Rigidbody2D>());

        CapsuleCollider2D collider = _player.GetComponent<CapsuleCollider2D>();
        if (collider == null) {
            Debug.LogWarning("The player object has no BoxCollider2D");
            return;
        }

        collider.sharedMaterial = _material2D;
        _background = GameObject.Instantiate(Resources.Load("Background") as GameObject);
        SpriteRenderer renderer = _background.GetComponent<SpriteRenderer>();
        renderer.sortingLayerName = "Default";
    }

    private float RandomVerticalDelta() {
        return Util.Random(minVerticalDelta, minVerticalDelta + verticalDeltaFlux);
    }

    private float MaxSpacing() {
        return _prefab.transform.localScale.x;
    }

    private GameObject Platform(float x, float y) {
        GameObject p1 = GameObject.Instantiate((count > 1)
            ? ((Util.Random() && (_platforms[^1].Key.GetComponent<IsTouchingPlayer>() == null)) ? _deathBlock : _prefab)
            : _prefab);
        p1.name = "Platform[" + x + ";" + y + "]";
        p1.transform.position = new Vector3(x, y, 0.0f);
        DynamicObject dynObj = p1.GetComponent<DynamicObject>();
        if (dynObj == null)
            dynObj = p1.AddComponent<DynamicObject>();
        dynObj.m_initialPosition = p1.transform.position;
        dynObj.frozen = true;
        _platforms.Add(new KeyValuePair<GameObject, DynamicObject>(p1, dynObj));
        count++;
        return p1;
    }

    private float NextY() {
        float y;
        if (_lastPosition == PlatformPosition.UPPER) {
            y = orgY;
            deathZoneYMin = y - _prefab.transform.localScale.y / 2.0f;
        }
        else { 
            y = _prefab.transform.localScale.y + Util.Random(minVerticalDelta, verticalDeltaFlux + minVerticalDelta);
            deathZoneYMax = y;
        }

        return y;
    }

    public void GenerateNext() {
        float x = _lastX - Util.Random(0.0f, overlapFlux);
        float y = NextY();
        _lastX = x + _prefab.transform.localScale.x;
        Platform(x, y);
        _lastPosition = (_lastPosition == PlatformPosition.UPPER) ? PlatformPosition.LOWER : PlatformPosition.UPPER;
    }

    public void AutomaticPlatformPerformanceOptimizationAndGenerationTick() {
        // Realign the background
        _background.transform.position =
            new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, 10.0f);
        float maxX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0.0f, 0.0f)).x;
        float minX = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, 0.0f)).x;
        float maxY = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, Screen.height, 0.0f)).y;
        float minY = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, 0.0f)).y;
        _background.transform.localScale = new Vector3(maxX - minX + 0.5f, maxY - minY + 0.5f, 0.0f);

        for (var index = 0; index < _platforms.Count; index++) {
            var kv = _platforms[index];
            GameObject obj = kv.Key;
            if (obj.transform.position.x + obj.transform.localScale.x / 2.0f <
                Camera.main?.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, 0.0f)).x) {
                ;
                GameObject.Destroy(obj);
                _platforms.Remove(kv);
            }
        }

        if (_platforms.Count < _minPlatformCount)
            for (int i = 0; i < _minPlatformCount - _platforms.Count; i++)
                GenerateNext();
    }

    public void CheckPlayerAndKill() {
        CharacterControllerNew ccn = _player.GetComponent<CharacterControllerNew>();
        if (_player.transform.position.y < deathZoneYMin || _player.transform.position.y > deathZoneYMax) {
            ccn.KillPlayer();
        }
    }
    
}