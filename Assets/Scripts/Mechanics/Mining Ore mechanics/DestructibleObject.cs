using System;
using UnityEngine;

public class DestructibleObject : MonoBehaviour
{
    [SerializeField] private Sprite[] _animatedSprite;

    private void Awake()
    {
        InitSprite();
    }

    private void InitSprite()
    {
        foreach (var sprite in _animatedSprite)
        {

        }
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {

        }
    }


    //Отвечает за выпадение предметов
    //Колличество выпадания предметов по типам
    //Колличество выпадания предметов всего
    //Качество выпадание предметов 

}
