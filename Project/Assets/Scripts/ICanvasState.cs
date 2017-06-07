using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICanvasState
{
    // bool isSelect { get; set; }
    void ChangeNormal();
    void ChangePressed();
}
