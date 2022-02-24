using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    private void FixedUpdate()
    {
        // За счет данного действия осуществляется масшаб и подгон камеры
        transform.position = FieldCreation.CamPosition;
    }
}