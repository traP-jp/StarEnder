using Cysharp.Threading.Tasks;
using h24s_15.Utils;
using UnityEngine;

namespace h24s_15.Battle.Rolling {
    public enum Role {
        NoPair = 0,
        OnePair,
        TwoPair,
        ThreeDice,
        FullHouse,
        SStraight,
        BStraight,
        FourDice,
        FiveDice,
        Count // 役の数
    }

    public static class RoleExtension {
        private static Sprite _noPairSprite;
        private static Sprite _onePairSprite;
        private static Sprite _twoPairSprite;
        private static Sprite _threeDiceSprite;
        private static Sprite _fullHouseSprite;
        private static Sprite _sStraightSprite;
        private static Sprite _bStraightSprite;
        private static Sprite _fourDiceSprite;
        private static Sprite _fiveDiceSprite;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void LoadSprites() {
            ResourcesUtility.LoadObjectAndAction<Sprite>("Sprites/Roles/yakuicons_nopair", obj => _noPairSprite = obj)
                .Forget();
            ResourcesUtility.LoadObjectAndAction<Sprite>("Sprites/Roles/yakuicon_1pair", obj => _onePairSprite = obj)
                .Forget();
            ResourcesUtility.LoadObjectAndAction<Sprite>("Sprites/Roles/yakuicon_2pair", obj => _twoPairSprite = obj)
                .Forget();
            ResourcesUtility.LoadObjectAndAction<Sprite>("Sprites/Roles/yakuicon_3pair", obj => _threeDiceSprite = obj)
                .Forget();
            ResourcesUtility
                .LoadObjectAndAction<Sprite>("Sprites/Roles/yakuicon_fullhouse", obj => _fullHouseSprite = obj)
                .Forget();
            ResourcesUtility
                .LoadObjectAndAction<Sprite>("Sprites/Roles/yakuicons_vstraight", obj => _sStraightSprite = obj)
                .Forget();
            ResourcesUtility
                .LoadObjectAndAction<Sprite>("Sprites/Roles/yakuicon_bstraight", obj => _bStraightSprite = obj)
                .Forget();
            ResourcesUtility.LoadObjectAndAction<Sprite>("Sprites/Roles/yakuicon_4pair", obj => _fourDiceSprite = obj)
                .Forget();
            ResourcesUtility.LoadObjectAndAction<Sprite>("Sprites/Roles/yakuicon_yotto", obj => _fiveDiceSprite = obj)
                .Forget();
        }

        public static Sprite ToSprite(this Role role) {
            return role switch {
                Role.NoPair => _noPairSprite,
                Role.OnePair => _onePairSprite,
                Role.TwoPair => _twoPairSprite,
                Role.ThreeDice => _threeDiceSprite,
                Role.FullHouse => _fullHouseSprite,
                Role.SStraight => _sStraightSprite,
                Role.BStraight => _bStraightSprite,
                Role.FourDice => _fourDiceSprite,
                Role.FiveDice => _fiveDiceSprite,
                _ => throw new System.ArgumentOutOfRangeException(nameof(role), role, null)
            };
        }

        public static bool IsMultipleEyeNecessary(this Role role) {
            return role switch {
                Role.SStraight => true,
                Role.BStraight => true,
                _ => false
            };
        }

        public static string ToJapaneseText(this Role role) {
            return role switch {
                Role.NoPair => "ノーペア",
                Role.OnePair => "ワンペア",
                Role.TwoPair => "ツーペア",
                Role.ThreeDice => "スリーカード",
                Role.FullHouse => "フルハウス",
                Role.SStraight => "スモールストレート",
                Role.BStraight => "ビッグストレート",
                Role.FourDice => "フォーカード",
                Role.FiveDice => "ファイブカード",
                _ => throw new System.ArgumentOutOfRangeException(nameof(role), role, null)
            };
        }
    }
}
