using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Spellcaster : MonoBehaviour
{
    public static event Action fireCast;
    public static event Action waterCast;
    public void CastFireSpell()
    {
        fireCast?.Invoke();
    }
    public void CastWaterSpell()
    {
        waterCast?.Invoke();
    }
}
