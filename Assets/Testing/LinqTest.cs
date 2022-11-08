using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Testing
{
    public class LinqTest
    {
        private int _munber;
        private string _id;
        LinqTest()
        {
            if (Random.value <= 0.5)
                _munber = 0;
            if(Random.value > 0.5)
                _munber = 1;
            if (Random.value <= 0.5)
                _id = "Foo";
            if (Random.value > 0.5)
                _id = "Goo";
        }
    }
    public class LinqTestSearch
    {
        private List<LinqTest> tests;
        
    }
}
