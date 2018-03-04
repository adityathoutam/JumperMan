using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRJMP
{
    public class PlatformBehaviour : MonoBehaviour
    {
        public int indexInList = -1;
        private Transform playerTransform;
        public Material rainbow;
        private float colorthing;
        private void Start()
        {
            playerTransform = Camera.main.transform;
        }
        private void Update()
        {
            rainbow.color = ColorChooser();

            if (playerTransform.position.z-20f > transform.position.z + (transform.localScale.z / 2.0f))
                SpawnManager.instance.RemoveExistingPlatform(this);
        }
        Color ColorChooser()
        {
            
            Color a = Color.HSVToRGB(colorthing += Time.deltaTime*Random.Range(1.0f,2.0f), 1, 1);
            if (colorthing > 1)
                colorthing = 0;
            return a;
        }
    }
}
