﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundsDestructor : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
