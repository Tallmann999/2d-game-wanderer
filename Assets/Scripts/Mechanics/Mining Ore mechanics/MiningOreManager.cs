using System.Collections.Generic;
using UnityEngine;

public class MiningOreManager : MonoBehaviour
{
    // возможно нужен словарь для работы с разными разрушаемыми обьектами и каждыми уникальными их спрайтами
    //[SerializeField] private Dictionary<DestructibleObject, Sprite[]> _desObject;
    [SerializeField] private DestructibleObject[] _destructibleObjects;
    [SerializeField] private Sprite[] _spriteDestructible;
    [SerializeField] private int _destructibleObjectCount;

    // Общий класс который отвечает за
    // количество появляемых кучек
    // Анимация измениение спрайтов
    // колличество попыток и уменьшения выносливости
    
}
