using UnityEngine;

namespace UIFrame
{
    public class sampleTest : MonoBehaviour     
    {
        public void Start()         
        {
           Invoke("Test", 1);
        }

        void Test(){
            Transform button = transform.Find("Continue");
            Debug.Log(button);
            button.localScale = Vector3.one * 2;

        }
    }
}
