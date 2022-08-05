using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace IdleActionFarm.UI
{
    public class StoragePanel : MonoBehaviour
    {
        [SerializeField] private Storage _storage;
        [SerializeField] private TMP_Text _text;

        private void OnEnable()
        {
            _storage.StacksCountChanged += UpdateText;
        }

        private void OnDisable()
        {
            _storage.StacksCountChanged -= UpdateText;
        }

        private void UpdateText(int stacksCount)
        {
            _text.text = $"{stacksCount}/{_storage.Capacity}";
        }
    }
}
