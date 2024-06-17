using System;
using h24s_15.Battle.Actions;
using h24s_15.Battle.Rolling.Actions;
using UnityEngine;

namespace h24s_15.Battle.Enemy {
    [Serializable]
    public struct ActionWithWeight {
        [SerializeField] private ActionData _actionData;
        [SerializeField] private float _weight;

        public ActionData ActionData => _actionData;
        public float Weight => _weight;

        public ActionWithWeight(ActionData actionData, float weight) {
            _actionData = actionData;
            _weight = weight;
        }
    }
}
