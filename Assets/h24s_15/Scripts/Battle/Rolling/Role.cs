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
