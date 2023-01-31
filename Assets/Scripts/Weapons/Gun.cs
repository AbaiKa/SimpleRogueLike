using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapons.Bullets;

namespace Weapons
{
    public class Gun : BaseWeapon
    {
        [SerializeField]
        private GunBullet _bulletPrefab;
        protected override void DoAttack()
        {
            //TODO: Take bullet from object pool
            GunBullet bullet = Instantiate(_bulletPrefab, transform.position, transform.rotation);
            bullet.Init(ignoreColliders, Stats.Damage, Stats.BulletSpeed, Stats.BulletLifeTime, Stats.TargetTag);
        }
    }
}