using System;
using Cysharp.Threading.Tasks;
using R3;
using UnityEngine;
using UnityEngine.UI;

namespace h24s_15.Battle.Rolling {
    public class Dice : MonoBehaviour {
        [Header("パラメーター")]
        [Tooltip("サイコロ回しのアニメーションの持続秒数")] [SerializeField]
        private float _rollingDurationSeconds = 1.0f;

        [Tooltip("ロールアニメーションのスピード")] [SerializeField] private float _animationSpeed = 1.0f;

        private readonly ReactiveProperty<bool> _isLocked = new(false);
        private RollEye _currentUpRollEye = RollEye.One;
        private RollProbsWeights _probsWeights;

        private Image _diceImage;
        private Animator _animator;

        public ReadOnlyReactiveProperty<bool> IsLocked => _isLocked.ToReadOnlyReactiveProperty();
        public RollEye CurrentUpRollEye => _currentUpRollEye;

        private void Awake() {
            _diceImage = GetComponent<Image>();
            _animator = GetComponent<Animator>();

            _animator.speed = 0f;
        }

        public void SetProbWeights(RollProbsWeights rollProbsWeights) {
            _probsWeights = rollProbsWeights;
        }

        public RollEye RollDice() {
            var eye = _probsWeights.Roll();
            PlayRollAnimationAsync(eye).Forget();
            _currentUpRollEye = eye;
            return eye;
        }

        public void Reset() {
            const RollEye defaultEye = RollEye.One;
            _currentUpRollEye = defaultEye;
            _diceImage.sprite = defaultEye.ToNormalSprite();
        }

        public void ToggleLock() {
            _isLocked.Value = !_isLocked.Value;
        }

        private async UniTask PlayRollAnimationAsync(RollEye rolledEye) {
            _animator.speed = _animationSpeed;
            await UniTask.Delay((int)(_rollingDurationSeconds * 1000));
            _animator.speed = 0f;

            _diceImage.sprite = rolledEye.ToNormalSprite();
        }
    }
}
