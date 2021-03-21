using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishSkript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PlayerTag")
        {
            FileRead.num++;
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
