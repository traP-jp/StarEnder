using System;
using System.Linq;
using h24s_15.Utils;
using UnityEngine;

namespace h24s_15.Battle.Rolling {
    [Serializable]
    public class RollProbsWeights {
        public RollProbsWeights() {
            _aliasMethod.Constructor(_probWeights);
        }

        [SerializeField] private float[] _probWeights = new float[6] { 1f, 1f, 1f, 1f, 1f, 1f };
        private readonly AliasMethod _aliasMethod = new();

        /// <summary>
        /// 確率を設定する.
        /// </summary>
        /// <param name="probsWeights"></param>
        public void SetProbs(float[] probsWeights) {
            _probWeights = probsWeights;
            _aliasMethod.Constructor(probsWeights);
        }

        /// <summary>
        /// 出目を受け取ってその確率を返す.
        /// </summary>
        /// <param name="eye"></param>
        /// <returns></returns>
        public float GetProb(RollEye eye) {
            var weightSum = _probWeights.Sum();
            var targetWeight = _probWeights[(int)eye - 1];
            return targetWeight / weightSum;
        }

        /// <summary>
        /// 最も確率の高い出目を返す.
        /// </summary>
        /// <returns></returns>
        public RollEye MostProbableEye() {
            float maxProb = 0;
            var maxEye = RollEye.One;
            for (var i = 0; i < 6; i++) {
                if (_probWeights[i] > maxProb) {
                    maxProb = _probWeights[i];
                    maxEye = (RollEye)(i + 1);
                }
            }

            return maxEye;
        }

        /// <summary>
        /// 確率の低い順にソートして出目の配列を返す.
        /// </summary>
        /// <returns></returns>
        public RollEye[] GetSortedEyes() {
            var sortedEyes = new RollEye[6];
            for (var i = 0; i < 6; i++) {
                sortedEyes[i] = (RollEye)(i + 1);
            }

            Array.Sort(sortedEyes, (a, b) => GetProb(a).CompareTo(GetProb(b)));
            return sortedEyes;
        }

        /// <summary>
        /// 確率に従って出目を出す.
        /// </summary>
        /// <returns></returns>
        public RollEye Roll() {
            _aliasMethod.Constructor(_probWeights);
            var rolledIndex = _aliasMethod.Roll();
            return (RollEye)(rolledIndex + 1);
        }
    }
}
