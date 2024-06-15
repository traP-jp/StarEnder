using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace h24s_15.Battle.Rolling {
    public class Dice : MonoBehaviour {
        [SerializeField] private Image _diceImage;
        [SerializeField] private TMP_Text _diceText;
        private RollProbsWeights _probsWeights;

        public void SetProbWeights(RollProbsWeights rollProbsWeights) {
            _probsWeights = rollProbsWeights;
        }

        public RollEye RollDice() {
            var eye = _probsWeights.Roll();
            _diceText.text = ((int)eye).ToString();
            return eye;
        }
    }
}
