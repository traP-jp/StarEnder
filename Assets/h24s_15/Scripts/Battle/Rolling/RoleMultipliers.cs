using System;

namespace h24s_15.Battle.Rolling {
    public readonly struct RoleMultipliers {
        public static RoleMultipliers Default => new(
            1,
            2,
            3,
            5,
            7,
            9,
            13,
            17,
            25);

        private readonly int _noPairMultiplier;
        private readonly int _onePairMultiplier;
        private readonly int _twoPairMultiplier;
        private readonly int _threeDiceMultiplier;
        private readonly int _fullHouseMultiplier;
        private readonly int _sStraightMultiplier;
        private readonly int _bStraightMultiplier;
        private readonly int _fourDiceMultiplier;
        private readonly int _fiveDiceMultiplier;

        public RoleMultipliers(int noPairMultiplier, int onePairMultiplier, int twoPairMultiplier,
            int threeDiceMultiplier, int fullHouseMultiplier, int sStraightMultiplier, int bStraightMultiplier,
            int fourDiceMultiplier, int fiveDiceMultiplier) {
            _noPairMultiplier = noPairMultiplier;
            _onePairMultiplier = onePairMultiplier;
            _twoPairMultiplier = twoPairMultiplier;
            _threeDiceMultiplier = threeDiceMultiplier;
            _fullHouseMultiplier = fullHouseMultiplier;
            _sStraightMultiplier = sStraightMultiplier;
            _bStraightMultiplier = bStraightMultiplier;
            _fourDiceMultiplier = fourDiceMultiplier;
            _fiveDiceMultiplier = fiveDiceMultiplier;
        }

        public int GetMultiplier(Role role) {
            switch (role) {
                case Role.NoPair:
                    return _noPairMultiplier;
                case Role.OnePair:
                    return _onePairMultiplier;
                case Role.TwoPair:
                    return _twoPairMultiplier;
                case Role.ThreeDice:
                    return _threeDiceMultiplier;
                case Role.FullHouse:
                    return _fullHouseMultiplier;
                case Role.SStraight:
                    return _sStraightMultiplier;
                case Role.BStraight:
                    return _bStraightMultiplier;
                case Role.FourDice:
                    return _fourDiceMultiplier;
                case Role.FiveDice:
                    return _fiveDiceMultiplier;
                default:
                    throw new ArgumentOutOfRangeException(nameof(role), role, null);
            }
        }
    }
}
