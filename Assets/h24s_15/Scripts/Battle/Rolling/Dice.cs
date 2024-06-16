using System;
using Cysharp.Threading.Tasks;
using R3;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace h24s_15.Battle.Rolling {
    public class Dice : MonoBehaviour, IPointerClickHandler {
        [SerializeField] private Image _diceImage;
        [SerializeField] private Image _diceCaseImage;
        [SerializeField] private Animator _animator;

        [Header("パラメーター")]
        [Tooltip("サイコロ回しのアニメーションの持続秒数")] [SerializeField]
        private float _rollingDurationSeconds = 1.0f;

        [Tooltip("ロールアニメーションのスピード")] [SerializeField] private float _animationSpeed = 1.0f;

        private readonly ReactiveProperty<bool> _isLocked = new(false);
        private RollEye _currentUpRollEye = RollEye.One;
        private RollProbsWeights _probsWeights;

        public ReadOnlyReactiveProperty<bool> IsLocked => _isLocked.ToReadOnlyReactiveProperty();
        public RollEye CurrentUpRollEye => _currentUpRollEye;

        private void Awake() {
            _animator.speed = 0f;

            _isLocked.Subscribe(this,
                    (isLocked, t) => { t._diceCaseImage.color = isLocked ? Color.black : Color.white; })
                .AddTo(this);
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
            _animator.enabled = true;
            await UniTask.Delay((int)(_rollingDurationSeconds * 1000));
            _animator.speed = 0f;
            _animator.enabled = false;

            await UniTask.Yield(PlayerLoopTiming.Update);

            _diceImage.sprite = rolledEye.ToNormalSprite();
        }

        public void OnPointerClick(PointerEventData eventData) {
            _isLocked.Value = !_isLocked.Value;
        }
    }
}
