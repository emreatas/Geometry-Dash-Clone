using GDClone.CubeCharacter;
using GDClone.GameManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GDClone.Portal
{

    public class Portal : MonoBehaviour
    {
        public GameMode gameMode;
        public States state;

        public SpeedState speedState;
        public bool gravityMode;



        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.GetComponent<CubeMovement>())
            {
                GameManager.GameManager.instance.ChangeMovement(gameMode, speedState, gravityMode, state);
            }



        }

    }
}