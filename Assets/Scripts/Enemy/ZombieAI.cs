using System;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class ZombieAI : MonoBehaviour
{
   [SerializeField] private BaseSightSense sightModulo;
   [SerializeField] private float chasevelocity = 3f;

   [Header("Patrol Stats")]
   [SerializeField] private float patrolSpeed = 1.2f;
   [SerializeField] private float patrolRadius = 3f;
   [SerializeField] private float changeDirDistance = 0.3f;
   [SerializeField] private float maxPatrolTime = 10f;


   private Vector2 currentPatrolPoint;
   private Rigidbody2D rb;
   private Transform objective;
   private float patrolStartTime;

   private void Awake()
   {
      rb = GetComponent<Rigidbody2D>();
      GenerateNewPatrolPoint();
   }

   private void Update()
   {
      objective = sightModulo.DectectObjetive();
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
      float distancex = Mathf.Abs(rb.position.x - currentPatrolPoint.x);
      
      if (distancex < changeDirDistance)
      {
         GenerateNewPatrolPoint();
      }

      float directionx = 0;
      if (currentPatrolPoint.x > rb.position.x)
      {
         directionx = 1f;
      }
      else
      {
         directionx = -1f;
      }

      rb.linearVelocity = new Vector2(directionx * patrolSpeed, rb.linearVelocity.y);
      Rotate(currentPatrolPoint.x);
   }

   private void Chase(Transform objetive)
   {
      float direccionX = 0;
      if (objetive.position.x > rb.position.x)
      {
         direccionX = 1f;
      }
      else
      {
         direccionX = -1f;
      }

      rb.linearVelocity = new Vector2(direccionX * chasevelocity, rb.linearVelocity.y);
      Rotate(objetive.position.x);
   }

   private void GenerateNewPatrolPoint()
   {
      Vector2 randomOffset = Random.insideUnitCircle * patrolRadius;
      currentPatrolPoint = rb.position + randomOffset;
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
