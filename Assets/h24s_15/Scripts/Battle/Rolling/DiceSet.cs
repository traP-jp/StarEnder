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

        public RollEye[] Roll() {
            AssignProbWeightsToAll();

            var result = new List<RollEye>(SET_SIZE);
            result.AddRange(_value.Select(dice => dice.RollDice()));

            return result.ToArray();
        }

        public void AssignProbWeightsToAll() {
            foreach (var dice in _value) {
                dice.SetProbWeights(_commonProbsWeights);
            }
        }
    }
}
