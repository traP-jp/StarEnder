using UnityEngine;

namespace h24s_15.Battle.Rolling {
    public static class RollingUtils {
        public static Role EvaluateRole(RollEye[] eyes) {
            var eyesLength = eyes.Length;

            if (eyesLength != DiceSet.SET_SIZE) {
                throw new System.ArgumentException($"サイコロの数が{DiceSet.SET_SIZE}個ではありません。");
            }

            var sortedEyes = (RollEye[])eyes.Clone();
            System.Array.Sort(sortedEyes);

            if (ExistsFiveDice(sortedEyes)) {
                return Role.FiveDice;
            }

            if (ExistsFourDice(sortedEyes)) {
                return Role.FourDice;
            }

            if (ExistsBStraight(sortedEyes)) {
                return Role.BStraight;
            }

            if (ExistsSStraight(sortedEyes)) {
                return Role.SStraight;
            }

            if (ExistsFullHouse(sortedEyes)) {
                return Role.FullHouse;
            }

            if (ExistsThreeDice(sortedEyes)) {
                return Role.ThreeDice;
            }

            if (ExistsTwoPair(sortedEyes)) {
                return Role.TwoPair;
            }

            if (ExistsOnePair(sortedEyes)) {
                return Role.OnePair;
            }

            return Role.NoPair;
        }

        public static bool ExistsOnePair(RollEye[] eyes) {
            return eyes[0] == eyes[1] || eyes[1] == eyes[2] || eyes[2] == eyes[3] || eyes[3] == eyes[4];
        }

        public static bool ExistsTwoPair(RollEye[] eyes) {
            return (eyes[0] == eyes[1] && eyes[2] == eyes[3]) ||
                   (eyes[0] == eyes[1] && eyes[3] == eyes[4]) ||
                   (eyes[1] == eyes[2] && eyes[3] == eyes[4]);
        }

        public static bool ExistsThreeDice(RollEye[] eyes) {
            return (eyes[0] == eyes[1] && eyes[1] == eyes[2]) ||
                   (eyes[1] == eyes[2] && eyes[2] == eyes[3]) ||
                   (eyes[2] == eyes[3] && eyes[3] == eyes[4]);
        }

        public static bool ExistsFullHouse(RollEye[] eyes) {
            return (eyes[0] == eyes[1] && eyes[1] == eyes[2] && eyes[3] == eyes[4]) ||
                   (eyes[0] == eyes[1] && eyes[2] == eyes[3] && eyes[3] == eyes[4]);
        }

        public static bool ExistsSStraight(RollEye[] eyes) {
            return (eyes[0] is RollEye.One && eyes[1] is RollEye.Two && eyes[2] is RollEye.Three &&
                    eyes[3] is RollEye.Four) ||
                   (eyes[1] is RollEye.Two && eyes[2] is RollEye.Three && eyes[3] is RollEye.Four &&
                    eyes[4] is RollEye.Five);
        }

        public static bool ExistsBStraight(RollEye[] eyes) {
            return eyes[0] + 1 == eyes[1] && eyes[1] + 1 == eyes[2] && eyes[2] + 1 == eyes[3] && eyes[3] + 1 == eyes[4];
        }

        public static bool ExistsFourDice(RollEye[] eyes) {
            return (eyes[0] == eyes[1] && eyes[1] == eyes[2] && eyes[2] == eyes[3]) ||
                   (eyes[1] == eyes[2] && eyes[2] == eyes[3] && eyes[3] == eyes[4]);
        }

        public static bool ExistsFiveDice(RollEye[] eyes) {
            return eyes[0] == eyes[1] && eyes[1] == eyes[2] && eyes[2] == eyes[3] && eyes[3] == eyes[4];
        }
    }
}
