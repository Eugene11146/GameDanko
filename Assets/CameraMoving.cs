using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    private void FixedUpdate()
    {
        // �� ���� ������� �������� �������������� ������ � ������ ������
        transform.position = FieldCreation.CamPosition;
    }
}