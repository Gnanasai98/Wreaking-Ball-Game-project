using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WB.Controller {
    public class BlockManager : MonoBehaviour
    {
        [SerializeField] int breakForce = 1200;

        FixedJoint2D fJoint2D;
        private void Start()
        {
            fJoint2D= GetComponent<FixedJoint2D>();
            fJoint2D.breakForce = breakForce;
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision == null || fJoint2D ==null) { return; }

            Vector2 collisionVelocity = collision.relativeVelocity;
            float impulseForce = Mathf.Abs(collisionVelocity.sqrMagnitude);
            fJoint2D.breakForce -= impulseForce*10;
            Debug.Log(fJoint2D.breakForce+ " "+ this.gameObject.name);
        }
    }
}
