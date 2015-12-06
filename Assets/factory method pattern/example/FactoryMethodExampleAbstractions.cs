using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace NG.factory_method_pattern.example
{
    public class Page
    {
        public GameObject page;
        public GameObject paper;
        public GameObject textMesh;
        private TextMesh _tm;


        public Page(string text , GameObject textMesh , GameObject paper, int pageNum)
        {
            this.page = new GameObject("page");

            this.textMesh = GameObject.Instantiate(textMesh, Vector3.zero, Quaternion.identity) as GameObject;
            this.textMesh.transform.SetParent(this.page.transform);
            this.textMesh.transform.localPosition = new Vector3(-4.7f, 4.7f, -0.1f);
            _tm = this.textMesh.GetComponent<TextMesh>();
            if (_tm != null)
                _tm.text = text;

            this.paper = GameObject.Instantiate(paper, Vector3.zero, Quaternion.identity) as GameObject;
            this.paper.transform.SetParent(this.page.transform);
            this.paper.transform.eulerAngles = new Vector3(-90f, 0, 0);

            this.page.transform.position += Vector3.forward * pageNum / 5f;
        }

        public void SetPageContents(string text)
        {
            if (_tm != null)
                _tm.text = text;
        }

        public void AddToPageContents(string text)
        {
            if (_tm != null)
                _tm.text += text;
        }

        public string GetPageText()
        {
            string text = "";

            if (_tm != null)
            {
                text = _tm.text;
            }

            return text;
        }
    }


    abstract class Document
    {
        protected List<Page> _pages = new List<Page>();
        public GameObject documentHolder { get; protected set; }

        public Document(GameObject textMesh, GameObject paper)
        {
            documentHolder = new GameObject();
            this.CreatePages(textMesh, paper);
        }

        public List<Page> pages
        {
            get { return _pages; }
        }

        public abstract void CreatePages(GameObject textMesh, GameObject paper);

        protected void SetTableOfContentsList(Page contents)
        {
            foreach (Page page in _pages)
            {
                if (page != contents)
                    contents.AddToPageContents("\n" + page.GetType().Name);
            }
        }
    }

    
}
