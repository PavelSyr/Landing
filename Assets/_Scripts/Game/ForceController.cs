using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class ForceController : MonoBehaviour
    {
        public float Force = 5f;
        private Vector3 LEFT  { get { return m_Transform.right * -1; } }
        private Vector3 RIGHT { get { return m_Transform.right; } }
        private Vector3 UP    { get { return m_Transform.up; } }
        private Vector3 DOWN  { get { return m_Transform.up * -1f; } }

        [SerializeField]
        private Rigidbody2D m_RBody;
        private Transform m_Transform;

        private void Awake()
        {
            m_Transform = transform;
        }

        public void Left()
        {
            AddForce(LEFT);
        }

        public void Right()
        {
            AddForce(RIGHT);
        }

        public void Up()
        {
            AddForce(UP);
        }

        public void Down()
        {
            AddForce(DOWN);
        }

        private void AddForce(Vector3 force)
        {
            m_RBody.AddForce(force * Force);
        }
    }
}
