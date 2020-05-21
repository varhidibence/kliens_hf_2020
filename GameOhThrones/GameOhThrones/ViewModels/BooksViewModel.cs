using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

using GameOhThrones.Core.Models;
using GameOhThrones.Core.Services;
using GameOhThrones.Helpers;

using Microsoft.Toolkit.Uwp.UI.Controls;
using Windows.Media.Miracast;

namespace GameOhThrones.ViewModels
{
    /// <summary>
    /// Control logic to books
    /// Acquires and stores the specified books to show
    /// </summary>
    public class BooksViewModel : Observable
    {
        private Book _selected;
        private int limit = 20;

        public Book Selected
        {
            get { return _selected; }
            set { Set(ref _selected, value); }
        }

        /// <summary>
        /// stored books of the page
        /// </summary>
        public ObservableCollection<Book> SampleItems { get; private set; } =
                new ObservableCollection<Book>();

        public BooksViewModel()
        {
        }

        /// <summary>
        /// Loads async all books from the API and updates the stored books
        /// </summary>
        public async Task LoadDataAsync(MasterDetailsViewState viewState)
        {
            SampleItems.Clear();
            var books = await GameOfThronesDataService.GetAllBooksAsync();
            SubstitueEmptyAttributes(books);

            if (viewState == MasterDetailsViewState.Both)
            {
                if (SampleItems != null)
                    Selected = SampleItems.First();
            }
        }

        /// <summary>
        /// Loads async the books given the list from the API with limit
        /// and updates the stored books
        /// </summary>
        /// <param name="urls">list of URL of books</param>
        public async Task LoadDataAsyncWithURLs(MasterDetailsViewState viewState, string[] urls = null)
        {
            if (urls != null)
            {
                var books = await GameOfThronesDataService.GetBookByUrlAsync(urls, limit);
                SampleItems.Clear();
                SubstitueEmptyAttributes(books);
            }

            if (viewState == MasterDetailsViewState.Both)
            {
                if (SampleItems != null)
                    Selected = SampleItems.First();
            }
        }

        /// <summary>
        /// Substitues empty text in the attributes of given list and add them
        /// to stored list
        /// </summary>
        /// <param name="books">list</param>
        private void SubstitueEmptyAttributes(List<Book> books)
        {
            foreach (var book in books)
            {
                if (book != null)
                {
                    if (book.country.Length == 0) book.country = "N/A";
                    if (book.isbn.Length == 0) book.isbn = "N/A";
                    if (book.mediaType.Length == 0) book.mediaType = "N/A";
                    if (book.name.Length == 0) book.name = "N/A";
                    if (book.publisher.Length == 0) book.publisher = "N/A";

                    SampleItems.Add(book);
                }
            }
        }
    }
}
