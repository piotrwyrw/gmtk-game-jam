using Unity.VisualScripting;
using UnityEngine;

namespace Utility {
    public static class Util {
        public static T AddIfNotPresent<T>(this Component c) where T : Component {
            T component = c.GetComponent<T>();
            if (component == null)
                return c.AddComponent<T>();
            return component;
        }
    }
}