using System;
using System.Collections.Generic;
using Assets.Classes;
using Assets.Scripts;
using UnityEngine;

[CreateAssetMenu(fileName = "IngredientData", menuName = "Scriptable Objects/IngredientData")]
public class IngredientData : ScriptableObject
{
    public Sprite sprite;
    public string ingredientName;

    [SerializeField] public List<RecipeComponent> recipes;

}
