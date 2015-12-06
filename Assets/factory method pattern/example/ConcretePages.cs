using UnityEngine;

namespace NG.factory_method_pattern.example
{
    public class Contents : Page
    {
        public Contents(string text, GameObject textMesh, GameObject paper, int pageNum) : base(text, textMesh, paper, pageNum)
        {
            if (page != null)
                page.name = this.GetType().Name;
        }
    }

    public class Stats : Page
    {
        public Stats(string text, GameObject textMesh, GameObject paper, int pageNum) : base(text, textMesh, paper, pageNum)
        {
            if (page != null)
                page.name = this.GetType().Name;
        }
    }

    public class Skills : Page
    {
        public Skills(string text, GameObject textMesh, GameObject paper, int pageNum) : base(text, textMesh, paper, pageNum)
        {
            if (page != null)
                page.name = this.GetType().Name;
        }
    }

    public class EarthSpells : Page
    {
        public EarthSpells(string text, GameObject textMesh, GameObject paper, int pageNum) : base(text, textMesh, paper, pageNum)
        {
            if (page != null)
                page.name = this.GetType().Name;
        }
    }

    public class WindSpells : Page
    {
        public WindSpells(string text, GameObject textMesh, GameObject paper, int pageNum) : base(text, textMesh, paper, pageNum)
        {
            if (page != null)
                page.name = this.GetType().Name;
        }
    }

    public class FireSpells : Page
    {
        public FireSpells(string text, GameObject textMesh, GameObject paper, int pageNum) : base(text, textMesh, paper, pageNum)
        {
            if (page != null)
                page.name = this.GetType().Name;
        }
    }

    public class WaterSpells : Page
    {
        public WaterSpells(string text, GameObject textMesh, GameObject paper, int pageNum) : base(text, textMesh, paper, pageNum)
        {
            if (page != null)
                page.name = this.GetType().Name;
        }
    }
}
