using UnityEngine;
using Const;

namespace UIFrame
{
    public abstract class OverlayUI : UIBase     
    {
        public override UILayer GetUiLayer(){
            return UILayer.OVER_LAY;
        }
    }
}
