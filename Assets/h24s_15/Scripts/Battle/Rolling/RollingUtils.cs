using System.Collections.Generic;
using UnityEngine;

namespace h24s_15.Battle.Rolling {
    public static class RollingUtils {
        public static List<RollEye> ComputeHeadEyes(RollEye[] eyes) {
            var headEyes = new List<RollEye>();

            var role = EvaluateRole(eyes);
            if (role.IsMultipleEyeNecessary() || role is Role.NoPair) {
                return headEyes;
            }

            System.Array.Sort(eyes);

            switch (role) {
                case Role.OnePair:
                    headEyes.Add(eyes[0]);
                    break;
                case Role.TwoPair:
                    headEyes.Add(eyes[0]);
                    headEyes.Add(eyes[2]);
                    break;
                case Role.ThreeDice:
                    headEyes.Add(eyes[0]);
                    break;
                case Role.FullHouse:
                    headEyes.Add(eyes[0]);
                    headEyes.Add(eyes[3]);
                    break;
                case Role.FourDice:
                    headEyes.Add(eyes[0]);
                    break;
                case Role.FiveDice:
                    headEyes.Add(eyes[0]);
                    break;
            }

            return headEyes;
        }

        public static Role EvaluateRole(RollEye[] eyes) {
            var eyesLength = eyes.Length;

            if (eyesLength != DiceSet.SET_SIZE) {
                throw new System.ArgumentException($"サイコロの数が{DiceSet.SET_SIZE}個ではありません。");
            }

            System.Array.Sort(eyes);

            if (ExistsFiveDice(eyes)) {
                return Role.FiveDice;
            }

            if (ExistsFourDice(eyes)) {
                return Role.FourDice;
            }

            if (ExistsBStraight(eyes)) {
                return Role.BStraight;
            }

            if (ExistsSStraight(eyes)) {
                return Role.SStraight;
            }

            if (ExistsFullHouse(eyes)) {
                return Role.FullHouse;
            }

            if (ExistsThreeDice(eyes)) {
                return Role.ThreeDice;
            }

            if (ExistsTwoPair(eyes)) {
                return Role.TwoPair;
            }

            if (ExistsOnePair(eyes)) {
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
