using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SearchSimilarImages
{
    public class ClassificationUtil
    {
        public static List<List<string>> Classify(Dictionary<string, Dictionary<string, double>> GridData, ClassificationMode mode, int groupsCount)
        {
            var treeRelations = convertToNodes(GridData);
            while (treeRelations.Keys.Count > groupsCount)
            {
                FindAndUnite(treeRelations, mode);
            }
            return ExtractGroups(treeRelations);
        }

        public static List<Tuple<string, TreeNode>> ExtractTree(Dictionary<string, Dictionary<string, double>> GridData, ClassificationMode mode, int groupsCount)
        {
            var treeRelations = convertToNodes(GridData);
            var tree =  new List<Tuple<string, TreeNode>>();
            while (treeRelations.Keys.Count > groupsCount)
            {
                FindAndUnite(treeRelations, mode);
            }
            //mark root nodes
            int i=1;
            foreach (var node in treeRelations.Keys)
            {
                node.GroupRoot = "Група" + i++;
            }
            while (treeRelations.Keys.Count > 1)
            {
                FindAndUnite(treeRelations, mode);
            }
            addToTree(treeRelations.Keys.First(), null, tree);
            return tree;
        }

        private static void addToTree(TreeNode node, TreeNode parent,List<Tuple<string, TreeNode>> tree) {
            if(parent == null) {
                tree.Add(new Tuple<string, TreeNode>("", node));
            } else {
                tree.Add(new Tuple<string, TreeNode>(parent.Id, node));
            }
            if(node is InnerNode) {
                InnerNode iNode = (InnerNode)node;
                addToTree(iNode.LeftNode, iNode, tree);
                addToTree(iNode.RightNode, iNode, tree);
            }
        }

        private static void FindAndUnite(Dictionary<TreeNode, Dictionary<TreeNode, double>> treeRelations, ClassificationMode mode)
        {
            TreeNode node1 = null;
            TreeNode node2 = null;
            double relation = double.MinValue;
            foreach (TreeNode key1 in treeRelations.Keys)
            {
                var row = treeRelations.Get(key1);
                foreach (TreeNode key2 in row.Keys)
                {
                    if (!key1.Equals(key2))
                    {
                        double inner = row.Get(key2);
                        double outer = row.Where(x => !x.Key.Equals(key2)).Sum(x => x.Value) +
                           treeRelations.First(x => x.Key.Equals(key2)).Value
                           .Where(x => !x.Key.Equals(key1)).Sum(x => x.Value);
                        double currentRelation = mode == ClassificationMode.INNER ? -inner :
                            mode == ClassificationMode.OUTER ? outer : outer - inner;
                        if ((node1 == null && node2 == null) || currentRelation > relation)
                        {
                            node1 = key1;
                            node2 = key2;
                            relation = currentRelation;
                        }
                    }
                }
            }
            ReplaceNode(node1, node2, treeRelations, mode);
        }

        private static void ReplaceNode(TreeNode node1, TreeNode node2, Dictionary<TreeNode, Dictionary<TreeNode, double>> data, ClassificationMode mode)
        {
            var row1 = data.GetEquals(node1);
            var row2 = data.GetEquals(node2);

            var newNode = new InnerNode(node1, node2);

            var newRow = new Dictionary<TreeNode, double>();
            newRow.Add(newNode, 0.0);
            //filling new row
            foreach (TreeNode key in row1.Keys)
            {
                if (!key.Equals(node1) && !key.Equals(node2))
                {
                    double relation = Math.Sqrt((Math.Pow(row1.GetEquals(key), 2.0) + Math.Pow(row2.GetEquals(key), 2.0)) / 2.0);
                    newRow.Add(key, relation);
                }
            }
            //removing old rows
            data.Remove(data.First(x => x.Key.Equals(node1)).Key);
            data.Remove(data.First(x => x.Key.Equals(node2)).Key);

            //fixing existing rows
            foreach (Dictionary<TreeNode, double> row in data.Values)
            {
                double relation = Math.Sqrt((Math.Pow(row.GetEquals(node1), 2.0) + Math.Pow(row.GetEquals(node2), 2.0)) / 2.0);
                row.Remove(row.First(x => x.Key.Equals(node1)).Key);
                row.Remove(row.First(x => x.Key.Equals(node2)).Key);
                row.Add(newNode, relation);
            }
            data.Add(newNode, newRow);

        }

        private static Dictionary<TreeNode, Dictionary<TreeNode, double>> convertToNodes(Dictionary<string, Dictionary<string, double>> data)
        {
            return data.ToDictionary(x => (TreeNode)new LeafNode(x.Key),
                x => x.Value.ToDictionary(y => (TreeNode)new LeafNode(y.Key),
                    y => y.Value));
        }


        private static List<List<string>> ExtractGroups(Dictionary<TreeNode, Dictionary<TreeNode, double>> treeRelations) {
            var groups = new List<List<string>>();
            foreach (TreeNode node in treeRelations.Keys)
            {
                var group = new List<string>();
                ExtractGroup(node, group);
                groups.Add(group);
            }
            return groups;
        }

        private static void ExtractGroup(TreeNode node, List<string> group)
        {
            if (node is LeafNode)
            {
                group.Add(((LeafNode)node).ImageName);
            }
            else
            {
                InnerNode inner = (InnerNode)node;
                ExtractGroup(inner.LeftNode, group);
                ExtractGroup(inner.RightNode, group);
            }
        }
    }

    public enum ClassificationMode
    {
        INNER, OUTER, INNER_OUTER
    }

    public enum ClassificationType
    {
        NORMAL, SELF
    }
}
