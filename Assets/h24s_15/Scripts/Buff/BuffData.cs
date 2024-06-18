using System;
using h24s_15.Battle.Rolling;
using UnityEngine;

namespace h24s_15.Buff {
    public class BuffData : MonoBehaviour {
        [SerializeField] private float _probWeight;
        [SerializeField] private BuffTypes _buffType;
        [SerializeField] private DiffProbWeights _diffProbWeights;
        [SerializeField] private DiffRoleMultipliers _diffRoleMultipliers;
        [SerializeField] private int _healValue;

        public float ProbWeight => _probWeight;
        public BuffTypes BuffType => _buffType;
        public DiffProbWeights DiffProbWeights => _diffProbWeights;
        public DiffRoleMultipliers DiffRoleMultipliers => _diffRoleMultipliers;
        public int HealValue => _healValue;

        public string GetDescription() {
            var description = "";
            switch (_buffType) {
                case BuffTypes.ChangeProbs:
                    var increasedEyes = _diffProbWeights.GetIncreasedEyes();
                    var decreasedEyes = _diffProbWeights.GetDecreasedEyes();
                    foreach (var eye in increasedEyes) {
                        description += $"{eye.ToFullText()} ";
                    }

                    description += "\nの目が出やすくなり\n";

                    foreach (var eye in decreasedEyes) {
                        description += $"{eye.ToFullText()} ";
                    }

                    description += "\nの目が出にくくなる";
                    break;
                case BuffTypes.ChangeMultipliers:
                    break;
                case BuffTypes.Heal:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return description;
        }
    }
}
