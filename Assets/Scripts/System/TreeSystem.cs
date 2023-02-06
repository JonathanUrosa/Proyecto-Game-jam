using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TreeSystem : MonoBehaviour
{
    [Tooltip("cuantos puntos de vida regenera UN SOLO ARBOL a la raiz por minuto")]
    public int regenerationRate = 7;
    public bool autoSearch;
    public List<Damageable> trees, roots;
    int remainingTrees=0;
    private void Awake()
    {
        if (autoSearch)
        {
            var dmgs = transform.GetComponentsInChildren<Damageable>(true);
            foreach (Damageable item in dmgs)
            {
               // Debug.Log(item.name);
                if (item.gameObject.CompareTag("Tree"))
                    trees.Add(item);
                if (item.gameObject.CompareTag("Root"))
                    roots.Add(item);
            }
        }
        foreach(Damageable tree in trees)
        {
            if (tree.endurance > 0)
            { 
                remainingTrees++;
                tree.OnEventDestroy.AddListener(() => remainingTrees--) ;            }
        }
        foreach (Damageable root in roots)
        {
            StartCoroutine(RegenCR(root));
        }
    }

 
    IEnumerator RegenCR(Damageable root)
    {
        
        while (root.endurance > 0)
        {
            if((root.endurance<root.totalEndurance)&&remainingTrees>0)
            {
                yield return new WaitForSeconds(60/regenerationRate );
                root.endurance = Math.Clamp(root.endurance+ remainingTrees, 0,root.totalEndurance-1);
                TreeHealthBar.UpdateSlider();
            }
            yield return new WaitForEndOfFrame();
        }
        yield break;
    }
}
