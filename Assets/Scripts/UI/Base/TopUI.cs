using UnityEngine;
using Const;

namespace UIFrame
{
    public abstract class TopUI : UIBase     
    {
        public override UILayer GetUiLayer(){
            return UILayer.OVER_LAY;
        }
    }
}
