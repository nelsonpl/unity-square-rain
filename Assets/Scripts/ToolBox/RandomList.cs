using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts
{
    public class RandomList<T>  //where T : class
    {
        private readonly List<T> _staticList = new List<T>();
        private List<T> _transactionList;
        private readonly Random _random = new Random();

        public RandomList()
        {
            _transactionList = new List<T>();
        }

        internal void Add(T item)
        {
            _staticList.Add(item);
        }

        internal T Get()
        {
            if (!_transactionList.Any())
            {
                _transactionList = new List<T>(_staticList);
            }

            var index = _random.Next(_transactionList.Count);
            var item = _transactionList[index];
            _transactionList.RemoveAt(index);

            return item;
        }

        internal T Get2()
        {
            if (!_transactionList.Any())
            {
                _transactionList = new List<T>(_staticList);
            }

            var index = _random.Next(_transactionList.Count);
            var item = _transactionList[index];

            return item;
        }
    }
}
