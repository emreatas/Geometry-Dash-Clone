using GDClone.CubeCharacter;
using GDClone.GameManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<CubeMovement>())
        {
            GameManager.instance.GameWin();
            Debug.Log("aa");
        }
    }
}
