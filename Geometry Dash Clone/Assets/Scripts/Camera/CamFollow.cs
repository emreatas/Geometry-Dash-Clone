using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GDClone.Camera
{
    public class CamFollow : MonoBehaviour
    {
        [SerializeField] Transform _character;

        public float smootSpeed = 0.125f;
        public Vector3 offset;
        private Vector3 velocity = Vector3.zero;

        private void LateUpdate()
        {
            /* Vector3 desiredPos = _character.position + offset;
             Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smootSpeed * Time.deltaTime);
             transform.position = new Vector3(smoothedPos.x, 0, smoothedPos.z);
         */
            Vector3 targetPos = _character.TransformPoint(offset);
            Vector3 test = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smootSpeed);

            transform.position = new Vector3(test.x, 0, test.z);
        }
    }
}
