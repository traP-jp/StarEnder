using System;
using UnityEngine;

namespace h24s_15.Battle.Rolling {
    [Serializable]
    public struct RoleMultipliers {
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

        [SerializeField] private int _noPairMultiplier;
        [SerializeField] private int _onePairMultiplier;
        [SerializeField] private int _twoPairMultiplier;
        [SerializeField] private int _threeDiceMultiplier;
        [SerializeField] private int _fullHouseMultiplier;
        [SerializeField] private int _sStraightMultiplier;
        [SerializeField] private int _bStraightMultiplier;
        [SerializeField] private int _fourDiceMultiplier;
        [SerializeField] private int _fiveDiceMultiplier;

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
