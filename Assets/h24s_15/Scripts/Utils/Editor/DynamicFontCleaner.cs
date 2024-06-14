using TMPro;
using UnityEditor;
using UnityEngine;

namespace h24s_15.Utils.Editor {
    [InitializeOnLoad]
    public static class DynamicFontCleaner {
        static DynamicFontCleaner() {
            EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
        }

        private static void OnPlayModeStateChanged(PlayModeStateChange state) {
            if (state == PlayModeStateChange.ExitingPlayMode) {
                var tmpFontAssets = Resources.FindObjectsOfTypeAll<TMPro.TMP_FontAsset>();
                foreach (var tmpFontAsset in tmpFontAssets) {
                    if (tmpFontAsset != null && tmpFontAsset.atlasPopulationMode == AtlasPopulationMode.Dynamic) {
                        tmpFontAsset.ClearFontAssetData();
                        Debug.Log("DynamicFontCleaner: ClearFontAssetData " + tmpFontAsset.name);
                    }
                }
            }
        }
    }
}
