using System;
using System.Collections;
using Managers;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerAttackSystem : PlayerSystem
    {   
        private static readonly int Shooting = Animator.StringToHash("shoot");
        [Header("Damage")]
        [SerializeField] private float damage;
        [SerializeField] private float range = 100f;

        [Header("ShootConfiguration")] 
        [SerializeField] private float fireRate = 0.15f;
        [SerializeField] private LineRenderer shootEffect;
        [SerializeField] private float effectDuration = 0.05f; 
        private bool automaticShoot = false;

        private float nextFireTime = 0f;
        private bool isHoldingTrigger;

        protected override void Awake()
        {
            base.Awake();
        }

        private void OnEnable()
        {
            
            main.Controls.Player.ToggleShoot.performed += ToggleShoot;
            main.Controls.Player.Shoot.performed += ManualShoot;;
            main.Controls.Player.Shoot.started +=  NotShooting;
            main.Controls.Player.Shoot.canceled += SetShooting;
        }

        private void SetShooting(InputAction.CallbackContext context)
        {
            isHoldingTrigger = false;
        }

        private void NotShooting(InputAction.CallbackContext context)
        {
            isHoldingTrigger = true;
        }

        private void ManualShoot(InputAction.CallbackContext context)
        {
            if (!automaticShoot)
            {
                TryManualShoot();
            }
        }

        private void ToggleShoot(InputAction.CallbackContext context)
        {
             automaticShoot = !automaticShoot;
        }

        private void OnDisable()
        {
            main.Controls.Player.ToggleShoot.performed -= ToggleShoot;
            main.Controls.Player.Shoot.performed -= ManualShoot;;
            main.Controls.Player.Shoot.started -=  NotShooting;
            main.Controls.Player.Shoot.canceled -= SetShooting;
        }

        private void TryManualShoot()
        {
            if (Time.time >= nextFireTime)
            {
                Shoot();
                nextFireTime = Time.time + fireRate;
            }
        }

        private void Update()
        {
           if(isHoldingTrigger && automaticShoot)
           {
               if (Time.time >= nextFireTime)
               {
                   Shoot();
                   nextFireTime = Time.time + fireRate;
               }
           }
        }

        private void Shoot()
        {
            main.Anim.SetTrigger(Shooting);
            AudioManager.AudioInstance.PlaySoud(main.ShootSound);
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (mousePos - transform.position).normalized;

            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, range, main.filter);
            Vector3 finalPoint;
            if (hit.collider != null)
            {
                finalPoint = hit.point;
                if (hit.collider.TryGetComponent(out IDamageable target))
                {
                    target.TakeDamage(damage);
                }
            }
            else
            {
                finalPoint = transform.position + (Vector3)direction * range;
            }
            StopCoroutine(ShowShoot(Vector3.zero));
            StartCoroutine(ShowShoot(finalPoint));
        }

        private IEnumerator ShowShoot(Vector3 destiny)
        {
            shootEffect.enabled = true;
            shootEffect.SetPosition(0,transform.position);
            shootEffect.SetPosition(1,destiny);
            yield return new WaitForSeconds(effectDuration);
            shootEffect.enabled = false;
           
        }
    }
    
    }