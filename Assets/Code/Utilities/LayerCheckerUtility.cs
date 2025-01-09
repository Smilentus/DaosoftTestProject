using UnityEngine;

namespace Dimasyechka
{
    public static class LayerCheckerUtility
    {
        public static bool IsInLayer(GameObject gameObject, LayerMask layerMask)
        {
            return ((1 << gameObject.layer) & layerMask) != 0;
        }
    }
}
