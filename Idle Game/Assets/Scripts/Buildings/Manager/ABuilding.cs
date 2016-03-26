﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Paramètre de placement du bâtiment.
/// </summary>
public abstract class ABuilding : MonoBehaviour
{
    #region Fields
    /// <summary>
    /// Type de bâtiment : construction, décors, autre ??e
    /// </summary>
    [SerializeField]
    private EBuildingCategory buildingCategory;
    [SerializeField]
    private string buildingName;
    private ConstructionSquare constructionSquareReference;
    public int BuildingLevel { get; protected set; }
    #endregion

    #region Properties
    public EBuildingCategory BuildingCategory
    {
        get { return buildingCategory; }
        private set { buildingCategory = value; }
    }

    public string BuildingName
    {
        get { return buildingName; }
        set { buildingName = value; }
    }

    public ConstructionSquare ConstructionSquareReference
    {
        get { return constructionSquareReference; }
        set { constructionSquareReference = value; }
    }
    #endregion
}
