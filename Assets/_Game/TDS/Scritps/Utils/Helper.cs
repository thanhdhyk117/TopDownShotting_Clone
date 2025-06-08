using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public static class Helper 
{
   public static float GetUpdateFormula(int level)
    {
        return Mathf.Abs(level / 2 - Mathf.PI / 10);
    }
}
