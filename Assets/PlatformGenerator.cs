using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using Random = UnityEngine.Random;

public class PlatformGenerator {
    private float _lastX;
    private float _lastY;

    // ---- Generator Settings ----
    private float _minXDelta; // Minimum spacing between platforms
    private float _deltaXFluctuations; // Randomness to _minXDelta

    private float _maxXMovement; // Maximum amount a platform can move around in the X axis
    private float _minXMovement; // Min. movement

    private float _maxYMovement; // Maximum amount a platform can move around in the Y axis
    private float _minYMovement; // Min. movement

    private List<GameObject> _platforms;

    public PlatformGenerator(float orgX, float orgY) {
        _lastX = orgX;
        _lastY = orgY;
    }

    public void GenerateNext() {
        float startX = _lastX + _minXDelta + Util.Random(0.0f, _deltaXFluctuations);
        float startY = _lastY;

        // Is the platform stationary?
        bool stat = Util.Random();

        float endX, endY;

        if (stat) {
            endX = startX;
            endY = startY;
        } else {
            endX = startX + Util.Random(_minXMovement, _maxXMovement);
            endY = startY + Util.Random(_minYMovement, _maxYMovement);
        }

        GameObject obj = Resources.Load("Player", typeof(GameObject)) as GameObject;
        GameObject platform = GameObject.Instantiate(obj);
        DynamicObject dynObj = platform.GetComponent<DynamicObject>();
        dynObj.startXPos = startX;
        dynObj.startYPos = startY;

    }
}