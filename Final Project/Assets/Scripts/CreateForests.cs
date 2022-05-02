using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateForests : MonoBehaviour
{
    public int forestSize = 25;

    public int elementSpacing = 3;

    public Element[] elements;

    private void Start()
    {
        for (int x = 0; x < forestSize; x += elementSpacing)
        {
            for (int z = 0; z < forestSize; z += elementSpacing)
            {
                for(int i = 0; i < elements.Length; i++){
                    Element ele = elements[i];

                    if(ele.CanPlace()){

                        Vector3 position = new Vector3(x, 0f, z);
                        Vector3 offset = new Vector3(Random.Range(-0.75f, 0.75f), 0f, Random.Range(-0.75f, 0.75f));
                        Vector3 rotation = new Vector3(Random.Range(0, 5f), Random.Range(0, 5f), Random.Range(0, 5f));
                        Vector3 scale = Vector3.one * Random.Range(0.75f, 1.2f);

                        GameObject newElement = Instantiate(ele.GetRandom());
                        newElement.transform.SetParent(transform);
                        newElement.transform.position = position + offset;
                        newElement.transform.eulerAngles = rotation;
                        if(newElement.tag != ("Portal")){
                            newElement.transform.localScale = scale;
                        }else{
                            elements[i] = elements[1];
                        }
                        break;
                    }
                }
            }
        }
    }

    [System.Serializable]
    public class Element
    {
        public string name;

        [Range(1, 10)]
        public int density;

        public GameObject[] prefabs;

        public bool CanPlace(){
            if(Random.Range(0, 10) < density){
                return true;
            }else{
                return false;
            }
        }

        public GameObject GetRandom(){
            return prefabs[Random.Range(0, prefabs.Length)];
        }


    }
}
