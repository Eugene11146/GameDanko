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
        //Ищем все обьекты типы SpriteRenderer
        SpriteRenderer[] sprite = FindObjectsOfType<SpriteRenderer>();

        //Создаем массив жлементов что будем удалять, что бы ограничить их по количеству(от 3 и более)
        SpriteRenderer[] deletedSprite = new SpriteRenderer[99];
        int i = 0;

        foreach (SpriteRenderer item in sprite)
        {
            //Выбираем спрайт на который нажимали
            if (Vector2.Distance(_rayHit.transform.position, item.transform.position) < 0.1f)
            {
                _main = item;
                _color = _main.color.ToString();
            }

            // Задаем ограничения по области 
            if (Vector2.Distance(_rayHit.transform.position, item.transform.position) < Sizing.scale * _deleteField)
            {
                string a = item.color.ToString();

                // Задаем ограничения по цвету, преобразуя его в формат String
                if (_color == a)
                {
                    // Добавляем все элементы в массив что будем удалять
                    deletedSprite[i] = item;
                    i++;

                }
            }
        }

        //Удаляем массив
        foreach (var a in deletedSprite)
        {
            if (i >= 3)
            { Destroy(a); 
            }
        }
    }
    void Update()
    {
        // По наэатию мыши выбираем спрайт(соновной)
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