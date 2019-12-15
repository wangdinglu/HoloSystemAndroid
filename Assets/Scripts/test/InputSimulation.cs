using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MixOne
{
    public class InputSimulation : MonoBehaviour
    {
        private ControlList cl;
        private Button bt;

        // Start is called before the first frame update
        void Start()
        {
            cl = GameObject.Find("StatusControl").GetComponent<ControlList>();
            bt = this.GetComponent<Button>();
            bt.onClick.AddListener(InputSim);
        }

        // Update is called once per frame
        public void InputSim()
        {
            cl.pushOperation("Touch:"+gameObject.name);
            //Debug.Log(gameObject.name);
        }
    }
}