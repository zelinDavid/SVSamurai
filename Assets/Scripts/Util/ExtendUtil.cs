using UnityEngine;



namespace Util
{
    public static class ExtendUtil
    {
        
        public static RectTransform RectTransform(this Transform transform){
           var rect = transform.GetComponent<RectTransform>();
            if (rect)
            {
                return rect;
            }
            Debug.LogError("can not find RectTransfomr");
            return null;
        }
    }
}