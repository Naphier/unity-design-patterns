using UnityEngine;

namespace NG.factory_method_pattern.example
{
    class CharacterSheet : Document
    {
        public CharacterSheet(GameObject textMesh, GameObject paper) : base(textMesh, paper)
        {
            documentHolder.name = this.GetType().Name;
        }


        public override void CreatePages(GameObject textMesh, GameObject paper)
        {
            int pageNum = 1;
            Page p = new Contents("Table of Contents", textMesh, paper, pageNum++);
            Page contents = p;
            p.page.transform.SetParent(documentHolder.transform);
            _pages.Add(p);
            p = new Stats("Character Stats", textMesh, paper, pageNum++);
            p.page.transform.SetParent(documentHolder.transform);
            _pages.Add(p);
            p = new Skills("Character Skills", textMesh, paper, pageNum++);
            p.page.transform.SetParent(documentHolder.transform);
            _pages.Add(p);

            SetTableOfContentsList(contents);
        }
    }

    class Spellbook : Document
    {
        public Spellbook(GameObject textMesh, GameObject paper) : base(textMesh, paper)
        {
            documentHolder.name = this.GetType().Name;
        }


        public override void CreatePages(GameObject textMesh, GameObject paper)
        {
            int pageNum = 1;
            Page p = new Contents("Table of Contents", textMesh, paper, pageNum++);
            Page contents = p;
            p.page.transform.SetParent(documentHolder.transform);
            _pages.Add(p);
            p = new EarthSpells("Earth", textMesh, paper, pageNum++);
            p.page.transform.SetParent(documentHolder.transform);
            _pages.Add(p);
            p = new WindSpells("Wind", textMesh, paper, pageNum++);
            p.page.transform.SetParent(documentHolder.transform);
            _pages.Add(p);
            p = new FireSpells("Fire", textMesh, paper, pageNum++);
            p.page.transform.SetParent(documentHolder.transform);
            _pages.Add(p);
            p = new WaterSpells("Water", textMesh, paper, pageNum++);
            p.page.transform.SetParent(documentHolder.transform);
            _pages.Add(p);

            SetTableOfContentsList(contents);
        }
    }
}
