using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace Bookmaster.AppData
{
    public class PaginationService<T>
    {
        // Определям поля для хранения данных
        private const int PAGE_SIZE = 50;
        private readonly List<T> _items;
        private int _currentPageIndex = 0;
        private int _currentPageNumber = 1;

        // Определяем свойства для вычисления и хранения данных
        public int CurrentPageNumber
        {
            get
            {
                return _currentPageNumber = _currentPageIndex + 1;
            }
            set
            {
                _currentPageIndex = value;
                _currentPageNumber = value - 1;
            }
        }

        public int ItemsCount => _items.Count;
        public int TotalPages => (ItemsCount + PAGE_SIZE - 1) / PAGE_SIZE;
        public List<T> CurrentPageOfItems => _items.Skip(_currentPageIndex * PAGE_SIZE).Take(PAGE_SIZE).ToList();

        // Определение конструктор класса для создания Объекта. В контруктор передаем полный список книг.
        public PaginationService(List<T> items)
        {
            _items = items;
        }
        // Определяем методы класса для реализации действий объекта.
        public List<T> NextPage()
        {
            if (_currentPageIndex < TotalPages - 1)
            {
                _currentPageIndex++;
            }
            return CurrentPageOfItems;
        }
        public List<T> PreviusPage()
        {
            if (_currentPageIndex > 0)
            {
                _currentPageIndex--;
            }
            return CurrentPageOfItems;
        }
        public void UpdatePaginationButtons(Button nextBtn, Button previusBtn)
        {
            nextBtn.IsEnabled = _currentPageIndex < TotalPages - 1;
            previusBtn.IsEnabled = _currentPageIndex > 0;
        }
        public List<T> SetCurrentPage(int pageNumber)
        {
            CurrentPageNumber = pageNumber;
            return CurrentPageOfItems;
        }
    }
}
