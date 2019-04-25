using System.Linq;
namespace UIFrame {
   using UnityEngine.UI;
   using UnityEngine;
   using Util;

   public class ComicsPage : MonoBehaviour {
      private Sprite[] numSprits;
      private Image _indexImage;

      private void Start() {
         numSprits = GetComponent<NumSprites>().numSprits;
         _indexImage = transform.Find("Index").Image();

      }

      public void ShowNum(int index) {
         if (index >= numSprits.Length) {
            Debug.LogError("index > numSprits Length");
            return;
         }
         _indexImage.sprite = numSprits[index];
      }
   }
}