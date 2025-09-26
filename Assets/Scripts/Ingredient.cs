using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class Ingredient : MonoBehaviour, ISelectable
    {
        public bool isSelected { get; set; }
    }
}
