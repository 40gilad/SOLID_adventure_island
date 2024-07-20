using System;
using UnityEngine;

namespace Assets.Scripts.Implementations
{
    public class SC_Jump
    {
        private float jumpSpeed;
        private bool isJumping = false;
        private Rigidbody2D rigid;

        public SC_Jump(float jumpspeed=100,Rigidbody2D rigidbody=null)
        {
            if (rigidbody == null)
                throw new ArgumentNullException("rigidbody");
            this.jumpSpeed = jumpspeed;
            this.rigid=rigidbody;
        }

        public void Jump()
        {
            if (!isJumping)
            {
                rigid.AddForce(new Vector2(0, jumpSpeed));
                isJumping = true;
            }
        }


        public void FloorCollision()
        {
            isJumping = false;
        }
    }
}
