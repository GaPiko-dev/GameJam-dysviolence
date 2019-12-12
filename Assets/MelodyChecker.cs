using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelodyChecker : MonoBehaviour
{
    public List<SonArbre1> listeAFaire;
    public int index = 0;
    public void TryPlaySound(SonArbre1 arbreToTry)
    {
      //  Win();
        if (listeAFaire[index] == arbreToTry)
        {
            index+=1;
            if (index >= listeAFaire.Count)
            {
                Win();
            }
        }
        else
        {
            index = 0;
        }
    }

    private void Win()
    {
        //Code quand on gagne
    }
}
