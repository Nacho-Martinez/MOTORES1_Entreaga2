using UnityEngine;

namespace Enemy
{
    public class EnemySystem : MonoBehaviour
    {
        protected EnemyMain main;
        protected virtual void Awake()
        {
            main = transform.root.GetComponent<EnemyMain>();
        }
    }
}