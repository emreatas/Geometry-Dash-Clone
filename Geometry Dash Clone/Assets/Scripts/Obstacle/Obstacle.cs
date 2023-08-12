using GDClone.CubeCharacter;
using GDClone.GameManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GDClone.Obstacle
{
    public class Obstacle : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.GetComponent<CubeMovement>())
            {
                GameManager.GameManager.instance.GameLose();
            }
        }
    }
}