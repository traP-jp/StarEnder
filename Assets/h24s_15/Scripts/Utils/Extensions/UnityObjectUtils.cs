using System.Linq;
using UnityEngine;

namespace h24s_15.Utils.Extensions {
    public static class UnityObjectUtils {
        public static T[] FindObjectsByInterface<T>() where T : class {
            return Object.FindObjectsByType<Component>(FindObjectsSortMode.None).OfType<T>().ToArray();
        }

        public static T FindObjectByInterface<T>() where T : class {
            return Object.FindObjectsByType<Component>(FindObjectsSortMode.None).OfType<T>().FirstOrDefault();
        }
    }
}
