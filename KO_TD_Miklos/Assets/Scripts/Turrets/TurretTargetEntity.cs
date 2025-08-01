
using System.Collections.Generic;
using UnityEngine;

public class TurretTargetEntity
{
    public TurretType type;
    public List<GameObject> listOfTargets;
    public int maxTargets;

    public TurretTargetEntity(TurretType _type, List<GameObject> _listOfTargets, int _maxTargets)
    {
        this.type = _type;
        this.listOfTargets = _listOfTargets;
        this.maxTargets = _maxTargets;
    }
}