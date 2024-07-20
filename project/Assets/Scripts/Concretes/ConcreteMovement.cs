using UnityEngine;

namespace Assets.Scripts.Concretes
{
    public abstract class ConcreteMovement : MonoBehaviour
    {
        public float speed = 5;
        protected float direction;
        protected Rigidbody2D rigid;

        void Awake()
        {
            rigid = GetComponent<Rigidbody2D>();
        }
        public void Update()
        {
            Move();
        }

        public abstract void Move();
    }
}
