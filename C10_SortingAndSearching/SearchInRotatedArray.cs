namespace C10_SortingAndSearching
{
    public class SearchInRotatedArray<T>
    {
        T[] test = new T[3];
        public int SearchValue { get; private set; }
        private int[] _arr;
        public int Count { get; private set; }
        public int Search(int[] arr, int searchValue)
        {
            SearchValue = searchValue;
            _arr = arr;
            Count = 0;
            return Search(0, arr.Length - 1);
        }

        private int Search(int left, int right)
        {

            int mid = (right + left) / 2;
            if (_arr[mid] == SearchValue) return mid;
            if (right < left) return -1;
            Count++;

            if (LeftIsOrdered(left, mid))
            {
                if (SearchValue >= _arr[left] && SearchValue < _arr[mid])
                    return Search(left, mid - 1); // go left

                return Search(mid, right); // go right
            }

            if (RightIsOrdered(left, mid))
            {
                if (SearchValue <= _arr[right] && SearchValue > _arr[mid])
                    return Search(mid + 1, right);

                return Search(left, mid - 1);
            }

            // if we're here, then _arr[left] == _arr[mid], so dups found on left

            if (_arr[right] != _arr[mid]) // no dups on right
            {
                if (SearchValue > _arr[mid] && SearchValue <= _arr[right])
                    return Search(mid + 1, right);

                return Search(left, mid - 1); // go left
            }

            // search both sides
            int ret = Search(left, mid-1); // go left
            if (ret > -1)
                return ret;

            return Search(mid+1, right); // go right
        }

        private bool RightIsOrdered(int left, int mid) => _arr[left] > _arr[mid];

        private bool LeftIsOrdered(int left, int mid) => _arr[left] < _arr[mid];
    }
}
