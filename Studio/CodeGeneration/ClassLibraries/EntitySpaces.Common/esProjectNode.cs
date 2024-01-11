using System.Collections;
using System.Collections.Generic;
using EntitySpaces.MetadataEngine;
using EntitySpaces.CodeGenerator;

namespace EntitySpaces.Common
{
    public class EsProjectNode : IProjectNode
    {
        public bool IsFolder { get; set; } = true;

        public string Name { get; set; }
        public Template Template { get; set; }
        public Hashtable Input { get; set; }
        public ISettings Settings { get; set; }

        private List<IProjectNode> _children;
        public List<IProjectNode> Children 
        {
            get => _children ?? (_children = new List<IProjectNode>());
            set => _children = value;
        }
    }
}
