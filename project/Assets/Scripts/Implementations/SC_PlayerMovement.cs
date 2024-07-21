using Assets.Scripts.Concretes;
using UnityEngine;


    public class SC_PlayerMovement : ConcreteMovement
    {

        public float jump_speed=200;

        public override void Move()
        {
            direction = Input.GetAxis("Horizontal");

            if (direction != 0 && rigid != null)
                Walk();
        }

        private void Walk()
        {
            rigid.velocity = new Vector2(direction * speed, rigid.velocity.y);

            if (direction > 0)
                transform.localScale = new Vector3(1, 1, 1);
            else transform.localScale = new Vector3(-1, 1, 1);
        }

    }

