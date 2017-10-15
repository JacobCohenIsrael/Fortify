using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackable : MonoBehaviour {

    public int Hitpoints;

    public void TakeDamage(int damageTaken)
    {
        Hitpoints -= damageTaken;

        if (Hitpoints < 0)
        {
            Destroy(gameObject);
        }
    }
}
