using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MixOne
{
    public class LayerSystem : MonoBehaviour
    {
        private static Dictionary<string, GameObject> Layers;
        private bool aiming;


        private List<string> LayerList = new List<string>{
            "Layers","SystemLayer","InfoLayer","VerticalLayer","StaticLayer","HorizonLayer","Background"
        };

        private void Awake()
        {
            Layers = new Dictionary<string, GameObject>();

            foreach(string layer in LayerList){
                GameObject item = GameObject.Find(layer) as GameObject;
               
                Layers.Add(layer, item);
            }
        }
        
        public GameObject GetLayer(string layer)
        {
            return Layers[layer];
        }

        public void RotateDynamicWindows(GameObject layer, float angle)
        {
            float time = 0.5f;
            aiming = true;
            StartCoroutine(RotateWindow(layer, angle / time * Time.deltaTime, time));
            StopCoroutine(RotateWindow(layer, angle / time * Time.deltaTime, time));
        }

        IEnumerator RotateWindow(GameObject window, float angle, float time)
        {
            for (float timer = time; timer >= 0; timer -= Time.deltaTime)
            {
                window.transform.RotateAround(Vector3.zero, Vector3.up, angle);
                yield return 0;
            }
            //Debug.Log("Finish rotation");
        }

    }
}