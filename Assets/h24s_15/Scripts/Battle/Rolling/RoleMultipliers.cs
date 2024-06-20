using System;
using UnityEngine;

namespace h24s_15.Battle.Rolling {
    [Serializable]
    public struct RoleMultipliers {
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
            return role switch {
                Role.NoPair => _noPairMultiplier,
                Role.OnePair => _onePairMultiplier,
                Role.TwoPair => _twoPairMultiplier,
                Role.ThreeDice => _threeDiceMultiplier,
                Role.FullHouse => _fullHouseMultiplier,
                Role.SStraight => _sStraightMultiplier,
                Role.BStraight => _bStraightMultiplier,
                Role.FourDice => _fourDiceMultiplier,
                Role.FiveDice => _fiveDiceMultiplier,
                _ => throw new ArgumentOutOfRangeException(nameof(role), role, null)
            };
        }
    }
}
