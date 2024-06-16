using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Object = UnityEngine.Object;

namespace h24s_15.Utils {
    public static class ResourcesUtility {
        public static async UniTask LoadObjectAndAction<T>(string path, Action<T> action) where T : Object {
            var asset = await Resources.LoadAsync<T>(path);
            if (asset != null) {
                action(asset as T);
            }
            else {
                Debug.LogError($"Failed to load {path}");
            }
        }
    }
}
