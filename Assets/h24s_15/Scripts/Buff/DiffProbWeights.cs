using System;
using System.Collections.Generic;
using h24s_15.Battle.Rolling;

namespace h24s_15.Buff {
    [Serializable]
    public struct DiffProbWeights {
        public int DiffOneProbWeight;
        public int DiffTwoProbWeight;
        public int DiffThreeProbWeight;
        public int DiffFourProbWeight;
        public int DiffFiveProbWeight;
        public int DiffSixProbWeight;

        public int GetDiffProbWeight(RollEye eye) {
            return eye switch {
                RollEye.One => DiffOneProbWeight,
                RollEye.Two => DiffTwoProbWeight,
                RollEye.Three => DiffThreeProbWeight,
                RollEye.Four => DiffFourProbWeight,
                RollEye.Five => DiffFiveProbWeight,
                RollEye.Six => DiffSixProbWeight,
                _ => throw new ArgumentOutOfRangeException(nameof(eye), eye, null)
            };
        }

        public List<RollEye> GetIncreasedEyes() {
            var increasedEyes = new List<RollEye>();
            if (DiffOneProbWeight > 0) {
                increasedEyes.Add(RollEye.One);
            }

            if (DiffTwoProbWeight > 0) {
                increasedEyes.Add(RollEye.Two);
            }

            if (DiffThreeProbWeight > 0) {
                increasedEyes.Add(RollEye.Three);
            }

            if (DiffFourProbWeight > 0) {
                increasedEyes.Add(RollEye.Four);
            }

            if (DiffFiveProbWeight > 0) {
                increasedEyes.Add(RollEye.Five);
            }

            if (DiffSixProbWeight > 0) {
                increasedEyes.Add(RollEye.Six);
            }

            return increasedEyes;
        }

        public List<RollEye> GetDecreasedEyes() {
            var decreasedEyes = new List<RollEye>();
            if (DiffOneProbWeight < 0) {
                decreasedEyes.Add(RollEye.One);
            }

            if (DiffTwoProbWeight < 0) {
                decreasedEyes.Add(RollEye.Two);
            }

            if (DiffThreeProbWeight < 0) {
                decreasedEyes.Add(RollEye.Three);
            }

            if (DiffFourProbWeight < 0) {
                decreasedEyes.Add(RollEye.Four);
            }

            if (DiffFiveProbWeight < 0) {
                decreasedEyes.Add(RollEye.Five);
            }

            if (DiffSixProbWeight < 0) {
                decreasedEyes.Add(RollEye.Six);
            }

            return decreasedEyes;
        }
    }
}
