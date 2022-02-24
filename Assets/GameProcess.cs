using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProcess : MonoBehaviour
{
    private RaycastHit2D _rayHit;

    private SpriteRenderer _main;

    private string _color;

    private float _deleteField = 2f;

    public void DeletObjects()
    {
        //���� ��� ������� ���� SpriteRenderer
        SpriteRenderer[] sprite = FindObjectsOfType<SpriteRenderer>();

        //������� ������ ��������� ��� ����� �������, ��� �� ���������� �� �� ����������(�� 3 � �����)
        SpriteRenderer[] deletedSprite = new SpriteRenderer[99];
        int i = 0;

        foreach (SpriteRenderer item in sprite)
        {
            //�������� ������ �� ������� ��������
            if (Vector2.Distance(_rayHit.transform.position, item.transform.position) < 0.1f)
            {
                _main = item;
                _color = _main.color.ToString();
            }

            // ������ ����������� �� ������� 
            if (Vector2.Distance(_rayHit.transform.position, item.transform.position) < Sizing.scale * _deleteField)
            {
                string a = item.color.ToString();

                // ������ ����������� �� �����, ���������� ��� � ������ String
                if (_color == a)
                {
                    // ��������� ��� �������� � ������ ��� ����� �������
                    deletedSprite[i] = item;
                    i++;

                }
            }
        }

        //������� ������
        foreach (var a in deletedSprite)
        {
            if (i >= 3)
            { Destroy(a); 
            }
        }
    }
    void Update()
    {
        // �� ������� ���� �������� ������(��������)
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 CurMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            _rayHit = Physics2D.Raycast(CurMousePos, Vector2.zero);

            if (_rayHit.transform != null)
            {
                DeletObjects();
            }
        }
    }
}