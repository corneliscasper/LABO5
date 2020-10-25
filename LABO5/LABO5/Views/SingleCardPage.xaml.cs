using System;
using System.Collections.Generic;
using LABO5.Models;
using LABO5.Repositories;
using Xamarin.Forms;

namespace LABO5.Views
{
    public partial class SingleCardPage : ContentPage
    {
        public TrelloBoard board { get; set; }
        public TrelloList list { get; set; }
        public SingleCardPage(TrelloList list,TrelloBoard board)
        {
            this.list = list;
            this.board = board;
            //lblBoard.Text = board.Name;
            //lblList.Text = list.Name;
            this.Title = "Add a new card";
            InitializeComponent();
        }

        void btnCancel_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
        }

        void btnSave_Clicked(System.Object sender, System.EventArgs e)
        {
            TrelloCard card = new TrelloCard();
            editName.Text = card.Name;
            TrelloRepository.AddCardAsync(list.ListId,card);
        }
    }
}
