using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Sizing;

public class FieldCreation : MonoBehaviour
{

    public static int width;
    public static int height;
    public static int color;

    public GameObject cube;
    public Transform start;

    private Vector3 _start = new Vector3(-5.8f, 3.3f, 0);
    public static Vector3 CamPosition = new Vector3(0, 0, -10);

    public InputField widthSize;
    public InputField heightSize;
    public InputField Color;

    [SerializeField] private Sizing Sizing;

    //Преобразуем данные с InputField-ов
    public void Parsing()
    {
        width = int.Parse(widthSize.text);
        if (width > 50)
        {
            width = 50;
            widthSize.text = "50";
        }
        if (width < 1)
        {
            width = 1;
            widthSize.text = "10";
        }

        height = int.Parse(heightSize.text);
        if (height > 50)
        {
            height = 50;
            heightSize.text = "50";
        }
        if (height < 1)
        {
            height = 1;
            heightSize.text = "10";
        }

        color = int.Parse(Color.text);
        if (color > 5)
        {
            color = 5;
            Color.text = "5";
        }
        if (color < 2)
        {
            color = 2;
            Color.text = "2";
        }
    }


    public void Creation()
    {
        _start = new Vector3(-5.8f, 3.3f, 0);

        //Удаляем старые объеты
        GameObject[] Old = FindObjectsOfType<GameObject>();
        foreach (GameObject item in Old)
        {
            if (item.tag == "Player")
            {
                Destroy(item);
            }
        }

        //Созлаем новые объекты
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                RandomColor();
                Instantiate(cube, _start, Quaternion.identity);
                
                if (x == (width / 2)-1 && y == (height / 2)-1)
                {
                    CamPosition.x = _start.x;
                    CamPosition.y = _start.y;
                }
                _start.y = _start.y - (cube.transform.localScale.y + 0.05f);
            }
            _start.x = _start.x + (cube.transform.localScale.x + 0.05f);
            _start.y = 3.3f;
        }
    }

    //Выбираем случайны цвет кубу
    private void RandomColor()
    {
        int randomNumber = Random.Range(0, color);
        if (randomNumber == 1)
        {
            cube.GetComponent<SpriteRenderer>().color = UnityEngine.Color.green;
        }
        if (randomNumber == 2)
        {
            cube.GetComponent<SpriteRenderer>().color = UnityEngine.Color.yellow;
        }
        if (randomNumber == 3)
        {
            cube.GetComponent<SpriteRenderer>().color = UnityEngine.Color.red;
        }
        if (randomNumber == 4)
        {
            cube.GetComponent<SpriteRenderer>().color = UnityEngine.Color.blue;
        }
        if (randomNumber == 0)
        {
            cube.GetComponent<SpriteRenderer>().color = UnityEngine.Color.cyan;
        }
    }

    private void Start()
    {
        Parsing();

        Sizing.Sized();
        
        Creation();
    }
}
