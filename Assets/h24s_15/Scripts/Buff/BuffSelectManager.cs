﻿using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using h24s_15.Battle.Rolling;
using h24s_15.Scenes.katsudon.katsudons.scripts;
using h24s_15.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace h24s_15.Buff {
    public class BuffSelectManager : SingletonMonoBehaviour<BuffSelectManager> {
        [SerializeField] private List<BuffCard> _buffCards;
        [SerializeField] private DiceSetManager _diceSetManager;
        [SerializeField] private Image _overLayImage;

        private List<BuffData> _buffDataList;
        private readonly AliasMethod _buffGacha = new();
        private BuffData _selectedBuffData = null;

        protected override void Awake() {
            base.Awake();

            _buffDataList = GetComponentsInChildren<BuffData>().ToList();
            var probWeights = _buffDataList.Select(data => data.ProbWeight).ToArray();
            _buffGacha.Constructor(probWeights);

            foreach (var buffCard in _buffCards) {
                buffCard.gameObject.SetActive(false);
            }
        }

        public void ApplyBuffData(BuffData data) {
            if (_selectedBuffData != null) {
                return;
            }

            _selectedBuffData = data;

            _overLayImage.enabled = true;
            _overLayImage
                .DOFade(1f, 1f)
                .OnComplete(() => { SceneManager.LoadScene("StageSelect"); })
                .SetLink(_overLayImage.gameObject);
        }

        public void DisplayBuffSelect() {
            Debug.Log("バフを選んでください");

            foreach (var card in _buffCards) {
                var data = GetRandomBuffData();
                card.AssignBuffData(data);
            }

            foreach (var card in _buffCards) {
                card.gameObject.SetActive(true);
            }
        }

        public async void BackToStageSelect() { }

        private BuffData GetRandomBuffData() {
            var index = _buffGacha.Roll();
            return _buffDataList[index];
        }
    }
}