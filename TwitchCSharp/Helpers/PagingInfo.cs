namespace TwitchCSharp.Helpers
{
    // @author gibletto
    public class PagingInfo
    {
        private int _pageSize;
        private const int MaxPageSize = 100;
        /// <summary>
        /// Initializes a new instance of the <see cref="PagingInfo"/> class.
        /// </summary>
        public PagingInfo()
        {
            Page = 1;
            PageSize = 25;
            ViewAll = false;
        }

        protected PagingInfo(PagingInfo pagingInfo)
        {
            Page = pagingInfo.Page;
            PageSize = pagingInfo.PageSize;
            ViewAll = pagingInfo.ViewAll;
        }

        /// <summary>
        /// Gets or sets the page.
        /// </summary>
        /// <value>
        /// The page.
        /// </value>
        public int Page { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [view all].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [view all]; otherwise, <c>false</c>.
        /// </value>
        public bool ViewAll { get; set; }

        /// <summary>
        /// Gets or sets the size of the page.
        /// </summary>
        /// <value>
        /// The size of the page.
        /// </value>
        public int PageSize
        {
            get
            {
                return ViewAll ? MaxPageSize : _pageSize;
            }
            set { _pageSize = value > MaxPageSize ? MaxPageSize : value; }
        }

        /// <summary>
        /// Gets the skip.
        /// </summary>
        /// <value>
        /// The skip.
        /// </value>
        public int Skip
        {
            get { return (Page - 1) * PageSize; }
        }
    }
}