using Minefield.Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minefield
{
    public class Mine : MonoBehaviour, IDamagable
    {
        [SerializeField] private float _damageRadius = 2.0f;
        [SerializeField] private float _baseDamage = 100.0f;
        [SerializeField] private bool _fadeDamage = false;
        [SerializeField] private float _triggerRadius = 2.0f;
        [SerializeField] private float _boomTimeout = 3.0f;
        [SerializeField] private float _minDamageForBoom = 0.0f;

        [SerializeField] private LayerMask _damagedLayers = Physics.AllLayers;
        [SerializeField] private LayerMask _ignoredLayers = 1 << 8;

        public void TakeDamage(float damage)
        {
            if (damage >= _minDamageForBoom)
                StartCoroutine(BoomDeferred());
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_ignoredLayers.Includes(other.gameObject.layer))
                return;

            Boom();
        }

        private void Boom()
        {
            Debug.Log("boom!");

            // нанести урон в радиусе поражения
            MakeDamage();

            // запустить эффекты
            ShowEffects();

            // исчезнуть
            Destroy();
        }

        private IEnumerator BoomDeferred()
        {
            yield return new WaitForSeconds(_boomTimeout);
            Boom();
        }

        private void MakeDamage()
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, _damageRadius, _damagedLayers);

            foreach (var item in colliders)
            {
                if (item.TryGetComponent(out IDamagable damagable))
                {
                    if (_fadeDamage)
                    {
                        float damage = CalculateDamageByDistance(item);
                        damagable.TakeDamage(damage);
                    }
                    else
                    {
                        damagable.TakeDamage(_baseDamage);
                    }
                }
            }
        }

        private void ShowEffects()
        {

        }

        private void Destroy()
        {
            gameObject.SetActive(false);
        }

        private float CalculateDamageByDistance(Collider collider)
        {
            return _baseDamage;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, _damageRadius);
        }
    }

    internal interface IDamagable
    {
        void TakeDamage(float damage);
    }
}

