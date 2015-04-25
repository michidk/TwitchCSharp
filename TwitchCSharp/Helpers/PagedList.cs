using System;
using System.Collections.Generic;
using TwitchCSharp.Enums;

namespace TwitchCSharp.Helpers
{
    // @author gibletto
    public class PagedList<T> : IPagedList<T>
    {
        private int _pageSize = 25;
        private const int MaxPageSize = 100;
        /// <summary>
        /// Initializes a new instance of the <see cref="PagedList{T}"/> class.
        /// </summary>
        protected PagedList()
        {

        }
        /// <summary>
        /// Initializes a new instance of the <see cref="PagedList{T}"/> class.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="count">The count.</param>
        /// <param name="controller">The controller.</param>
        /// <param name="action">The action.</param>
        /// <param name="pagingTarget">The paging target.</param>
        public PagedList(IEnumerable<T> list, int page, int pageSize, int count)
        {
            List = list;
            Page = page;
            PageSize = pageSize;
            Count = count;
        }

        /// <inheritdoc />
        public IEnumerable<T> List { get; set; }

        /// <inheritdoc />
        public int Page { get; set; }

        /// <inheritdoc />
        public int PageSize { get { return _pageSize; } set { _pageSize = Math.Max(value, MaxPageSize); } }

        /// <inheritdoc />
        public int Count { get; set; }

        /// <inheritdoc />
        public int Start
        {
            get { return ((Page - 1) * PageSize) + 1; }
        }

        /// <inheritdoc />
        public int End
        {
            get { return PageSize * Page > Count ? Count : PageSize * Page; }
        }

        /// <inheritdoc />
        public bool HasNext
        {
            get { return End < Count; }
        }

        /// <inheritdoc />
        public bool HasPrev
        {
            get { return Start > 1; }
        }

        /// <inheritdoc />
        public int NextPage
        {
            get { return Page + 1; }
        }

        /// <inheritdoc />
        public int PrevPage
        {
            get { return Math.Max(Page - 1, 1); }
        }

        /// <inheritdoc />
        public int PageCount
        {
            get
            {
                var hasRemainder = Count % PageSize > 0;
                return (Count / PageSize) + (hasRemainder ? 1 : 0);
            }
        }
    }
}