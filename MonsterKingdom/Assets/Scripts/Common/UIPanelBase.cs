using System;
using UnityEngine;

namespace Game.Common
{
    public class UIPanelBase : MonoBehaviour
    {
        public GameObject selfGameObject;
        private void Awake()
        {
            selfGameObject = this.gameObject;
        }
    }
}