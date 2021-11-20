using UnityEngine;

namespace _TestObject
{
    
    public static class Tools
    {

        public static bool IsInLayerMask(int layer, LayerMask layermask)
        {
            return layermask == (layermask | (1 << layer));
        }
    }
}