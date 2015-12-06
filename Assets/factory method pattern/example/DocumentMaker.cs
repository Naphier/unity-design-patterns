using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using NG.factory_method_pattern.example;

public class DocumentMaker : MonoBehaviour
{
    public GameObject textMeshPrefab;
    public GameObject paperPrefab;

    private List<Document> documents = new List<Document>();

    void Start()
    {
        documents.Add(new CharacterSheet(textMeshPrefab, paperPrefab));
        documents.Add(new Spellbook(textMeshPrefab, paperPrefab));
        StartCoroutine(DisplayDocuments());
    }

    IEnumerator DisplayDocuments()
    {
        while (true)
        {
            foreach (Document d in documents)
            {
                d.documentHolder.SetActive(false);
            }

            foreach (Document d in documents)
            {
                d.documentHolder.SetActive(true);
                foreach (Page p in d.pages)
                {
                    p.page.SetActive(true);
                }
                yield return new WaitForSeconds(2f);

                for (int i = 1; i < d.pages.Count; i++)
                {
                    yield return new WaitForSeconds(1f);
                    d.pages[i - 1].page.SetActive(false);

                }

                yield return new WaitForSeconds(1f);
                d.documentHolder.SetActive(false);

            }

        }
    }
}
