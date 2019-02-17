using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartLib
{
    /// <summary>
    /// Extended list with events
    /// </summary>
    /// <typeparam name="T">
    /// The type of the elements
    /// </typeparam>
    public class EventList<T> : List<T>
    {
        #region Event(s)
        public event EventHandler<ListEventArgs> CountChanged;
        #endregion
        //---------------------------------------------------------------
        #region Methods
        /// <summary>
        /// Adds an item
        /// </summary>
        public new void Add(T item)
        {
            base.Add(item);

            // Copy to a temporary variable to be thread-safe (MSDN).
            EventHandler<ListEventArgs> tmp = CountChanged;
            if (tmp != null)
                tmp(this, new EventList<T>.ListEventArgs(this.Count));
        }
        //------------------------------------------------------------------
        /// <summary>
        /// Adds a range
        /// </summary>
        public new void AddRange(IEnumerable<T> collection)
        {
            base.AddRange(collection);

            // Copy to a temporary variable to be thread-safe (MSDN).
            EventHandler<ListEventArgs> tmp = CountChanged;
            if (tmp != null)
                tmp(this, new EventList<T>.ListEventArgs(this.Count));
        }
        //------------------------------------------------------------------
        /// <summary>
        /// Clears the list.
        /// </summary>
        public new void Clear()
        {
            base.Clear();

            // Copy to a temporary variable to be thread-safe (MSDN).
            EventHandler<ListEventArgs> tmp = CountChanged;
            if (tmp != null)
                tmp(this, new EventList<T>.ListEventArgs(this.Count));
        }
        //------------------------------------------------------------------
        /// <summary>
        /// Removes the first matched item.
        /// </summary>
        public new void Remove(T item)
        {
            base.Remove(item);

            // Copy to a temporary variable to be thread-safe (MSDN).
            EventHandler<ListEventArgs> tmp = CountChanged;
            if (tmp != null)
                tmp(this, new EventList<T>.ListEventArgs(this.Count));
        }
        #endregion
        //------------------------------------------------------------------
        #region Subclasses
        /// <summary>
        /// EventArgs
        /// </summary>
        public class ListEventArgs : EventArgs
        {
            /// <summary>
            /// Number of elements in the list
            /// </summary>
            public int Count { get; set; }
            //----------------------------------------------------------
            public ListEventArgs(int anzahl)
            {
                this.Count = anzahl;
            }
        }
        #endregion
    }
}
