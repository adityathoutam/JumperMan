using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRJMP
{
    public class SpawnManager : MonoBehaviour
    {
        public static SpawnManager instance;
        [SerializeField]
        private PlatformBehaviour[] platforms;
        [SerializeField]
        
        private int numberOfPlatformsToPlace = 3;
        [SerializeField]
        private float minDistanceForGap = 4.0f;
        [SerializeField]
        private float maxDistanceForGap = 9.0f;
        public List<int> currentlyPlacedPlatformIndices;
        private void Awake()
        {
            if (instance == null)
                instance = this;
            else
                Destroy(gameObject);
        }
        private void Start()
        {
            currentlyPlacedPlatformIndices = new List<int>();
            for (int i = 0; i < platforms.Length; i++)
            {
                platforms[i].indexInList = i;
            }
            platforms[0].transform.position = new Vector3(0, -1, 0);
            currentlyPlacedPlatformIndices.Add(0);
            Spawn();
            Spawn();
            
        }
        void Spawn()
        {
            bool success = false;
            while (success != true)
            {
                int tempIndex = Random.Range(0, platforms.Length);
                if (!currentlyPlacedPlatformIndices.Exists(ele => ele == tempIndex))
                {
                    PlatformBehaviour temp = platforms[currentlyPlacedPlatformIndices[currentlyPlacedPlatformIndices.Count - 1]];
                    float prevObjMaxZ = temp.transform.position.z + (temp.transform.localScale.z / 2.0f);
                    float zOffset = prevObjMaxZ;
                    zOffset += Random.Range(minDistanceForGap, maxDistanceForGap);
                    currentlyPlacedPlatformIndices.Add(tempIndex);
                    Vector3 newPlacementPos = new Vector3(0, -1, zOffset + (platforms[tempIndex].transform.localScale.z / 2.0f));
                    platforms[tempIndex].transform.position = newPlacementPos;
                    success = true;
                    float nextObjMaxZ = platforms[tempIndex].transform.position.z + (platforms[tempIndex].transform.localScale.z / 2.0f);                    
                }
            }
        }
        public void RemoveExistingPlatform(PlatformBehaviour platform)
        {
            platform.transform.position = Vector3.one * 200;
            currentlyPlacedPlatformIndices.Remove(platform.indexInList);
            Spawn();
        }
    }
}
