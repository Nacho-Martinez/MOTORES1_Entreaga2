using UnityEngine;

namespace Npc
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Random = UnityEngine.Random;
    public class NPCMovemnt : MonoBehaviour
    {
        private static readonly int Running = Animator.StringToHash("running");
        [SerializeField] private float patrolSpeed;
        [SerializeField] private Transform patrolPath;
        private Vector3 currentDestitnation;
        private int currentIndex = 0;
        private List<Vector3> patrolPosition = new();
        private Animator anim;

        private void Start()
        {
            anim = GetComponent<Animator>();
            foreach (Transform patrolPoint in patrolPath)
            {
                patrolPosition.Add(patrolPoint.position);  
            }

            StartCoroutine(PatrolAndWait());
        }

        private IEnumerator PatrolAndWait()
        {
            while (true)
            {
                anim.SetBool(Running,true);
                CalculateNewDestitnation();
                FaceToDestination();
                while (transform.position != currentDestitnation) //Mientras no hayas llegado....
                {
                    transform.position =
                        Vector3.MoveTowards(transform.position, currentDestitnation, patrolSpeed * Time.deltaTime);
                    yield return new WaitForEndOfFrame();
                }
                anim.SetBool(Running,false);
                yield return new WaitForSeconds(Random.Range(0.5f, 1.75f));
                currentIndex = (currentIndex + 1) % patrolPosition.Count;
                anim.SetBool(Running,true);
            }
        }

        private void FaceToDestination()
        {
            float x = currentDestitnation.x - transform.position.x;
            if (Math.Sign(x) == -1)//El destino esta a mi izquierda
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            else if (Math.Sign(x) == 1f)
            {
                transform.eulerAngles = Vector3.zero;
            }
        }
        private void CalculateNewDestitnation()
        {
            currentDestitnation = patrolPosition[currentIndex];
        }

        public void StopAllMovementCorrutines()
        {
            anim.SetBool(Running,false);
            StopAllCoroutines();
        }
    }
}