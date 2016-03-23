﻿using System;

/// <summary>
/// Permet de s'abonner à des delegate ayant pour prototype : delegate void function().
/// </summary>
/// <typeparam name="EnumerationType"></typeparam>
public class EventManagerParamsConstructionSquareArrayAndInt<EnumerationType> where EnumerationType : struct, IConvertible
{
    public delegate void Delegate(ConstructionSquare[] constructionSquares, int anInt);

    #region Fields
    protected Delegate[] events;
    #endregion

    #region Constructor
    public EventManagerParamsConstructionSquareArrayAndInt()
    {
        if (!typeof(EnumerationType).IsEnum)
            throw new ArgumentException("EnumerationType must be an enumerated type");

        this.events = new Delegate[EnumHelper.Count<EnumerationType>()];
    }
    #endregion

    #region Behaviour Methods
    /// <summary>
    /// Permet de récupérer l'event lié à l'énumération EnumerationType.
    /// </summary>
    /// <param name="enumeration"></param>
    /// <returns></returns>
    protected Delegate GetEvent(EnumerationType enumeration)
    {
        return this.events[EnumHelper.GetIndex<EnumerationType>(enumeration)];
    }

    /// <summary>
    /// S'abonne à l'action ayant pour identifiant un EnumerationType.
    /// </summary>
    /// <param name="enumeration"></param>
    /// <param name="action"></param>
    public void SubcribeToEvent(EnumerationType enumeration, Delegate action)
    {
        this.events[EnumHelper.GetIndex<EnumerationType>(enumeration)] += action;
    }

    /// <summary>
    /// Se désabonne d'une action ayant pour identifiant un EnumerationType
    /// </summary>
    /// <param name="enumeration"></param>
    /// <param name="action"></param>
    public void UnsubcribeToEvent(EnumerationType enumeration, Delegate action)
    {
        this.events[EnumHelper.GetIndex<EnumerationType>(enumeration)] -= action;
    }

    /// <summary>
    /// Appele les actions lié à l'identifiant EnumerationType.
    /// </summary>
    /// <param name="enumeration"></param>
    public void CallEvent(EnumerationType enumeration, ConstructionSquare[] constructionSquares, int anInt)
    {
        Delegate action = this.GetEvent(enumeration);

        if (null != action)
            action(constructionSquares, anInt);
    }
    #endregion
}