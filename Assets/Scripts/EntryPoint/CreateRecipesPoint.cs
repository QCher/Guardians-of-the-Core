using Unity.Hierarchy;
using UnityEngine;
using VContainer.Unity;

namespace VContainer
{
    public class Recipe
    {
        public readonly string Name;
        public readonly string[] Items;

        public Recipe(string name, params string[] items)
        {
            Name = name;
            Items = items;
        }
    }

    public class PrintNameNodeHandler : HierarchyNodeTypeHandlerBase
    {
        public PrintNameNodeHandler(string name)
        {
            
        }
        protected override void Initialize()
        {
            base.Initialize();
        }
    }
    
    public class CreateRecipesPoint : IStartable
    {
        void IStartable.Start()
        {
            var item = new Hierarchy();
            
            var node1 = item.Add(item.Root);
            var node2 = item.Add(item.Root);
            var node3 = item.Add(node1);
            var node4 = item.Add(node1);
            var node5 = item.Add(node2);
            var node6 = item.Add(node5);
            var node7 = item.Add(node5);
            
            item.SetName(node1, "1");
            item.SetName(node2, "2");
            item.SetName(node3, "3");
            item.SetName(node4, "4");
            item.SetName(node5, "5");
            item.SetName(node6, "6");
            item.SetName(node7, "7");
            

            var path = item.GetPath(node7);
            
            Debug.Log(path);








        }
    }
}