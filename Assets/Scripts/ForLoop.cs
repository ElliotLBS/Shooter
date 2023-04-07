using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForLoop : MonoBehaviour
{
    void Start()
    {
        int n = 5, sum = 0;

        for (int i = 1; i <= n; i++)
        {
            // sum = sum + i;
            sum += i;
        }

        //print("For" + " " + n + "," + sum);
    }
}
