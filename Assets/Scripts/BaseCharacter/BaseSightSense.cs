using UnityEngine;

public class BaseSightSense : MonoBehaviour
{
   [SerializeField] private float visionRange = 10f;
   [Range(0, 360)] [SerializeField] private float visionAngle = 90f;
   [SerializeField] private LayerMask obstacules;


   public Transform DectectObjetive()
   {
      Collider2D[] closeColliders = Physics2D.OverlapCircleAll(transform.position, visionRange);
      foreach (var collider in closeColliders)
      {
         if (collider.CompareTag("Player"))
         {
            Transform objective = collider.transform;
            Vector2 directionObjective = (objective.position - transform.position).normalized;

            float angle = Vector2.Angle(transform.right, directionObjective);
            if (angle < visionAngle / 2f)
            {
               float distance = Vector2.Distance(transform.position, objective.position);

               if (!Physics2D.Raycast(transform.position, directionObjective, distance, obstacules))
               {
                  return objective;
               }
            }
         }
      }

      return null;
   }
   
   private void OnDrawGizmosSelected()
   {
      // Dibujamos el cono de visión en el editor para depurar
      Gizmos.color = Color.blue;
      Gizmos.DrawWireSphere(transform.position, visionRange);

      Vector3 dcha = Quaternion.Euler(0, 0, -visionAngle / 2) * transform.right;
      Vector3 izq = Quaternion.Euler(0, 0, visionAngle / 2) * transform.right;

      Gizmos.color = Color.cyan;
      Gizmos.DrawRay(transform.position, dcha * visionAngle);
      Gizmos.DrawRay(transform.position, izq * visionAngle);
   }
   
}
