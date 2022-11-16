using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;

namespace DopeFrenzy
{
    public class ShootableWeapon : Weapon
    {

        [SerializeField] private Transform _firePoint;
        [SerializeField] private float _damagePerBullet;
        [SerializeField] private LayerMask m_damagableLayer;
        [SerializeField] private float _fireRate;


        private LineRenderer lineRenderer;
        private EquipHandler equipHandler;


        protected override LayerMask layerMask { get => m_damagableLayer; set => m_damagableLayer = value; }
        public override Transform firePoint { get => _firePoint; set => _firePoint = value; }


        void Start()
        {
            lineRenderer = transform.Find("Line").GetComponent<LineRenderer>();
        }

        public override void Fire(Character character)
        {
            if (weaponType == WeaponType.Primary)
            {
                StartCoroutine(OnFire(_damagePerBullet, character));
            }
            else {
                transform.DOLocalMoveX(0.1f, 0.2f)
                    .OnComplete(()=> transform.DOLocalMoveX(0f,0.2f));
            }
        }

        private IEnumerator OnFire(float damage, Character m_Character)
        {

            //ANCHOR Accuracy calculation
            float vertical = Random.Range(0, 100);
            float horizontal = Random.Range(0, 100);

            var direction = firePoint.right + new Vector3(
                horizontal = horizontal < m_Character.Accuracy ? 0 : Random.Range(-0.03f, 0.03f),
                vertical = vertical < m_Character.Accuracy ? 0 : Random.Range(-0.03f, 0.03f)
                );

            //END Accuracy Calculation

            RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, direction, Mathf.Infinity, layerMask);

            if (hitInfo)
            {
                //takeDamage
                try
                {
                    hitInfo.transform.GetComponent<IDamagable>().TakeDamage(damage, m_Character);
                }
                catch (System.Exception)
                {


                }


                lineRenderer.SetPosition(0, firePoint.position);
                lineRenderer.SetPosition(1, hitInfo.point);
            }
            else
            {
                lineRenderer.SetPosition(0, firePoint.position);
                lineRenderer.SetPosition(1, firePoint.position + firePoint.right * 100);
            }

            lineRenderer.enabled = true;
            yield return null;
            lineRenderer.enabled = false;
        }


    }
}


