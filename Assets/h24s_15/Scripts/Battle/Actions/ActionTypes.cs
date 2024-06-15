using UnityEngine;

namespace h24s_15.Battle.Actions {
    public enum ActionTypes {
        Attack,
        Shield,
        Special
    }

    public static class ActionTypesExtension {
        private static Sprite _attackIcon;
        private static Sprite _shieldIcon;
        private static Sprite _specialIcon;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Initialize() {
            _attackIcon = Resources.Load<Sprite>("Sprites/Actions/IntentAttack");
            _shieldIcon = Resources.Load<Sprite>("Sprites/Actions/IntentShield");
            _specialIcon = Resources.Load<Sprite>("Sprites/Actions/IntentSpecial");
        }

        public static Sprite ToSprite(this ActionTypes actionType) {
            return actionType switch {
                ActionTypes.Attack => _attackIcon,
                ActionTypes.Shield => _shieldIcon,
                ActionTypes.Special => _specialIcon,
                _ => null
            };
        }
    }
}
