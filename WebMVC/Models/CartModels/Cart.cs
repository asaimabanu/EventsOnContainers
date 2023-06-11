﻿namespace WebMvc.Models.CartModels
{
    public class Cart
    {
        public string BuyerId { get; set; }
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        public decimal Total()
        {
            return Math.Round(Items.Sum(x => x.TicketPrice * x.Quantity), 2);
        }
    }
}