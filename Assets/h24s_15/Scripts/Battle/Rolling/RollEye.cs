using Cysharp.Threading.Tasks;
using h24s_15.Utils;
using UnityEngine;

namespace h24s_15.Battle.Rolling {
    public enum RollEye {
        One = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6
    }

    public static class RollEyeExtension {
        private static Sprite _oneSprite;
        private static Sprite _twoSprite;
        private static Sprite _threeSprite;
        private static Sprite _fourSprite;
        private static Sprite _fiveSprite;
        private static Sprite _sixSprite;

        private static Sprite _oneHistorySprite;
        private static Sprite _twoHistorySprite;
        private static Sprite _threeHistorySprite;
        private static Sprite _fourHistorySprite;
        private static Sprite _fiveHistorySprite;
        private static Sprite _sixHistorySprite;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
        private static void LoadSprites() {
            ResourcesUtility.LoadObjectAndAction<Sprite>("Sprites/Dices/dice 1", obj => _oneSprite = obj).Forget();
            ResourcesUtility.LoadObjectAndAction<Sprite>("Sprites/Dices/dice 2", obj => _twoSprite = obj).Forget();
            ResourcesUtility.LoadObjectAndAction<Sprite>("Sprites/Dices/dice 3", obj => _threeSprite = obj)
                .Forget();
            ResourcesUtility.LoadObjectAndAction<Sprite>("Sprites/Dices/dice 4", obj => _fourSprite = obj).Forget();
            ResourcesUtility.LoadObjectAndAction<Sprite>("Sprites/Dices/dice 5", obj => _fiveSprite = obj).Forget();
            ResourcesUtility.LoadObjectAndAction<Sprite>("Sprites/Dices/dice 6", obj => _sixSprite = obj).Forget();

            ResourcesUtility.LoadObjectAndAction<Sprite>("Sprites/Dices/dicedisplay16",
                obj => _oneHistorySprite = obj).Forget();
            ResourcesUtility.LoadObjectAndAction<Sprite>("Sprites/Dices/dicedisplay16-1",
                obj => _twoHistorySprite = obj).Forget();
            ResourcesUtility.LoadObjectAndAction<Sprite>("Sprites/Dices/dicedisplay16-2",
                obj => _threeHistorySprite = obj).Forget();
            ResourcesUtility.LoadObjectAndAction<Sprite>("Sprites/Dices/dicedisplay16-3",
                obj => _fourHistorySprite = obj).Forget();
            ResourcesUtility.LoadObjectAndAction<Sprite>("Sprites/Dices/dicedisplay16-4",
                obj => _fiveHistorySprite = obj).Forget();
            ResourcesUtility.LoadObjectAndAction<Sprite>("Sprites/Dices/dicedisplay16-5",
                obj => _sixHistorySprite = obj).Forget();
        }

        public static Sprite ToNormalSprite(this RollEye eye) {
            var sprite = eye switch {
                RollEye.One => _oneSprite,
                RollEye.Two => _twoSprite,
                RollEye.Three => _threeSprite,
                RollEye.Four => _fourSprite,
                RollEye.Five => _fiveSprite,
                RollEye.Six => _sixSprite,
                _ => null
            };

            if (sprite == null) {
                Debug.LogError($"Failed to get sprite for {eye}");
            }

            return sprite;
        }

        public static Sprite ToHistorySprite(this RollEye eye) {
            var sprite = eye switch {
                RollEye.One => _oneHistorySprite,
                RollEye.Two => _twoHistorySprite,
                RollEye.Three => _threeHistorySprite,
                RollEye.Four => _fourHistorySprite,
                RollEye.Five => _fiveHistorySprite,
                RollEye.Six => _sixHistorySprite,
                _ => null
            };

            if (sprite == null) {
                Debug.LogError($"Failed to get sprite for {eye}");
            }

            return sprite;
        }

        public static string ToText(this RollEye eye) {
            return eye switch {
                RollEye.One => "1",
                RollEye.Two => "2",
                RollEye.Three => "3",
                RollEye.Four => "4",
                RollEye.Five => "5",
                RollEye.Six => "6",
                _ => null
            };
        }

        public static string ToFullText(this RollEye eye) {
            return eye switch {
                RollEye.One => "１",
                RollEye.Two => "２",
                RollEye.Three => "３",
                RollEye.Four => "４",
                RollEye.Five => "５",
                RollEye.Six => "６",
                _ => null
            };
        }
    }
}
