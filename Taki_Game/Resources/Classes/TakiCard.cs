﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Numerics;
namespace Taki_Game.Resources.Classes
{
        public class TakiCard : INotifyPropertyChanged
        {
        public event PropertyChangedEventHandler PropertyChanged;
        public BitmapImage Image => GlobalVars.LoadImageFromResource($"{Pic}.png");
        public static BitmapImage Back => GlobalVars.LoadImageFromResource("CardImageBack.png");
        public bool Decak { get; set; } = false;
        public bool Stack { get; set; } = false;
        public bool Hand { get; set; } = false;
        public bool notStack { get; set; } = false;
        public string color { get; set; }
        public string val { get; set; }
        public string Pic { get; set; }
        public int Player { get; set; }
        public TakiCard() => VisibleImage = Back;
            BitmapImage _visibleImage;
            public BitmapImage VisibleImage
            {
                get { return _visibleImage; }
                set
                {
                    _visibleImage = value;
                    OnPropertyChanged(nameof(VisibleImage));
                }
            }
            void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            public void setSetColor(string value) => color = value;
            public void setSetValue(string value) => val = value;
            public void setPic() => Pic = $"{color}{val}";
            public void ResetCard()
            {
                Decak = true;
                Stack = false;
                Player = 0;
                Hand = false;
                notStack = true;
            }
            public void GiveCard(int player)
            {
                Decak = true;
                Stack = false;
                Player = player;
                Hand = true;
                notStack = true;
            }
            public void Internalflip(int player)
            {
                if (Hand)
                {
                    if (Player == player)
                    {
                        VisibleImage = Image;
                        return;
                    }
                    else
                    {
                        VisibleImage = Back;
                        return;
                    }
                }
            }
            public void InternalDeflip()
            {
                if (notStack)
                {
                    VisibleImage = Back;
                    return;
                }
            }
            public void PlayCard()
            {
                if (GlobalVars.Plus2Active && this.val != "2+")
                {
                    GlobalVars.Plus2Active = false;
                Game.PeneltyDraw(Game.players_list[GlobalVars.player - 1]);
                return;
                }
                if (GlobalVars.TakiActive)
                {
                    if (this.color == GlobalVars.TakiColor)
                    {
                        if (this.val == "2+")
                        {
                            MessageBox.Show("Impossible move", "Impossible move");
                            return;
                        }
                        else
                        {
                            GlobalVars.nextCardOutStack(this);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Impossible move", "Impossible move");
                    }
                }
                if (!GlobalVars.TakiActive)
                {
                    if (this.val == GlobalVars.lastCardInStack.val || this.color == GlobalVars.lastCardInStack.color || this.color == "" || GlobalVars.lastCardInStack.val == "Change")
                    {
                        GlobalVars.nextCardOutStack(this);
                    }
                    else
                    {
                        MessageBox.Show("Impossible move", "Impossible move");
                    }
                }
            }
        }
    
}