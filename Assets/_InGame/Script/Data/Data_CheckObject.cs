using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Data_CheckObject 
{
    public static List<ObjectStatus> _objectLists = new List<ObjectStatus>()
    {
        ObjectStatus.Fine,
        ObjectStatus.Defect_PartsLoss,
        ObjectStatus.Defect_Cracked
 
    };

}


