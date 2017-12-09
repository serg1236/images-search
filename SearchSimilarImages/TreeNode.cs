using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SearchSimilarImages
{
    public abstract class TreeNode
    {
        public string Id { set; get; }
        public string GroupRoot { set; get; }
        public virtual bool Equals(TreeNode node)
        {
            return ReferenceEquals(this, node);
        }
    }

    class LeafNode : TreeNode
    {
        public string ImageName { set; get; }

        public LeafNode(string imageName)
        {
            ImageName = imageName;
            Id = imageName;
            GroupRoot = "";
        }

        public override bool Equals(TreeNode node)
        {
            return node is LeafNode ?  (this.ImageName == ((LeafNode)node).ImageName) : base.Equals(node);
        }

        public override bool Equals(object node)
        {
            return node is LeafNode ? (this.ImageName == ((LeafNode)node).ImageName) : base.Equals(node);
        }

        public override int GetHashCode()
        {
            return ImageName.GetHashCode();
        }

    }

    class InnerNode : TreeNode
    {
        public TreeNode LeftNode { set; get; }
        public TreeNode RightNode { set; get; }

        public InnerNode(TreeNode leftNode, TreeNode rightNode)
        {
            LeftNode = leftNode;
            RightNode = rightNode;
            Id = leftNode.Id + "_" + rightNode.Id;
            GroupRoot = "";
        }

        public override bool Equals(TreeNode node)
        {
            return node is InnerNode ? (this.LeftNode == ((InnerNode)node).LeftNode && this.RightNode == ((InnerNode)node).RightNode) ||
                (this.LeftNode == ((InnerNode)node).RightNode && this.RightNode == ((InnerNode)node).LeftNode) : base.Equals(node);
        }

        public override bool Equals(object node)
        {
            return node is InnerNode ? (this.LeftNode == ((InnerNode)node).LeftNode && this.RightNode == ((InnerNode)node).RightNode) ||
                (this.LeftNode == ((InnerNode)node).RightNode && this.RightNode == ((InnerNode)node).LeftNode) : base.Equals(node);
        }

        public override int GetHashCode()
        {
            return LeftNode.GetHashCode() + RightNode.GetHashCode();
        }
    }

}
