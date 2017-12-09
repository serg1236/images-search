using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchSimilarImages;

namespace UnitTests
{

    [TestClass]
    public class ClassificationTest
    {

        [TestMethod]
        public void ShouldClassifySameImages()
        {
            Dictionary<string, double> img1 = new Dictionary<string, double>();
            img1.Add("1", 0.0);
            img1.Add("2", 0.0);
            img1.Add("3", 1.0);
            img1.Add("4", 1.0);

            Dictionary<string, double> img2 = new Dictionary<string, double>();
            img2.Add("1", 0.0);
            img2.Add("2", 0.0);
            img2.Add("3", 1.0);
            img2.Add("4", 1.0);

            Dictionary<string, double> img3 = new Dictionary<string, double>();
            img3.Add("1", 1.0);
            img3.Add("2", 1.0);
            img3.Add("3", 0.0);
            img3.Add("4", 0.0);

            Dictionary<string, double> img4 = new Dictionary<string, double>();
            img4.Add("1", 1.0);
            img4.Add("2", 1.0);
            img4.Add("3", 0.0);
            img4.Add("4", 0.0);

            Dictionary<string, Dictionary<string, double>> matrix = new Dictionary<string, Dictionary<string, double>>();
            matrix.Add("1", img1);
            matrix.Add("2", img2);
            matrix.Add("3", img3);
            matrix.Add("4", img4);

            List<List<string>> groups = ClassificationUtil.Classify(matrix, ClassificationMode.INNER, 2);
            Assert.AreEqual(2, groups.Count);
            foreach (var group in groups)
            {
                Assert.AreEqual(2, group.Count);
                Assert.IsTrue((group.Contains("1") && group.Contains("2")) ||
                    (group.Contains("3") && group.Contains("4")));
            }
        }



    }
}
