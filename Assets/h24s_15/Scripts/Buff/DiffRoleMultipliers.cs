using System;
using h24s_15.Battle.Rolling;

namespace h24s_15.Buff {
    [Serializable]
    public struct DiffRoleMultipliers {
        public int DiffNoPairMultiplier;
        public int DiffOnePairMultiplier;
        public int DiffTwoPairMultiplier;
        public int DiffThreeDiceMultiplier;
        public int DiffFullHouseMultiplier;
        public int DiffSStraightMultiplier;
        public int DiffBStraightMultiplier;
        public int DiffFourDiceMultiplier;
        public int DiffFiveDiceMultiplier;

        public int GetDiffRoleMultiplier(Role role) {
            return role switch {
                Role.NoPair => DiffNoPairMultiplier,
                Role.OnePair => DiffOnePairMultiplier,
                Role.TwoPair => DiffTwoPairMultiplier,
                Role.ThreeDice => DiffThreeDiceMultiplier,
                Role.FullHouse => DiffFullHouseMultiplier,
                Role.SStraight => DiffSStraightMultiplier,
                Role.BStraight => DiffBStraightMultiplier,
                Role.FourDice => DiffFourDiceMultiplier,
                Role.FiveDice => DiffFiveDiceMultiplier,
                _ => throw new ArgumentOutOfRangeException(nameof(role), role, null)
            };
        }
    }
}
