using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyInterfaces
{
    public interface IColor
    {
        void ChangeColor();
        void ResetColor();
    }


    public interface IMove
    {
        void Move();
    }

    public interface IJump
    {
        void Jump();
    }
}
