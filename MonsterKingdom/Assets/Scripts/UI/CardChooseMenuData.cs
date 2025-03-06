using System;
using UnityEngine;

namespace UI
{
    public class CardChooseMenuData : UIData
    {
        public Vector3 pos;
        public int index;
        public Action<string> onMonsterChoose;
    }
}