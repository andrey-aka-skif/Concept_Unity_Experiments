using System;
using System.Collections;
using UnityEngine;

namespace SteelHeart.Interactable
{
    public class EventsCatcher : MonoBehaviour
    {
        [SerializeField] private AbstractActivatedSource _source;

        private void OnActivated(Action action)
        {
            StartCoroutine(Timer(action));
        }

        IEnumerator Timer(Action action)
        {
            yield return new WaitForSeconds(10);

            action?.Invoke();
        }

        private void OnEnable() =>
            _source.ActivatedWithCallback += OnActivated;

        private void OnDisable() =>
            _source.ActivatedWithCallback -= OnActivated;
    }
}
