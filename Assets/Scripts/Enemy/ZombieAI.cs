using System;
using Enemy;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class ZombieAI : EnemySystem
{
   private static readonly int Running = Animator.StringToHash("running");

   [SerializeField] private float chasevelocity = 3f;

   [Header("Patrol Stats")]
   [SerializeField] private float patrolSpeed = 1.2f;
   [SerializeField] private float patrolRadius = 3f;
   [SerializeField] private float changeDirDistance = 0.3f;
   [SerializeField] private float maxPatrolTime = 10f;
   
   private Vector2 currentPatrolPoint;
   private Transform objective;
   private float patrolStartTime;

   
   private void Start()
   {
      GenerateNewPatrolPoint();
   }

   private void Update()
   {
      objective = main.sightModulo.DectectObjetive();
      if (objective == null)
      {
         float timePatroling = Time.time - patrolStartTime;

         if (timePatroling >= maxPatrolTime)
         {
            GenerateNewPatrolPoint();
         }
      }
     
   }

   private void FixedUpdate()
   {
      if (objective!= null)
      {
         Chase(objective);
      }
      else
      {
         Patrol();
      }
   }

   private void Patrol()
   {
      main.Anim.SetBool(Running,false);
      float distancex = Mathf.Abs(main.Rb.position.x - currentPatrolPoint.x);
      
      if (distancex < changeDirDistance)
      {
         GenerateNewPatrolPoint();
      }

      float directionx = 0;
      if (currentPatrolPoint.x > main.Rb.position.x)
      {
         directionx = 1f;
      }
      else
      {
         directionx = -1f;
      }

      main.Rb.linearVelocity = new Vector2(directionx * patrolSpeed, main.Rb.linearVelocity.y);
      Rotate(currentPatrolPoint.x);
   }

   private void Chase(Transform objetive)
   {
      main.Anim.SetBool(Running,true);
      float direccionX = 0;
      if (objetive.position.x > main.Rb.position.x)
      {
         direccionX = 1f;
      }
      else
      {
         direccionX = -1f;
      }

      main.Rb.linearVelocity = new Vector2(direccionX * chasevelocity, main.Rb.linearVelocity.y);
      Rotate(objetive.position.x);
   }

   private void GenerateNewPatrolPoint()
   {
      Vector2 randomOffset = Random.insideUnitCircle * patrolRadius;
      currentPatrolPoint = main.Rb.position + randomOffset;
      patrolStartTime = Time.time;
   }

   private void Rotate(float objetiveX)
   {
      if (objetiveX > transform.position.x)
      {
         transform.eulerAngles = Vector3.zero;
      }
      else if (objetiveX < transform.position.x)
      {
         transform.eulerAngles = new Vector3(0, 180, 0);
      }
   }
}
