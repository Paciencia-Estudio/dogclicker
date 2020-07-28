using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _InterfaceButtonManager : MonoBehaviour
{
    [Header ("Configs")]
    public Click clickM;
    public FirebaseTestRealtimeDatabse firebaseTest;
    
    public void _SavePointsOnDatabase()
    {
        firebaseTest.EnviarParaRTD(clickM.Points);
    }

    public void _GetPointsFromDatabase()
    {
        firebaseTest.PegarRTD();
    }
}
