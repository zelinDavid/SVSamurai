using Module;
using UnityEngine;

namespace Game.Service {

    public interface ISkillCodeService : IInitService {
        int GetCurrentSkillcode(InputButton button, int currentCode);
    }

    //TODO:待实现
    public class SkillCodeService : ISkillCodeService {
        private SkillCodeModule _skillCode;
        public int GetCurrentSkillcode(InputButton button, int currentCode) {
            // Debug.Log("GetCurrentSkillcode before:" + currentCode);
            if (button == InputButton.ATTACK_O) {
                currentCode = _skillCode.GetCurrentSkillCode(SkillButton.O, currentCode);
            } else if (button == InputButton.ATTACK_X) {
                currentCode = _skillCode.GetCurrentSkillCode(SkillButton.X, currentCode);
            }
            // Debug.Log("GetCurrentSkillcode ret:" + currentCode);
            return currentCode;
 
        }

        public int GetPriority() {
            return 0;
        }

        public void Init(Contexts contexts) {
            contexts.service.SetGameServiceSkillCodeService(this);
            _skillCode = new SkillCodeModule();
        }
    }
}