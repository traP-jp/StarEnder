using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace h24s_15.Battle.Rolling {
    [Serializable]
    public class DiceSet {
        public DiceSet(List<Dice> value) {
            _value = value;
        }

        public const int SET_SIZE = 5;

        [SerializeField] private List<Dice> _value = new(6);
        [SerializeField] private RollProbsWeights _commonProbsWeights = new();

        public IReadOnlyList<Dice> Value => _value;
        public RollProbsWeights CommonProbsWeights => _commonProbsWeights;

        public void Reset() {
            foreach (var dice in _value) {
                dice.Reset();
            }
        }

        public RollEye[] Roll() {
            AssignProbWeightsToAll();

            foreach (var value in _value.Where(value => !value.IsLocked.CurrentValue)) {
                value.RollDice();
            }

            var result = _value.Select(dice => dice.CurrentUpRollEye).ToList();

            return result.ToArray();
        }

        public void AssignProbWeightsToAll() {
            foreach (var dice in _value) {
                dice.SetProbWeights(_commonProbsWeights);
            }
        }
    }
}
