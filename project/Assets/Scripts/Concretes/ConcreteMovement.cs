using UnityEngine;

namespace Assets.Scripts.Concretes
{
    public abstract class ConcreteMovement : MonoBehaviour
    {
        public float speed = 5;
        protected float direction;
        protected Rigidbody2D rigid;
        protected bool is_moving = true;

        void Awake()
        {
            rigid = GetComponent<Rigidbody2D>();
        }
        public void Update()
        {
            if (is_moving)
                Move();
        }

        public virtual void Move()
        {
            Debug.Log("Basic Movement is Nothing");
        }
    }
}
