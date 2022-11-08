using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Testing
{
    public class LinqTest
    {
        public int Number;
        public string Id;

        public LinqTest(int num, string id)
        {
            Id = id;
            Number = num;
        }
    }

    public class LinqTestSearch : MonoBehaviour
    {
        private List<LinqTest> _tests;

        public void Start()
        {
           _tests = new List<LinqTest>();
           _tests.Add(new LinqTest(1, "Foo"));
           _tests.Add(new LinqTest(2, "Foo"));
           _tests.Add(new LinqTest(1, "F"));
           _tests.Add(new LinqTest(0, "F"));
           _tests.Add(new LinqTest(0, "Foo"));

           FindWhere();
        }

        public void FindWhere()
        {
            IEnumerable<LinqTest> result = _tests.Where(x => x.Number == 1);

            foreach (var item in result)
            {
                Debug.Log(item.Id);
            }
        }

    }
}
