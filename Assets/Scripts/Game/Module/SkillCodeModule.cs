using UnityEngine;

namespace Module {
    /// <summary>
    /// 任务技能编码功能模块
    /// </summary>
    public class SkillCodeModule {
        /*
        
         public int GetCurrentSkillCode(SkillButton button, int currentCode)

        /// <summary>
        /// 获取int类型的技能编码
        /// </summary>
        /// <param name="skillName"></param>
        /// <param name="prefix"></param>
        /// <param name="posfix"></param>
        /// <returns></returns>
        public int GetSkillCode(string skillName,string prefix,string posfix)


         /// <summary>
        /// 获取XXOO类型的技能编码
        /// </summary>
        /// <returns></returns>
        public string GetCodeString(int code)

        
           //转换string编码到int 从xxoo类型转换成int类型编码
        private int ConvertStringToInt(string codeString)

      //转换int编码到string 转换成xxoo类型的编码
        private string ConvertIntToString(int code)
        
         */
         
        public int GetCurrentSkillCode(SkillButton button, int currentCode) {
            int code = (int) button;
            if (currentCode < 0) {
                Debug.LogError("SkillCode不能小于0");
            } else if (currentCode == 0) {
                currentCode = code;
            } else {
                currentCode = currentCode * 10 + code;
            }

            return currentCode;
        }


        //转换int编码到string 转换成xxoo类型的编码
        // private string ConvertIntToString(int code){
            

        // }
    }

    public enum SkillButton {
        X = 1,
        O = 2,
    }

}