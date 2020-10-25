using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LABO5.Models;
using LABO5.Repositories;
using LABO5.Views;
using Xamarin.Forms;


namespace LABO5
{
    public partial class MainPage : ContentPage
    {
        private static Random _rnd = new Random();

        public MainPage()
        {
            InitializeComponent();
            //TestTrelloRepository();
            LoadBoardsAsync();

        }

        private async Task LoadBoardsAsync()
        {
            List<TrelloBoard> boardsList = await TrelloRepository.GetTrelloBoardsAsync();
            lvwBoards.ItemsSource = boardsList;

        }

        private async Task TestTrelloRepository()
        {
            List<TrelloBoard> boardsList = await TrelloRepository.GetTrelloBoardsAsync();
            //foreach(TrelloBoard item in boardsList)
            //{
            //  if (item.IsFavorite)
            //{

            //}


            TrelloBoard selectedBoard = boardsList.Where(x => x.IsFavorite == true).First();

            //2.Trellolist

            List<TrelloList> trelloLists = await TrelloRepository.GetTrelloListAsync(selectedBoard.BoardId);
            TrelloList selectedList = trelloLists[_rnd.Next(trelloLists.Count)];//Random list selector 

            //.3 TrelloCard
            List<TrelloCard> trelloCards = await TrelloRepository.GetTrelloCardAsync(selectedList.ListId);
            TrelloCard selectedCards = trelloCards[_rnd.Next(trelloCards.Count)];//RANDOM Card selector
            //.4 Card Id
            //TrelloCard cardDetail = await TrelloRepository.GetTrelloCardAsync(selectedBoard.)
            TrelloCard trellocardId = await TrelloRepository.GetTrelloCardByIdAsync(selectedCards.CardId);

            //.5 List ophalen
            TrelloList trelloListId = await TrelloRepository.GetTrellListByIdAsync(selectedList.ListId);

            //6. ADD/UPDATE TRELLOCARD
            //string temp = trellocardId.Name;
            //string testName = "Look@fancycard";
            //trellocardId.Name = testName;
            //await TrelloRepository.UpdateCardAsync(trellocardId);
            //bool cardUpdated = (await TrelloRepository.GetTrelloCardByIdAsync(trellocardId.CardId)).Name.Equals(testName);

            //trellocardId.Name = temp;
            //await TrelloRepository.UpdateCardAsync(trellocardId);

            //TrelloCard newCard = new TrelloCard { Name = testName, IsClosed = false };
            //await TrelloRepository.AddCardAsync(selectedList.ListId, newCard);
            //TrelloCard searchCard = (await TrelloRepository.GetTrelloCardAsync(selectedList.ListId)).Where(x => x.Name.Equals(testName)).FirstOrDefault();
            //bool cardAdded = (searchCard != null);

            lvwBoards.ItemsSource = trelloLists;


        }

        void lvwBoards_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            TrelloBoard selectedBoard = lvwBoards.SelectedItem as TrelloBoard;// item ophalen en casten naar een trelloboard
            if (selectedBoard != null)
            {
                //navigate to trello lists page, pass the selected board
                Navigation.PushAsync(new TrelloListPage(selectedBoard));

                //clear selection
                lvwBoards.SelectedItem = null;
            }
        }

    }



}


