using System;
using UnityEngine;

namespace WeaponsAttacks
{
    public interface IAttack
    {

    }

    public abstract class Attack : IAttack
    {
        public event Action<IWeaponVisitor> AcceptVisit;

        protected Weapon weapon;

        public Attack(Weapon weapon)
        {
            this.weapon = weapon;
        }

        public abstract void PerformAttack();

        protected void Accept(IWeaponVisitor visitor)
        {
            AcceptVisit?.Invoke(visitor);
        }
    }

    public class OverlapAttack : Attack
    {
        private OverlapSettings _settings;

        public OverlapAttack(Weapon weapon, OverlapSettings overlapSettings) : base(weapon)
        {
            _settings = overlapSettings;
        }

        public override void PerformAttack()
        {
            Collider[] hitColliders = new Collider[_settings.maxAmountColliders];
            int amountColliders = Physics.OverlapSphereNonAlloc(_settings.overlapPoint.position, _settings.attackRange, hitColliders);
            TryPerformAttack(hitColliders, amountColliders);
        }

        private void TryPerformAttack(Collider[] colliders, int amountColliders)
        {
            for(int i = 0; i < amountColliders; i++)
            {
                TryAcceptWeaponVisitor(colliders[i]);
            }
        }

        protected virtual void TryAcceptWeaponVisitor(Collider collider)
        {
            if(collider.gameObject.TryGetComponent(out IWeaponVisitor weaponVisitor))
            {
                Accept(weaponVisitor);
            }
        }
    }

    public class WeaponSettings
    {
    }

    public class OverlapSettings : WeaponSettings
    {
        private int _maxAmountColliders;
        private float _attackRange;
        private Transform _overlapPoint;

        public int maxAmountColliders => _maxAmountColliders;
        public float attackRange => _attackRange;
        public Transform overlapPoint => _overlapPoint;
    }
}