using Microsoft.VisualStudio.TestTools.UnitTesting;
using Composite_Iterator_project;
using Microsoft.VisualBasic;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Aggregate a1 = new Aggregate(1);
            Aggregate a2 = new Aggregate(2);
            Aggregate a3 = new Aggregate(3);
            Composite c1 = new Composite();
            c1.Add(a1);
            c1.Add(a2);
            c1.Add(a3);

            var i = new Composite_Iterator(c1);

            Assert.AreEqual(i.Get_Current(), a1);

            i.MoveNext();

            Assert.AreEqual(i.Get_Current(), a2);

            c1.Delete(a2);

            Assert.AreEqual(i.Get_Current(), a3);

        }
        [TestMethod]
        public void TestMethod2()
        {
            Aggregate a1 = new Aggregate(1);
            Aggregate a2 = new Aggregate(2);
            Aggregate a3 = new Aggregate(3);
            Composite c1 = new Composite();
            c1.Add(a1);
            c1.Add(a2);
            c1.Add(a3);

            var i = new Composite_Iterator(c1);

            Assert.AreEqual(i.Get_Current(), a1);

            c1.Delete(a1); 

            Assert.AreEqual(i.Get_Current(), a2);

            c1.Delete(a2);

            Assert.AreEqual(i.Get_Current(), a3);

            c1.Delete(a3);

            Assert.IsTrue(i.IsDone());

        }
        [TestMethod]
        public void TestMethod3()
        {
            My_List<int> list = new My_List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            var i = list.Create_Iterator();

            Assert.AreEqual(i.Get_Current(), 1);

            i.MoveNext();

            Assert.AreEqual(i.Get_Current(), 2);

            list.Delete(2);

            Assert.AreEqual(i.Get_Current(), 3);

            list.Delete(3);

            Assert.IsTrue( i.IsDone());

        }

        [TestMethod]
        public void TestMethod4()
        {
            Aggregate a1 = new Aggregate(1);
            Aggregate a2 = new Aggregate(2);
            Aggregate a3 = new Aggregate(3);
            Composite c1 = new Composite();
            c1.Add(a1);
            c1.Add(a2);
            c1.Add(a3);
            Aggregate a4 = new Aggregate(4);
            Composite c2 = new Composite();
            c2.Add(c1);
            c2.Add(a4);
            Aggregate a5 = new Aggregate(5);
            Aggregate a6 = new Aggregate(6);
            Composite c3 = new Composite();
            c3.Add(c2);
            Composite c4 = new Composite();
            c4.Add(a5);
            c4.Add(a6);
            c3.Add(c4);

            var i = new Composite_Iterator(c3);
            i.Reset();

            Assert.AreEqual(i.Get_Current(), c2);

            i.MoveNext();
            Assert.AreEqual(i.Get_Current(), c1);

            i.MoveNext();
            Assert.AreEqual(i.Get_Current(), a1);

            i.MoveNext();
            Assert.AreEqual(i.Get_Current(), a2);

            c1.Delete(a1);
            Assert.AreEqual(i.Get_Current(), a2);

            c2.Delete(c1);
            Assert.AreEqual(i.Get_Current(), a4);

            c4.Delete(a6);
            Assert.AreEqual(i.Get_Current(), a4);

            i.MoveNext();
            Assert.AreEqual(i.Get_Current(), c4);

            i.MoveNext();
            Assert.AreEqual(i.Get_Current(), a5);

            c3.Delete(c4);
            Assert.IsTrue(i.IsDone());

        }
    }
}