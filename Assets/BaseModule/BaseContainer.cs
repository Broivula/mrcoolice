using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RelationsTerm { Bad, OK, Good, Excellent }

public class BaseContainer : MonoBehaviour {

    [SerializeField]
    private string baseName;
    private RelationsTerm relationsTerm;

    [SerializeField]
    private string baseCaptainName;

    [SerializeField]
    private int relationsWithYou = 0;
    [SerializeField]
    private int suppliesInBase = 0;

    [SerializeField]
    private AudioClip baseAudio;

    public string GetRelationsStatus()
    {
        switch(CalculateRelations())
        {
            case RelationsTerm.Bad:
                return "bad";
            case RelationsTerm.OK:
                return "OK";
            case RelationsTerm.Good:
                return "good";
            case RelationsTerm.Excellent:
                return "excellent";
        }

        return "if you see this message something's gone very wrong";
    }

    public RelationsTerm CalculateRelations()
    {
        if(relationsWithYou >= 20)
        {
            return RelationsTerm.Excellent;
        }

        else if(relationsWithYou >= 15)
        {
            return RelationsTerm.Good;
        }

        else if(relationsWithYou >= 10)
        {
            return RelationsTerm.OK;
        }

        return RelationsTerm.Bad;
    }

    public int GetSuppliesStatus()
    {
        return suppliesInBase;
    }

    public string GetBaseCaptainName()
    {
        return baseCaptainName;
    }
}
