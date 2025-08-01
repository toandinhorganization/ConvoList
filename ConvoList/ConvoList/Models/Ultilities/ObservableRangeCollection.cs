using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvoList.Models.Ultilities
{
    public class ObservableRangeCollection<T>: ObservableCollection<T>
    {
        public void AddRange(IEnumerable<T> collection)
        {
            if (collection == null)
                return;

            var items = collection as List<T> ?? collection.ToList();
            if (items.Count == 0)
                return;

            var startIndex = Count;

            foreach (var item in items)
            {
                Items.Add(item);
            }
            if (Items == null)
                return;

            OnCollectionChanged(new NotifyCollectionChangedEventArgs(
                NotifyCollectionChangedAction.Add,
                (IList)items,
                startIndex));

            OnPropertyChanged(new PropertyChangedEventArgs(nameof(Count)));

        }
    }
}
